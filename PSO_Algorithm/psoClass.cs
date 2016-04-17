/*
 * psoClass.cs
 * Melisa Griffin
 * 4/16/2016
 * 
 * This file defines the classes Particle and psoClass.
 *
 */

using System;

namespace PSO_Algorithm
{
    /*
     * Class Particle: This class defines the Particle Objects. These are the 
     * actual particles that are doing the swarming. 
     */
    public class Particle
    {
        public double particleX { get; set; }        //Particle X coordinate
        public double particleY { get; set; }        //Particle Y coordinate
        public double pValue    { get; set; }        //Particle Value
        public double perBest   { get; set; }        //Personal best
        public double perBestX  { get; set; }        //Personal best X coordinate
        public double perBestY  { get; set; }        //Personal best Y coordinate
        public double velX      { get; set; }        //Velocity x distance
        public double velY      { get; set; }        //Velocity y distance
    }


    /*
     * This class implements the actual PSO algorithm.
     * 
     */
    public class psoClass
    {
        #region Member Variables
        //Array of particle objects
        private Particle [] _particles;
        public Particle [] particles
        {
            get { return _particles; }
            set { _particles = value; }
        }

        //Number of particles in the array
        private int _numParticles;
        public int numParticles
        {
            get { return _numParticles; }
            set { _numParticles = value; }
        }

        //The best location found by the particles so far
        private Particle _globalBest;
        public Particle globalBest
        {
            get { return _globalBest; }
            set { _globalBest = value; }
        }
        #endregion

        public psoClass()
        {
            //chose 400 particles to do the searching
            numParticles = 400;                         

            //create memory for array of particles
            particles = new Particle[numParticles];     

            //create particle objects
            for (int i = 0; i < numParticles; ++i)
            {
                particles[i] = new Particle();
            }

            //create the global best particle object
            globalBest = new Particle();

            //This will initialize everything to have certain values 
            //and positions in a grid shape
            reset();
        }

        public void functionCalc(int fun)
        {
            /*
             * This function switches between the three functions that the 
             * program will calculate the PSO on.
             */
            switch (fun)
            {
                case 0:
                    //Bohachevsky 1
                    for (int i = 0; i < numParticles; ++i)
                    {
                        particles[i].pValue = Math.Pow(particles[i].particleX, 2) + 2 * Math.Pow(particles[i].particleY, 2)
                                              - 0.3 * Math.Cos(3 * Math.PI * particles[i].particleX) - 0.4 * Math.Cos(4 * Math.PI * particles[i].particleX)
                                              + 0.7;
                    }
                    break;
                case 1:
                    //Easom
                    for (int i = 0; i < numParticles; ++i)
                    {
                        particles[i].pValue = -Math.Cos(particles[i].particleX) * Math.Cos(particles[i].particleY) *
                                               Math.Exp(-(Math.Pow(particles[i].particleX - Math.PI, 2)) - (Math.Pow(particles[i].particleY - Math.PI, 2)));
                    }
                    break;
                case 2:
                    //Beale's
                    for (int i = 0; i < numParticles; ++i)
                    {
                        particles[i].pValue = Math.Pow(1.5 - particles[i].particleX + particles[i].particleX * particles[i].particleY, 2) +
                                              Math.Pow(2.25 - particles[i].particleX + particles[i].particleX * Math.Pow(particles[i].particleY, 2), 2) +
                                              Math.Pow(2.625 - particles[i].particleX + particles[i].particleX * Math.Pow(particles[i].particleY, 3), 2);
                    }
                    break;
                default:
                    //Resets the particles to 0
                    for (int i = 0; i < numParticles; ++i)
                    {
                        particles[i].pValue = 0;
                    }
                    break;
            }   
            
        }

        public void updateBest()
        {
            /*
             * This function updates two things. The first is each particle's
             * personal best, the second is the global best.
             */ 
            for (int i = 0; i < numParticles; ++i)
            {
                if(particles[i].pValue < particles[i].perBest)
                {
                    particles[i].perBest = particles[i].pValue;
                    particles[i].perBestX = particles[i].particleX;
                    particles[i].perBestY = particles[i].particleY;
                }
                if (particles[i].pValue < globalBest.pValue)
                {
                    globalBest.pValue = particles[i].pValue;
                    globalBest.particleX = particles[i].particleX;
                    globalBest.particleY = particles[i].particleY;
                }
            }
        }

        public void updateVelPos(double vMax)
        {
            /*
             * This function updates each particle's velocity and position.
             */

             //scalar used to control the velocity
            double c = .5;
            double inertialWeight = .5;

            //generates a random scalar between 0 and 1
            Random rand = new Random();
            double r = rand.NextDouble();

            for (int i = 0; i < numParticles; ++i)
            {
                //calculates velocity for x and y based off of previous 
                //velocity and their current location with respect to the 
                //globalBest and their personal best
                particles[i].velX = inertialWeight*particles[i].velX + c*r*(particles[i].perBestX - particles[i].particleX) + c*r*(globalBest.particleX - particles[i].particleX);
                particles[i].velY = inertialWeight*particles[i].velY + c*r*(particles[i].perBestY - particles[i].particleY) + c*r*(globalBest.particleY - particles[i].particleY);

                //These if statements restrict the particles velocity to the
                //maximum
                if (particles[i].velX > vMax)
                    particles[i].velX = vMax;
                if (particles[i].velY > vMax)
                    particles[i].velY = vMax;

                if (particles[i].velX < -vMax)
                    particles[i].velX = -vMax;
                if (particles[i].velY < -vMax)
                    particles[i].velY = -vMax;

                //calculate the particles new position based off of velocity
                particles[i].particleX += particles[i].velX;
                particles[i].particleY += particles[i].velY;
            }
        }

        public void reset()
        {
            //first point in the grid is (1,1)
            double x = 1,
                   y = 1;

            //This can be used to scale the grid size
            double scale = 10;

            //Set the global best value
            //Since we are looking for the minimum,
            //the global best is set to a large value, and the coordinates
            //just initialized to 0
            globalBest.pValue = 1000;
            globalBest.particleX = 0;
            globalBest.particleY = 0;

            for (int i = 0; i < numParticles/4; ++i)
            {
                /* This sets the x and y coordinates to the initial grid
                 *   ........|.........
                 *   ........|.........
                 *   ........|.........
                 *   ........|.........
                 *   ------------------
                 *   ........|.........
                 *   ........|.........
                 *   ........|.........
                 *   ........|......... 
                 * 
                 */

                //The first two set up the positive x, positive y plane.
                particles[i].particleX = x / 10 * scale;
                particles[i].particleY = y / 10 * scale;

                //Set up the negative x, positive y plane.
                particles[i + numParticles / 4].particleX = -x / 10 * scale;
                particles[i + numParticles / 4].particleY = y / 10 * scale;

                //Set up the negative x, negative y plane.
                particles[i + numParticles / 2].particleX = -x / 10 * scale;
                particles[i + numParticles / 2].particleY = -y / 10 * scale;

                //Set up the positve x, negative y plane.
                particles[i + numParticles - (numParticles / 4)].particleX = x / 10 * scale;
                particles[i + numParticles - (numParticles / 4)].particleY = -y / 10 * scale;


                //Set the particular particle's personal best value
                //Since we are looking for the minimum,
                //the personal best is set to a large value, and the coordinates
                //just initialized to 0
                particles[i].perBest = 1000;
                particles[i].perBestX = 0;
                particles[i].perBestY = 0;

                //Set the particle's initial velocity to 0
                particles[i].velX = 0;
                particles[i].velY = 0;

                //increment y each time
                ++y;

                //when y gets to the top, reset it to 0, and increment x
                if (y > Math.Sqrt(numParticles/4))
                {
                    ++x;
                    y = 1;
                }

                //Initialize the particles' values
                functionCalc(-1);
            }
        }

        public double convergence(int fun)
        {
            /*
             * This function calculates the % of particles that converged onto
             * the global best
             */

            double numConverged = 0;
            double tempX = 0;
            double tempY = 0;

            //the amount of error allowed for Easom and Beale's
            double errorMargin = 0.01;                   

            switch (fun)
            {
                case 0:
                    //Bohachevsky 
                    /* **Special Case**
                     * Because Bohachevsky's minimum is at (0,0), we cannot use
                     * the typical error equation.
                     *   (experimental - actual)/actual
                     *   //because you cannot divide by 0
                     * So consider any particles within .1 to be converged on
                     * the solution
                     */
                    for (int i = 0; i < numParticles; ++i)
                    {
                        tempX = particles[i].particleX;
                        tempY = particles[i].particleY - globalBest.particleY;

                        if (tempX <= 0.1 && tempY <= 0.1)
                        {
                            ++numConverged;
                        }
                    }
                    break;
                case 1:
                case 2:
                default:
                    //Easom and Beale's
                    /*
                     * For these two use the error equation:
                     *   (experimental - actual)/actual
                     * If a particle comes within 1% of the actual minimum 
                     * consider the particle converged.
                     */
                    for (int i = 0; i < numParticles; ++i)
                    {
                        tempX = particles[i].particleX - globalBest.particleX;
                        tempX = Math.Abs(tempX / globalBest.particleX);

                        tempY = particles[i].particleY - globalBest.particleY;
                        tempY = Math.Abs(tempY / globalBest.particleY);

                        if (tempX <= errorMargin && tempY <= errorMargin)
                        {
                            ++numConverged;
                        }
                    }
                    break;
                }

            //returns percentage of particles that converged
            return (numConverged / numParticles);
        }

    }
}

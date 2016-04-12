using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PSO_Algorithm
{
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

            reset();
        }

        public void functionCalc(int fun)
        {
            switch (fun)
            {
                case 0:
                    for (int i = 0; i < numParticles; ++i)
                    {
                        particles[i].pValue = Math.Pow(particles[i].particleX, 2) + 2 * Math.Pow(particles[i].particleY, 2)
                                              - 0.3 * Math.Cos(3 * Math.PI * particles[i].particleX) - 0.4 * Math.Cos(4 * Math.PI * particles[i].particleX)
                                              + 0.7;
                    }
                    break;
                case 1:
                    for (int i = 0; i < numParticles; ++i)
                    {
                        particles[i].pValue = -Math.Cos(particles[i].particleX) * Math.Cos(particles[i].particleY) *
                                               Math.Exp(-(Math.Pow(particles[i].particleX - Math.PI, 2)) - (Math.Pow(particles[i].particleY - Math.PI, 2)));
                    }
                    break;
                case 2:
                    for (int i = 0; i < numParticles; ++i)
                    {
                        particles[i].pValue = Math.Pow(1.5 - particles[i].particleX + particles[i].particleX * particles[i].particleY, 2) +
                                              Math.Pow(2.25 - particles[i].particleX + particles[i].particleX * Math.Pow(particles[i].particleY, 2), 2) +
                                              Math.Pow(2.625 - particles[i].particleX + particles[i].particleX * Math.Pow(particles[i].particleY, 3), 2);
                    }
                    break;
                default:
                    for (int i = 0; i < numParticles; ++i)
                    {
                        particles[i].pValue = 0;
                    }
                    break;
            }   
            
        }

        public void updateBest()
        {
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
            double c = 1.494;
            for (int i = 0; i < numParticles; ++i)
            {
                Random rand = new Random();
                double r = 1;// rand.NextDouble();

                particles[i].velX = 0.5*particles[i].velX + c*r*(particles[i].perBestX - particles[i].particleX) + c*r*(globalBest.particleX - particles[i].particleX);
                particles[i].velY = 0.5*particles[i].velY + c*r*(particles[i].perBestY - particles[i].particleY) + c*r*(globalBest.particleY - particles[i].particleY);

                if (particles[i].velX > vMax)
                    particles[i].velX = vMax;
                if (particles[i].velY > vMax)
                    particles[i].velY = vMax;

                if (particles[i].velX < -vMax)
                    particles[i].velX = -vMax;
                if (particles[i].velY < -vMax)
                    particles[i].velY = -vMax;

                particles[i].particleX += particles[i].velX;
                particles[i].particleY += particles[i].velY;
            }
        }

        public void reset()
        {

            double x = 1,
                   y = 1;

            double scale = 10;

            //Set the global best particle value and location
            globalBest.pValue = 1000;
            globalBest.particleX = 0;
            globalBest.particleY = 0;

            for (int i = 0; i < numParticles/4; ++i)
            {


                //This sets the x and y coordinates to the initial grid
                particles[i].particleX = x / 10 * scale;
                particles[i].particleY = y / 10 * scale;
                particles[i + 100].particleX = -x / 10 * scale;
                particles[i + 100].particleY = y / 10 * scale;
                particles[i + 200].particleX = -x / 10 * scale;
                particles[i + 200].particleY = -y / 10 * scale;
                particles[i + 300].particleX = x / 10 * scale;
                particles[i + 300].particleY = -y / 10 * scale;

                //Set the particular particle's personal best value
                //Since this is a constuctor and we are looking for the minimum,
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

        public double convergance()
        {
            double numConverged = 0;
            double tempX = 0;
            double tempY = 0;         


            for (int i = 0; i < numParticles; ++i)
            {
                tempX = particles[i].particleX - globalBest.particleX;
                tempX = Math.Abs(tempX / globalBest.particleX);

                tempY = particles[i].particleY - globalBest.particleY;
                tempY = Math.Abs(tempY / globalBest.particleY);
                
                //Console.WriteLine(tempX + " " + tempY);
                if (tempX <= 0.01 && tempY <= 0.01)
                {
                    ++numConverged;
                }
            }

            return (numConverged / numParticles);
        }

    }
}

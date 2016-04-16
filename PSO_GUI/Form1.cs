/*
 * Form1.cs
 * Melisa Griffin
 * 4/16/2016
 * 
 * This file defines the GUI of the main window for the PSO demonstration
 *
 */

using System;
using System.Windows.Forms;
using PSO_Algorithm;

namespace PSO_GUI
{
    public partial class Form1 : Form
    {
        public Boolean start;                       //Boolean used to start algorithm
        public psoClass runVar = new psoClass();    //object of PSO class
        public double vMax = 25;                    //maximum velocity allowed
        public int runs = 0;                        //iteration counter
        public int selFunct = 0;                    //function selected

        //These constants define the zoom levels for the different functions
        //The default setting is from x: -10 to 10, y: -10 to 10.
        //Function 0, in this implementation, has a solution at (0,0), so it is
        //best for it to zoom to .5.
        //Function 1 and 2 in this implementation zoom to 5
        public const double ZOOM_DEFAULT = 10;
        public const double ZOOM_F0 = .5;
        public const double ZOOM_F1 = 5;
        public const double ZOOM_F2 = 5;

        //Chose to do 200 iterations
        public const int TOTAL_RUNS = 200;

        public Form1()
        {
            InitializeComponent();
        }

        //Starts the simulation
        private void btn_START_Click(object sender, EventArgs e)
        {
            //disable the start, reset, and zoom buttons
            //don't want them getting pressed while the demo is running
            this.btn_start.Enabled = false;
            this.btReset.Enabled   = false;
            this.btnZOOM.Enabled   = false;

            start = true;

            //clear the graph's points
            ParticlePlot.Series["Series1"].Points.Clear();

            //re-plot the graph's points
            for (int j = 0; j < runVar.numParticles; ++j)
                ParticlePlot.Series["Series1"].Points.AddXY(runVar.particles[j].particleX, runVar.particles[j].particleY);
        }

        /*
         * This is a timer that updates the GUI ever so often. (So that you can
         * see the particles converging on the point)
         */
        private void psoTick_Tick(object sender, EventArgs e)
        {
            //While start was the last button pushed and the total number of 
            //runs is less than the max runs allowed
            if(start && runs < TOTAL_RUNS)
            {
                //recalculate the values and current positions of particles
                runVar.functionCalc(selFunct);

                //reupdate the particles' current bests and the global best
                runVar.updateBest();

                //get new velocity of particles
                runVar.updateVelPos(vMax);
               
                //replot the particles on the graph
                if (runs % 20 == 0)
                {
                    ParticlePlot.Series["Series1"].Points.Clear();
                    for (int j = 0; j < runVar.numParticles; ++j)
                    {
                        ParticlePlot.Series["Series1"].Points.AddXY(runVar.particles[j].particleX, runVar.particles[j].particleY);
                    }
                }

                //dampen the velocity
                vMax = ((1 - (runs / TOTAL_RUNS)) ^ 2) * vMax;

                ++runs;
            }

            //If runs has reached the end, populate the fields for the ideal
            //x-coordinate, y-coordinate, value at that point, and the % 
            //of particles that actually converged on that point
            if (runs > TOTAL_RUNS - 1)
            {
                this.btReset.Enabled = true;
                this.btnZOOM.Enabled = true;
                start = false;
                this.tbXcoor.Text = Math.Round( runVar.globalBest.particleX, 2).ToString(); 
                this.tbYcoor.Text = Math.Round(runVar.globalBest.particleY, 2).ToString();
                this.tbOpt.Text = Math.Round(runVar.globalBest.pValue,2).ToString();
                this.tbPercConv.Text = Math.Round(runVar.convergence(selFunct) *100, 2).ToString();
            }
                
        }

        /*
         * Loads the main GUI. Sets the graph to have the default zoom level,
         * and adds the initial grid of particles
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbFuncSel.SelectedIndex = 0;

            ParticlePlot.ChartAreas[0].AxisX.Minimum = -ZOOM_DEFAULT;
            ParticlePlot.ChartAreas[0].AxisX.Maximum = ZOOM_DEFAULT;
            ParticlePlot.ChartAreas[0].AxisY.Minimum = -ZOOM_DEFAULT;
            ParticlePlot.ChartAreas[0].AxisY.Maximum = ZOOM_DEFAULT;

            ParticlePlot.Series["Series1"].Points.Clear();
            for (int j = 0; j < runVar.numParticles; ++j)
            {
                ParticlePlot.Series["Series1"].Points.AddXY(runVar.particles[j].particleX, runVar.particles[j].particleY);
            }
        }

        /*
         * Whenever the function is changed this resets the selected function
         * to be what was selected, and resets runs to 0. Resetting runs to 0
         * keeps the ticking object from changing any fields.
         */
        private void cbFuncSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFunct = this.cbFuncSel.SelectedIndex;
            runs = 0;
        }

        /*
         * Resets the graph's points, the graph's zoom, and the fields that 
         * show the results
         */
        private void btReset_Click(object sender, EventArgs e)
        {
            runs = 0;
            runVar.reset();
            ParticlePlot.Series["Series1"].Points.Clear();
            for (int j = 0; j < runVar.numParticles; ++j)
            {
                ParticlePlot.Series["Series1"].Points.AddXY(runVar.particles[j].particleX, runVar.particles[j].particleY);
            }

            ParticlePlot.ChartAreas[0].AxisX.Minimum = -ZOOM_DEFAULT;
            ParticlePlot.ChartAreas[0].AxisX.Maximum = ZOOM_DEFAULT;
            ParticlePlot.ChartAreas[0].AxisY.Minimum = -ZOOM_DEFAULT;
            ParticlePlot.ChartAreas[0].AxisY.Maximum = ZOOM_DEFAULT;

            this.tbXcoor.Text = "";
            this.tbYcoor.Text = "";
            this.tbOpt.Text = "";
            this.tbPercConv.Text = "";
            this.btn_start.Enabled = true;
        }

        /*
         * Opens the INFO window whenever pressed
         */
        private void btnINFO_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if(f is Form2)
                {
                    f.Activate();
                }
            }
            Form2 frm = new Form2();
            frm.Show();
        }

        /*
         * Zooms in on the graph whenever pressed. The zoom amount is based on
         * which function is currently selected
         */
        private void btnZOOM_Click(object sender, EventArgs e)
        {
            switch (selFunct)
            {
                case 0: ParticlePlot.ChartAreas[0].AxisX.Minimum = -ZOOM_F0;
                        ParticlePlot.ChartAreas[0].AxisX.Maximum = ZOOM_F0;
                        ParticlePlot.ChartAreas[0].AxisY.Minimum = -ZOOM_F0;
                        ParticlePlot.ChartAreas[0].AxisY.Maximum = ZOOM_F0;
                    break;
                case 1:
                        ParticlePlot.ChartAreas[0].AxisX.Minimum = -ZOOM_F1;
                        ParticlePlot.ChartAreas[0].AxisX.Maximum = ZOOM_F1;
                        ParticlePlot.ChartAreas[0].AxisY.Minimum = -ZOOM_F1;
                        ParticlePlot.ChartAreas[0].AxisY.Maximum = ZOOM_F1;
                    break;
                case 2:
                        ParticlePlot.ChartAreas[0].AxisX.Minimum = -ZOOM_F2;
                        ParticlePlot.ChartAreas[0].AxisX.Maximum = ZOOM_F2;
                        ParticlePlot.ChartAreas[0].AxisY.Minimum = -ZOOM_F2;
                        ParticlePlot.ChartAreas[0].AxisY.Maximum = ZOOM_F2;
                    break;
                default:
                        ParticlePlot.ChartAreas[0].AxisX.Minimum = -ZOOM_DEFAULT;
                        ParticlePlot.ChartAreas[0].AxisX.Maximum = ZOOM_DEFAULT;
                        ParticlePlot.ChartAreas[0].AxisY.Minimum = -ZOOM_DEFAULT;
                        ParticlePlot.ChartAreas[0].AxisY.Maximum = ZOOM_DEFAULT;
                    break;
            }
        }
    }
}

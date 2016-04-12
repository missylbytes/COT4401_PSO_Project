using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using PSO_Algorithm;
using System.Threading;

namespace PSO_GUI
{
    public partial class Form1 : Form
    {
        public Boolean start;
        public psoClass runVar = new psoClass();
        public double vMax = 50;
        public int runs = 0;
        public int selFunct = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_START_Click(object sender, EventArgs e)
        {
            this.btn_start.Enabled = false;
            this.btReset.Enabled   = false;
            this.btnZOOM.Enabled   = false;
            start = true;
            

            ParticlePlot.Series["Series1"].Points.Clear();
            for (int j = 0; j < runVar.numParticles; ++j)
            {
                ParticlePlot.Series["Series1"].Points.AddXY(runVar.particles[j].particleX, runVar.particles[j].particleY);
            }

        }

        private void psoTick_Tick(object sender, EventArgs e)
        {
            if(start && runs < 200)
            {
                runVar.functionCalc(selFunct);
                runVar.updateBest();
                runVar.updateVelPos(vMax);
               
                if (runs % 20 == 0)
                {
                    ParticlePlot.Series["Series1"].Points.Clear();
                    for (int j = 0; j < runVar.numParticles; ++j)
                    {
                        ParticlePlot.Series["Series1"].Points.AddXY(runVar.particles[j].particleX, runVar.particles[j].particleY);
                    }
                }
                vMax = ((1 - (runs / 200)) ^ 2) * vMax;
                runs = runs + 1;
            }

            if (runs > 199)
            {
                this.btReset.Enabled = true;
                this.btnZOOM.Enabled = true;
                start = false;
                this.tbXcoor.Text = Math.Round( runVar.globalBest.particleX, 2).ToString(); 
                this.tbYcoor.Text = Math.Round(runVar.globalBest.particleY, 2).ToString();
                this.tbOpt.Text = Math.Round(runVar.globalBest.pValue,2).ToString();
                this.tbPercConv.Text = Math.Round(runVar.convergance()*100, 2).ToString();
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbFuncSel.SelectedIndex = 0;

            ParticlePlot.ChartAreas[0].AxisX.Minimum = -10;
            ParticlePlot.ChartAreas[0].AxisX.Maximum = 10;
            ParticlePlot.ChartAreas[0].AxisY.Minimum = -10;
            ParticlePlot.ChartAreas[0].AxisY.Maximum = 10;

            ParticlePlot.Series["Series1"].Points.Clear();
            for (int j = 0; j < runVar.numParticles; ++j)
            {
                ParticlePlot.Series["Series1"].Points.AddXY(runVar.particles[j].particleX, runVar.particles[j].particleY);
            }
        }

        private void cbFuncSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFunct = this.cbFuncSel.SelectedIndex;
            //switch(selFunct)
            //{
            //    case 0:
                    
            //        break;
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    default:
            //        break;
            //}
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            runs = 0;
            runVar.reset();
            ParticlePlot.Series["Series1"].Points.Clear();
            for (int j = 0; j < runVar.numParticles; ++j)
            {
                ParticlePlot.Series["Series1"].Points.AddXY(runVar.particles[j].particleX, runVar.particles[j].particleY);
            }

            ParticlePlot.ChartAreas[0].AxisX.Minimum = -10;
            ParticlePlot.ChartAreas[0].AxisX.Maximum = 10;
            ParticlePlot.ChartAreas[0].AxisY.Minimum = -10;
            ParticlePlot.ChartAreas[0].AxisY.Maximum = 10;

            this.tbXcoor.Text = "";
            this.tbYcoor.Text = "";
            this.tbOpt.Text = "";
            this.tbPercConv.Text = "";
            this.btn_start.Enabled = true;
        }

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
            //frm.MdiParent = this;
            frm.Show();
        }

        private void btnZOOM_Click(object sender, EventArgs e)
        {
            switch (selFunct)
            {
                case 0: ParticlePlot.ChartAreas[0].AxisX.Minimum = -.5;
                        ParticlePlot.ChartAreas[0].AxisX.Maximum = .5;
                        ParticlePlot.ChartAreas[0].AxisY.Minimum = -.5;
                        ParticlePlot.ChartAreas[0].AxisY.Maximum = .5;
                    break;
                case 1:
                        ParticlePlot.ChartAreas[0].AxisX.Minimum = -5;
                        ParticlePlot.ChartAreas[0].AxisX.Maximum = 5;
                        ParticlePlot.ChartAreas[0].AxisY.Minimum = -5;
                        ParticlePlot.ChartAreas[0].AxisY.Maximum = 5;
                    break;
                case 2:
                        ParticlePlot.ChartAreas[0].AxisX.Minimum = -5;
                        ParticlePlot.ChartAreas[0].AxisX.Maximum = 5;
                        ParticlePlot.ChartAreas[0].AxisY.Minimum = -5;
                        ParticlePlot.ChartAreas[0].AxisY.Maximum = 5;
                    break;
                default:
                        ParticlePlot.ChartAreas[0].AxisX.Minimum = -10;
                        ParticlePlot.ChartAreas[0].AxisX.Maximum = 10;
                        ParticlePlot.ChartAreas[0].AxisY.Minimum = -10;
                        ParticlePlot.ChartAreas[0].AxisY.Maximum = 10;
                    break;
            }
        }
    }
}

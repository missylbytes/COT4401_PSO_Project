namespace PSO_GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_pso = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ParticlePlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.psoTick = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbXcoor = new System.Windows.Forms.TextBox();
            this.tbYcoor = new System.Windows.Forms.TextBox();
            this.cbFuncSel = new System.Windows.Forms.ComboBox();
            this.tbOpt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPercConv = new System.Windows.Forms.TextBox();
            this.btReset = new System.Windows.Forms.Button();
            this.btnINFO = new System.Windows.Forms.Button();
            this.btnZOOM = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ParticlePlot)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_start.Location = new System.Drawing.Point(12, 392);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(159, 32);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_START_Click);
            // 
            // lbl_pso
            // 
            this.lbl_pso.AutoSize = true;
            this.lbl_pso.Location = new System.Drawing.Point(187, 62);
            this.lbl_pso.Name = "lbl_pso";
            this.lbl_pso.Size = new System.Drawing.Size(72, 13);
            this.lbl_pso.TabIndex = 1;
            this.lbl_pso.Text = "Optimal Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y Coordinate";
            // 
            // ParticlePlot
            // 
            chartArea1.Name = "ChartArea1";
            this.ParticlePlot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ParticlePlot.Legends.Add(legend1);
            this.ParticlePlot.Location = new System.Drawing.Point(12, 12);
            this.ParticlePlot.Name = "ParticlePlot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ParticlePlot.Series.Add(series1);
            this.ParticlePlot.Size = new System.Drawing.Size(750, 374);
            this.ParticlePlot.TabIndex = 3;
            this.ParticlePlot.Text = "chart1";
            // 
            // psoTick
            // 
            this.psoTick.Enabled = true;
            this.psoTick.Interval = 25;
            this.psoTick.Tick += new System.EventHandler(this.psoTick_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X Coordinate";
            // 
            // tbXcoor
            // 
            this.tbXcoor.Location = new System.Drawing.Point(80, 31);
            this.tbXcoor.Name = "tbXcoor";
            this.tbXcoor.Size = new System.Drawing.Size(100, 20);
            this.tbXcoor.TabIndex = 5;
            // 
            // tbYcoor
            // 
            this.tbYcoor.Location = new System.Drawing.Point(80, 57);
            this.tbYcoor.Name = "tbYcoor";
            this.tbYcoor.Size = new System.Drawing.Size(100, 20);
            this.tbYcoor.TabIndex = 6;
            // 
            // cbFuncSel
            // 
            this.cbFuncSel.FormattingEnabled = true;
            this.cbFuncSel.Items.AddRange(new object[] {
            "Bohachevsky 1",
            "Easom",
            "Beale\'s"});
            this.cbFuncSel.Location = new System.Drawing.Point(205, 424);
            this.cbFuncSel.Name = "cbFuncSel";
            this.cbFuncSel.Size = new System.Drawing.Size(108, 21);
            this.cbFuncSel.TabIndex = 7;
            this.cbFuncSel.SelectedIndexChanged += new System.EventHandler(this.cbFuncSel_SelectedIndexChanged);
            // 
            // tbOpt
            // 
            this.tbOpt.Location = new System.Drawing.Point(265, 59);
            this.tbOpt.Name = "tbOpt";
            this.tbOpt.Size = new System.Drawing.Size(100, 20);
            this.tbOpt.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPercConv);
            this.groupBox1.Controls.Add(this.tbXcoor);
            this.groupBox1.Controls.Add(this.tbOpt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbl_pso);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbYcoor);
            this.groupBox1.Location = new System.Drawing.Point(337, 398);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 105);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "% Converged";
            // 
            // tbPercConv
            // 
            this.tbPercConv.Location = new System.Drawing.Point(265, 31);
            this.tbPercConv.Name = "tbPercConv";
            this.tbPercConv.Size = new System.Drawing.Size(100, 20);
            this.tbPercConv.TabIndex = 9;
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(12, 431);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(159, 32);
            this.btReset.TabIndex = 10;
            this.btReset.Text = "RESET";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // btnINFO
            // 
            this.btnINFO.Location = new System.Drawing.Point(716, 475);
            this.btnINFO.Name = "btnINFO";
            this.btnINFO.Size = new System.Drawing.Size(46, 28);
            this.btnINFO.TabIndex = 11;
            this.btnINFO.Text = "INFO";
            this.btnINFO.UseVisualStyleBackColor = true;
            this.btnINFO.Click += new System.EventHandler(this.btnINFO_Click);
            // 
            // btnZOOM
            // 
            this.btnZOOM.Location = new System.Drawing.Point(12, 469);
            this.btnZOOM.Name = "btnZOOM";
            this.btnZOOM.Size = new System.Drawing.Size(159, 34);
            this.btnZOOM.TabIndex = 12;
            this.btnZOOM.Text = "ZOOM";
            this.btnZOOM.UseVisualStyleBackColor = true;
            this.btnZOOM.Click += new System.EventHandler(this.btnZOOM_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Function Select";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 509);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnZOOM);
            this.Controls.Add(this.btnINFO);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbFuncSel);
            this.Controls.Add(this.ParticlePlot);
            this.Controls.Add(this.btn_start);
            this.MinimumSize = new System.Drawing.Size(790, 547);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ParticlePlot)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lbl_pso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ParticlePlot;
        private System.Windows.Forms.Timer psoTick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbXcoor;
        private System.Windows.Forms.TextBox tbYcoor;
        private System.Windows.Forms.ComboBox cbFuncSel;
        private System.Windows.Forms.TextBox tbOpt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Button btnINFO;
        private System.Windows.Forms.Button btnZOOM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPercConv;
        private System.Windows.Forms.Label label4;
    }
}


﻿namespace BrainApp
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.btnBuld = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewThrowThresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMinVal = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.tbSliceNum = new System.Windows.Forms.TrackBar();
            this.tbRayNum1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRayNum2 = new System.Windows.Forms.TextBox();
            this.tbCRSpeed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCRRange = new System.Windows.Forms.TextBox();
            this.tbTODown = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTOUp = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optioanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plottingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbCR = new System.Windows.Forms.CheckBox();
            this.cbGrad = new System.Windows.Forms.CheckBox();
            this.tbGradThr = new System.Windows.Forms.TextBox();
            this.tbGradient = new System.Windows.Forms.TextBox();
            this.rbThreshold = new System.Windows.Forms.RadioButton();
            this.rbGrad = new System.Windows.Forms.RadioButton();
            this.panelVisual = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtChartMax = new System.Windows.Forms.TextBox();
            this.txtChartMin = new System.Windows.Forms.TextBox();
            this.panelChart = new System.Windows.Forms.Panel();
            this.btnHist = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinVal)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSliceNum)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelVisual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.AnT.BackColor = System.Drawing.Color.White;
            this.AnT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AnT.Location = new System.Drawing.Point(18, 0);
            this.AnT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(640, 656);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            this.AnT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseClick);
            this.AnT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseDown);
            this.AnT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseMove);
            this.AnT.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.AnTMouseWheel);
            // 
            // btnBuld
            // 
            this.btnBuld.Location = new System.Drawing.Point(548, 717);
            this.btnBuld.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuld.Name = "btnBuld";
            this.btnBuld.Size = new System.Drawing.Size(112, 35);
            this.btnBuld.TabIndex = 2;
            this.btnBuld.Text = "Build";
            this.btnBuld.UseVisualStyleBackColor = true;
            this.btnBuld.Click += new System.EventHandler(this.btnBuld_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(548, 672);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 35);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(669, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(766, 786);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.sliceMouseWheel);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewThrowThresholdToolStripMenuItem,
            this.showGradientToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(278, 64);
            // 
            // viewThrowThresholdToolStripMenuItem
            // 
            this.viewThrowThresholdToolStripMenuItem.Name = "viewThrowThresholdToolStripMenuItem";
            this.viewThrowThresholdToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.viewThrowThresholdToolStripMenuItem.Text = "Show through threshold";
            this.viewThrowThresholdToolStripMenuItem.Click += new System.EventHandler(this.viewThrowThresholdToolStripMenuItem_Click);
            // 
            // showGradientToolStripMenuItem
            // 
            this.showGradientToolStripMenuItem.Name = "showGradientToolStripMenuItem";
            this.showGradientToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.showGradientToolStripMenuItem.Text = "Show gradient";
            this.showGradientToolStripMenuItem.Click += new System.EventHandler(this.showGradientToolStripMenuItem_Click);
            // 
            // tbMinVal
            // 
            this.tbMinVal.Location = new System.Drawing.Point(342, -2);
            this.tbMinVal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMinVal.Name = "tbMinVal";
            this.tbMinVal.Size = new System.Drawing.Size(156, 69);
            this.tbMinVal.TabIndex = 5;
            this.tbMinVal.Scroll += new System.EventHandler(this.tbMinVal_Scroll);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblVal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblZ);
            this.panel1.Controls.Add(this.lblY);
            this.panel1.Controls.Add(this.lblX);
            this.panel1.Controls.Add(this.tbSliceNum);
            this.panel1.Controls.Add(this.tbMinVal);
            this.panel1.Location = new System.Drawing.Point(0, 865);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1457, 47);
            this.panel1.TabIndex = 6;
            // 
            // lblVal
            // 
            this.lblVal.AutoSize = true;
            this.lblVal.Location = new System.Drawing.Point(1394, 12);
            this.lblVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(18, 20);
            this.lblVal.TabIndex = 14;
            this.lblVal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1358, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Val:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1298, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1244, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1178, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "X:";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(1320, 12);
            this.lblZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(18, 20);
            this.lblZ.TabIndex = 9;
            this.lblZ.Text = "0";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(1264, 12);
            this.lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(18, 20);
            this.lblY.TabIndex = 8;
            this.lblY.Text = "0";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(1202, 12);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(18, 20);
            this.lblX.TabIndex = 7;
            this.lblX.Text = "0";
            // 
            // tbSliceNum
            // 
            this.tbSliceNum.Location = new System.Drawing.Point(4, -2);
            this.tbSliceNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSliceNum.Name = "tbSliceNum";
            this.tbSliceNum.Size = new System.Drawing.Size(346, 69);
            this.tbSliceNum.TabIndex = 6;
            this.tbSliceNum.Scroll += new System.EventHandler(this.tbSliceNum_Scroll);
            // 
            // tbRayNum1
            // 
            this.tbRayNum1.Location = new System.Drawing.Point(63, 672);
            this.tbRayNum1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRayNum1.Name = "tbRayNum1";
            this.tbRayNum1.Size = new System.Drawing.Size(48, 26);
            this.tbRayNum1.TabIndex = 7;
            this.tbRayNum1.Text = "200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 677);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Rays";
            // 
            // tbRayNum2
            // 
            this.tbRayNum2.Location = new System.Drawing.Point(122, 672);
            this.tbRayNum2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRayNum2.Name = "tbRayNum2";
            this.tbRayNum2.Size = new System.Drawing.Size(48, 26);
            this.tbRayNum2.TabIndex = 9;
            this.tbRayNum2.Text = "100";
            // 
            // tbCRSpeed
            // 
            this.tbCRSpeed.Location = new System.Drawing.Point(184, 720);
            this.tbCRSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCRSpeed.Name = "tbCRSpeed";
            this.tbCRSpeed.Size = new System.Drawing.Size(48, 26);
            this.tbCRSpeed.TabIndex = 12;
            this.tbCRSpeed.Text = "1,1";
            this.tbCRSpeed.MouseHover += new System.EventHandler(this.tbCRRange_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 726);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Check ray";
            // 
            // tbCRRange
            // 
            this.tbCRRange.Location = new System.Drawing.Point(126, 720);
            this.tbCRRange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCRRange.Name = "tbCRRange";
            this.tbCRRange.Size = new System.Drawing.Size(48, 26);
            this.tbCRRange.TabIndex = 10;
            this.tbCRRange.Text = "1";
            this.tbCRRange.MouseHover += new System.EventHandler(this.tbCRRange_MouseHover);
            // 
            // tbTODown
            // 
            this.tbTODown.Location = new System.Drawing.Point(478, 665);
            this.tbTODown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTODown.Name = "tbTODown";
            this.tbTODown.Size = new System.Drawing.Size(48, 26);
            this.tbTODown.TabIndex = 15;
            this.tbTODown.Text = "-100";
            this.tbTODown.MouseHover += new System.EventHandler(this.tbCRRange_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 671);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ray type";
            // 
            // tbTOUp
            // 
            this.tbTOUp.Location = new System.Drawing.Point(420, 665);
            this.tbTOUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTOUp.Name = "tbTOUp";
            this.tbTOUp.Size = new System.Drawing.Size(48, 26);
            this.tbTOUp.TabIndex = 13;
            this.tbTOUp.Text = "500";
            this.tbTOUp.MouseHover += new System.EventHandler(this.tbCRRange_MouseHover);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1458, 35);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.openToolStripMenuItem.Text = "Open..";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optioanToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.optionsToolStripMenuItem.Text = "Configuration";
            // 
            // optioanToolStripMenuItem
            // 
            this.optioanToolStripMenuItem.Name = "optioanToolStripMenuItem";
            this.optioanToolStripMenuItem.Size = new System.Drawing.Size(148, 30);
            this.optioanToolStripMenuItem.Text = "Options";
            this.optioanToolStripMenuItem.Click += new System.EventHandler(this.optioanToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.plottingToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Checked = true;
            this.mainToolStripMenuItem.CheckOnClick = true;
            this.mainToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(205, 30);
            this.mainToolStripMenuItem.Text = "3DVisualization";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // plottingToolStripMenuItem
            // 
            this.plottingToolStripMenuItem.CheckOnClick = true;
            this.plottingToolStripMenuItem.Name = "plottingToolStripMenuItem";
            this.plottingToolStripMenuItem.Size = new System.Drawing.Size(205, 30);
            this.plottingToolStripMenuItem.Text = "Chart";
            this.plottingToolStripMenuItem.Click += new System.EventHandler(this.plottingToolStripMenuItem_Click);
            // 
            // cbCR
            // 
            this.cbCR.AutoSize = true;
            this.cbCR.Checked = true;
            this.cbCR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCR.Location = new System.Drawing.Point(18, 725);
            this.cbCR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCR.Name = "cbCR";
            this.cbCR.Size = new System.Drawing.Size(22, 21);
            this.cbCR.TabIndex = 18;
            this.cbCR.UseVisualStyleBackColor = true;
            this.cbCR.CheckedChanged += new System.EventHandler(this.cbCR_CheckedChanged);
            // 
            // cbGrad
            // 
            this.cbGrad.AutoSize = true;
            this.cbGrad.Location = new System.Drawing.Point(16, 763);
            this.cbGrad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbGrad.Name = "cbGrad";
            this.cbGrad.Size = new System.Drawing.Size(141, 24);
            this.cbGrad.TabIndex = 19;
            this.cbGrad.Text = "Grad threshold";
            this.cbGrad.UseVisualStyleBackColor = true;
            this.cbGrad.CheckedChanged += new System.EventHandler(this.cbGrad_CheckedChanged);
            // 
            // tbGradThr
            // 
            this.tbGradThr.Location = new System.Drawing.Point(152, 760);
            this.tbGradThr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGradThr.Name = "tbGradThr";
            this.tbGradThr.Size = new System.Drawing.Size(48, 26);
            this.tbGradThr.TabIndex = 20;
            this.tbGradThr.Text = "30";
            // 
            // tbGradient
            // 
            this.tbGradient.Location = new System.Drawing.Point(420, 694);
            this.tbGradient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGradient.Name = "tbGradient";
            this.tbGradient.Size = new System.Drawing.Size(48, 26);
            this.tbGradient.TabIndex = 23;
            this.tbGradient.Text = "200";
            // 
            // rbThreshold
            // 
            this.rbThreshold.AutoSize = true;
            this.rbThreshold.Checked = true;
            this.rbThreshold.Location = new System.Drawing.Point(310, 671);
            this.rbThreshold.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbThreshold.Name = "rbThreshold";
            this.rbThreshold.Size = new System.Drawing.Size(104, 24);
            this.rbThreshold.TabIndex = 24;
            this.rbThreshold.TabStop = true;
            this.rbThreshold.Text = "Threshold";
            this.rbThreshold.UseVisualStyleBackColor = true;
            // 
            // rbGrad
            // 
            this.rbGrad.AutoSize = true;
            this.rbGrad.Location = new System.Drawing.Point(310, 695);
            this.rbGrad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbGrad.Name = "rbGrad";
            this.rbGrad.Size = new System.Drawing.Size(96, 24);
            this.rbGrad.TabIndex = 25;
            this.rbGrad.Text = "Gradient";
            this.rbGrad.UseVisualStyleBackColor = true;
            // 
            // panelVisual
            // 
            this.panelVisual.Controls.Add(this.rbGrad);
            this.panelVisual.Controls.Add(this.rbThreshold);
            this.panelVisual.Controls.Add(this.tbGradThr);
            this.panelVisual.Controls.Add(this.tbGradient);
            this.panelVisual.Controls.Add(this.cbGrad);
            this.panelVisual.Controls.Add(this.cbCR);
            this.panelVisual.Controls.Add(this.tbTODown);
            this.panelVisual.Controls.Add(this.label7);
            this.panelVisual.Controls.Add(this.tbTOUp);
            this.panelVisual.Controls.Add(this.tbCRSpeed);
            this.panelVisual.Controls.Add(this.label6);
            this.panelVisual.Controls.Add(this.tbCRRange);
            this.panelVisual.Controls.Add(this.tbRayNum2);
            this.panelVisual.Controls.Add(this.label5);
            this.panelVisual.Controls.Add(this.tbRayNum1);
            this.panelVisual.Controls.Add(this.btnLoad);
            this.panelVisual.Controls.Add(this.btnBuld);
            this.panelVisual.Controls.Add(this.AnT);
            this.panelVisual.Location = new System.Drawing.Point(0, 43);
            this.panelVisual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelVisual.Name = "panelVisual";
            this.panelVisual.Size = new System.Drawing.Size(666, 814);
            this.panelVisual.TabIndex = 26;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(4, -2);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(639, 614);
            this.chart1.TabIndex = 26;
            this.chart1.Text = "chart";
            // 
            // txtChartMax
            // 
            this.txtChartMax.Location = new System.Drawing.Point(75, 623);
            this.txtChartMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtChartMax.Name = "txtChartMax";
            this.txtChartMax.Size = new System.Drawing.Size(60, 26);
            this.txtChartMax.TabIndex = 27;
            this.txtChartMax.Text = "200";
            this.txtChartMax.TextChanged += new System.EventHandler(this.txtChartMin_TextChanged);
            // 
            // txtChartMin
            // 
            this.txtChartMin.Location = new System.Drawing.Point(6, 622);
            this.txtChartMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtChartMin.Name = "txtChartMin";
            this.txtChartMin.Size = new System.Drawing.Size(60, 26);
            this.txtChartMin.TabIndex = 28;
            this.txtChartMin.Text = "-100";
            this.txtChartMin.TextChanged += new System.EventHandler(this.txtChartMin_TextChanged);
            // 
            // panelChart
            // 
            this.panelChart.Controls.Add(this.chart2);
            this.panelChart.Controls.Add(this.btnHist);
            this.panelChart.Controls.Add(this.txtChartMin);
            this.panelChart.Controls.Add(this.chart1);
            this.panelChart.Controls.Add(this.txtChartMax);
            this.panelChart.Location = new System.Drawing.Point(8, 43);
            this.panelChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(652, 658);
            this.panelChart.TabIndex = 27;
            this.panelChart.Visible = false;
            // 
            // btnHist
            // 
            this.btnHist.Location = new System.Drawing.Point(568, 625);
            this.btnHist.Name = "btnHist";
            this.btnHist.Size = new System.Drawing.Size(75, 33);
            this.btnHist.TabIndex = 29;
            this.btnHist.Text = "Hist";
            this.btnHist.UseVisualStyleBackColor = true;
            this.btnHist.Click += new System.EventHandler(this.btnHist_Click);
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(0, 5);
            this.chart2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(639, 614);
            this.chart2.TabIndex = 30;
            this.chart2.Text = "chart";
            this.chart2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 912);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelVisual);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Brainwork";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbMinVal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSliceNum)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelVisual.ResumeLayout(false);
            this.panelVisual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panelChart.ResumeLayout(false);
            this.panelChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Button btnBuld;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar tbMinVal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar tbSliceNum;
        private System.Windows.Forms.Label lblVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TextBox tbRayNum1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRayNum2;
        private System.Windows.Forms.TextBox tbCRSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCRRange;
        private System.Windows.Forms.TextBox tbTODown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTOUp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optioanToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbCR;
        private System.Windows.Forms.CheckBox cbGrad;
        private System.Windows.Forms.TextBox tbGradThr;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewThrowThresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGradientToolStripMenuItem;
        private System.Windows.Forms.TextBox tbGradient;
        private System.Windows.Forms.RadioButton rbThreshold;
        private System.Windows.Forms.RadioButton rbGrad;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plottingToolStripMenuItem;
        private System.Windows.Forms.Panel panelVisual;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtChartMin;
        private System.Windows.Forms.TextBox txtChartMax;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Button btnHist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}


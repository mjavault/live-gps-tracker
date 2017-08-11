namespace LiveGpsTracking
{
    partial class FormMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.txtComPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtBaudrate = new System.Windows.Forms.TextBox();
            this.chartAltitude = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkFollow = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuxComPort = new System.Windows.Forms.TextBox();
            this.txtAuxBaudrate = new System.Windows.Forms.TextBox();
            this.btnAuxConnect = new System.Windows.Forms.Button();
            this.btnAuxDisconnect = new System.Windows.Forms.Button();
            this.serialPortAux = new System.IO.Ports.SerialPort(this.components);
            this.timerHeartbeat = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartAltitude)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtComPort
            // 
            this.txtComPort.Location = new System.Drawing.Point(3, 3);
            this.txtComPort.Name = "txtComPort";
            this.txtComPort.Size = new System.Drawing.Size(50, 21);
            this.txtComPort.TabIndex = 0;
            this.txtComPort.Text = "COM4";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(115, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(196, 0);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.Location = new System.Drawing.Point(264, 29);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(579, 191);
            this.txtConsole.TabIndex = 4;
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(3, 29);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(255, 191);
            this.txtStatus.TabIndex = 5;
            // 
            // txtBaudrate
            // 
            this.txtBaudrate.Location = new System.Drawing.Point(59, 3);
            this.txtBaudrate.Name = "txtBaudrate";
            this.txtBaudrate.Size = new System.Drawing.Size(50, 21);
            this.txtBaudrate.TabIndex = 0;
            this.txtBaudrate.Text = "4800";
            // 
            // chartAltitude
            // 
            this.chartAltitude.BorderlineColor = System.Drawing.SystemColors.ActiveBorder;
            this.chartAltitude.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Maximum = 500D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.Maximum = 500D;
            chartArea1.AxisY2.Minimum = -500D;
            chartArea1.Name = "ChartAreaAltitude";
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.Maximum = 500D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartAreaVS";
            this.chartAltitude.ChartAreas.Add(chartArea1);
            this.chartAltitude.ChartAreas.Add(chartArea2);
            this.chartAltitude.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartAltitude.Legends.Add(legend1);
            this.chartAltitude.Location = new System.Drawing.Point(10, 239);
            this.chartAltitude.Name = "chartAltitude";
            series1.ChartArea = "ChartAreaAltitude";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Altitude (ft)";
            series2.ChartArea = "ChartAreaVS";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "VS (ft/min)";
            this.chartAltitude.Series.Add(series1);
            this.chartAltitude.Series.Add(series2);
            this.chartAltitude.Size = new System.Drawing.Size(849, 197);
            this.chartAltitude.TabIndex = 6;
            this.chartAltitude.Text = "chart1";
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(10, 436);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(849, 368);
            this.gmap.TabIndex = 7;
            this.gmap.Zoom = 0D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkFollow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAuxComPort);
            this.panel1.Controls.Add(this.txtAuxBaudrate);
            this.panel1.Controls.Add(this.txtComPort);
            this.panel1.Controls.Add(this.btnAuxConnect);
            this.panel1.Controls.Add(this.txtBaudrate);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.btnAuxDisconnect);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.btnDisconnect);
            this.panel1.Controls.Add(this.txtConsole);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 229);
            this.panel1.TabIndex = 8;
            // 
            // chkFollow
            // 
            this.chkFollow.AutoSize = true;
            this.chkFollow.Checked = true;
            this.chkFollow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFollow.Location = new System.Drawing.Point(434, 6);
            this.chkFollow.Name = "chkFollow";
            this.chkFollow.Size = new System.Drawing.Size(56, 17);
            this.chkFollow.TabIndex = 7;
            this.chkFollow.Text = "Follow";
            this.chkFollow.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Auxiliary GPS:";
            // 
            // txtAuxComPort
            // 
            this.txtAuxComPort.Location = new System.Drawing.Point(576, 3);
            this.txtAuxComPort.Name = "txtAuxComPort";
            this.txtAuxComPort.Size = new System.Drawing.Size(50, 21);
            this.txtAuxComPort.TabIndex = 0;
            this.txtAuxComPort.Text = "COM6";
            // 
            // txtAuxBaudrate
            // 
            this.txtAuxBaudrate.Location = new System.Drawing.Point(632, 3);
            this.txtAuxBaudrate.Name = "txtAuxBaudrate";
            this.txtAuxBaudrate.Size = new System.Drawing.Size(50, 21);
            this.txtAuxBaudrate.TabIndex = 0;
            this.txtAuxBaudrate.Text = "4800";
            // 
            // btnAuxConnect
            // 
            this.btnAuxConnect.Location = new System.Drawing.Point(688, 0);
            this.btnAuxConnect.Name = "btnAuxConnect";
            this.btnAuxConnect.Size = new System.Drawing.Size(75, 23);
            this.btnAuxConnect.TabIndex = 1;
            this.btnAuxConnect.Text = "Connect";
            this.btnAuxConnect.UseVisualStyleBackColor = true;
            this.btnAuxConnect.Click += new System.EventHandler(this.btnAuxConnect_Click);
            // 
            // btnAuxDisconnect
            // 
            this.btnAuxDisconnect.Enabled = false;
            this.btnAuxDisconnect.Location = new System.Drawing.Point(769, 0);
            this.btnAuxDisconnect.Name = "btnAuxDisconnect";
            this.btnAuxDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnAuxDisconnect.TabIndex = 3;
            this.btnAuxDisconnect.Text = "Disconnect";
            this.btnAuxDisconnect.UseVisualStyleBackColor = true;
            this.btnAuxDisconnect.Click += new System.EventHandler(this.btnAuxDisconnect_Click);
            // 
            // timerHeartbeat
            // 
            this.timerHeartbeat.Enabled = true;
            this.timerHeartbeat.Interval = 1000;
            this.timerHeartbeat.Tick += new System.EventHandler(this.timerHeartbeat_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 814);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.chartAltitude);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Live GPS Tracking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartAltitude)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox txtComPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtBaudrate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAltitude;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuxComPort;
        private System.Windows.Forms.TextBox txtAuxBaudrate;
        private System.Windows.Forms.Button btnAuxConnect;
        private System.Windows.Forms.Button btnAuxDisconnect;
        private System.IO.Ports.SerialPort serialPortAux;
        private System.Windows.Forms.CheckBox chkFollow;
        private System.Windows.Forms.Timer timerHeartbeat;
    }
}


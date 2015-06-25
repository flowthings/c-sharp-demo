namespace flowthingsTemperatureGraphDemo
{
    partial class TempGraph
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tmrHeartbeat = new System.Windows.Forms.Timer(this.components);
            this.tmrSend = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(690, 240);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(120, 258);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(148, 49);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect...";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tmrHeartbeat
            // 
            this.tmrHeartbeat.Interval = 30000;
            this.tmrHeartbeat.Tick += new System.EventHandler(this.tmrHeartbeat_Tick);
            // 
            // tmrSend
            // 
            this.tmrSend.Interval = 20000;
            this.tmrSend.Tick += new System.EventHandler(this.tmrSend_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(274, 258);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(145, 49);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Sending";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(426, 259);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(132, 48);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop Sending";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(13, 258);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(101, 49);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create Flow";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // TempGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 342);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.chart1);
            this.Name = "TempGraph";
            this.Text = "Temperature Graph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TempGraph_FormClosing);
            this.Load += new System.EventHandler(this.TempGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Timer tmrHeartbeat;
        private System.Windows.Forms.Timer tmrSend;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnCreate;
    }
}


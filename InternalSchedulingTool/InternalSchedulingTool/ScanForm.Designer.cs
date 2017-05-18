namespace InternalSchedulingTool
{
    partial class ScanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanForm));
            this.cmbSelectSite = new System.Windows.Forms.ComboBox();
            this.lblSelectSite = new System.Windows.Forms.Label();
            this.txtIPsToScan = new System.Windows.Forms.TextBox();
            this.lblIPsToScan = new System.Windows.Forms.Label();
            this.dtpscanTime = new System.Windows.Forms.DateTimePicker();
            this.lblOn = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbScanNow = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.btnGetSites = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbSelectSite
            // 
            this.cmbSelectSite.FormattingEnabled = true;
            this.cmbSelectSite.Location = new System.Drawing.Point(84, 12);
            this.cmbSelectSite.Name = "cmbSelectSite";
            this.cmbSelectSite.Size = new System.Drawing.Size(182, 21);
            this.cmbSelectSite.TabIndex = 0;
            // 
            // lblSelectSite
            // 
            this.lblSelectSite.AutoSize = true;
            this.lblSelectSite.Location = new System.Drawing.Point(4, 15);
            this.lblSelectSite.Name = "lblSelectSite";
            this.lblSelectSite.Size = new System.Drawing.Size(58, 13);
            this.lblSelectSite.TabIndex = 1;
            this.lblSelectSite.Text = "Select Site";
            // 
            // txtIPsToScan
            // 
            this.txtIPsToScan.Location = new System.Drawing.Point(84, 92);
            this.txtIPsToScan.Multiline = true;
            this.txtIPsToScan.Name = "txtIPsToScan";
            this.txtIPsToScan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIPsToScan.Size = new System.Drawing.Size(182, 345);
            this.txtIPsToScan.TabIndex = 2;
            // 
            // lblIPsToScan
            // 
            this.lblIPsToScan.AutoSize = true;
            this.lblIPsToScan.Location = new System.Drawing.Point(4, 95);
            this.lblIPsToScan.Name = "lblIPsToScan";
            this.lblIPsToScan.Size = new System.Drawing.Size(62, 13);
            this.lblIPsToScan.TabIndex = 3;
            this.lblIPsToScan.Text = "IPs to Scan";
            // 
            // dtpscanTime
            // 
            this.dtpscanTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpscanTime.Location = new System.Drawing.Point(84, 60);
            this.dtpscanTime.Name = "dtpscanTime";
            this.dtpscanTime.Size = new System.Drawing.Size(182, 20);
            this.dtpscanTime.TabIndex = 4;
            // 
            // lblOn
            // 
            this.lblOn.AutoSize = true;
            this.lblOn.Location = new System.Drawing.Point(4, 60);
            this.lblOn.Name = "lblOn";
            this.lblOn.Size = new System.Drawing.Size(52, 13);
            this.lblOn.TabIndex = 5;
            this.lblOn.Text = "On (UTC)";
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.Location = new System.Drawing.Point(11, 469);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(128, 68);
            this.btnScan.TabIndex = 6;
            this.btnScan.Text = "SCAN";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(84, 443);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(182, 20);
            this.txtDuration.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Max Duration\r\n(Seconds)";
            // 
            // cbScanNow
            // 
            this.cbScanNow.AutoSize = true;
            this.cbScanNow.Location = new System.Drawing.Point(277, 63);
            this.cbScanNow.Name = "cbScanNow";
            this.cbScanNow.Size = new System.Drawing.Size(79, 17);
            this.cbScanNow.TabIndex = 9;
            this.cbScanNow.Text = "Scan Now!";
            this.cbScanNow.UseVisualStyleBackColor = true;
            this.cbScanNow.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 68);
            this.button1.TabIndex = 10;
            this.button1.Text = "Submit exception";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(4, 36);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(51, 13);
            this.lblTemplate.TabIndex = 12;
            this.lblTemplate.Text = "Template";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(84, 36);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(182, 21);
            this.cmbTemplate.TabIndex = 13;
            // 
            // btnGetSites
            // 
            this.btnGetSites.Location = new System.Drawing.Point(146, 469);
            this.btnGetSites.Name = "btnGetSites";
            this.btnGetSites.Size = new System.Drawing.Size(125, 68);
            this.btnGetSites.TabIndex = 14;
            this.btnGetSites.Text = "Get Sites";
            this.btnGetSites.UseVisualStyleBackColor = true;
            this.btnGetSites.Click += new System.EventHandler(this.btnGetSites_Click);
            // 
            // ScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 549);
            this.Controls.Add(this.btnGetSites);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbScanNow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lblOn);
            this.Controls.Add(this.dtpscanTime);
            this.Controls.Add(this.lblIPsToScan);
            this.Controls.Add(this.txtIPsToScan);
            this.Controls.Add(this.lblSelectSite);
            this.Controls.Add(this.cmbSelectSite);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScanForm";
            this.Text = "Nexpose Scan Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelectSite;
        private System.Windows.Forms.Label lblSelectSite;
        private System.Windows.Forms.TextBox txtIPsToScan;
        private System.Windows.Forms.Label lblIPsToScan;
        private System.Windows.Forms.DateTimePicker dtpscanTime;
        private System.Windows.Forms.Label lblOn;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbScanNow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Button btnGetSites;
    }
}


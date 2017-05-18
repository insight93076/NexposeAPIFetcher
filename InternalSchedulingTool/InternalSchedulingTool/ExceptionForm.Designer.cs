namespace InternalSchedulingTool
{
    partial class ExceptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtIps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVulnName = new System.Windows.Forms.Label();
            this.txtTicket = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRequestor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbExceptionType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.expDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSiteSelect = new System.Windows.Forms.ComboBox();
            this.cmbVulnTitle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(217, 450);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(288, 58);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit Exceptions";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtIps
            // 
            this.txtIps.Location = new System.Drawing.Point(15, 41);
            this.txtIps.Multiline = true;
            this.txtIps.Name = "txtIps";
            this.txtIps.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIps.Size = new System.Drawing.Size(196, 467);
            this.txtIps.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Except these IPs:";
            // 
            // lblVulnName
            // 
            this.lblVulnName.AutoSize = true;
            this.lblVulnName.Location = new System.Drawing.Point(217, 71);
            this.lblVulnName.Name = "lblVulnName";
            this.lblVulnName.Size = new System.Drawing.Size(67, 13);
            this.lblVulnName.TabIndex = 3;
            this.lblVulnName.Text = "With this title";
            this.lblVulnName.Click += new System.EventHandler(this.lblVulnName_Click);
            // 
            // txtTicket
            // 
            this.txtTicket.Location = new System.Drawing.Point(304, 97);
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.Size = new System.Drawing.Size(200, 20);
            this.txtTicket.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "As per ticket #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "As requested by";
            // 
            // txtRequestor
            // 
            this.txtRequestor.Location = new System.Drawing.Point(304, 125);
            this.txtRequestor.Name = "txtRequestor";
            this.txtRequestor.Size = new System.Drawing.Size(200, 20);
            this.txtRequestor.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "As an";
            // 
            // cmbExceptionType
            // 
            this.cmbExceptionType.FormattingEnabled = true;
            this.cmbExceptionType.Location = new System.Drawing.Point(304, 153);
            this.cmbExceptionType.Name = "cmbExceptionType";
            this.cmbExceptionType.Size = new System.Drawing.Size(200, 21);
            this.cmbExceptionType.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "To expire on";
            // 
            // expDate
            // 
            this.expDate.Location = new System.Drawing.Point(304, 180);
            this.expDate.Name = "expDate";
            this.expDate.Size = new System.Drawing.Size(200, 20);
            this.expDate.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "From this site";
            // 
            // cmbSiteSelect
            // 
            this.cmbSiteSelect.FormattingEnabled = true;
            this.cmbSiteSelect.Location = new System.Drawing.Point(304, 41);
            this.cmbSiteSelect.Name = "cmbSiteSelect";
            this.cmbSiteSelect.Size = new System.Drawing.Size(201, 21);
            this.cmbSiteSelect.TabIndex = 15;
            // 
            // cmbVulnTitle
            // 
            this.cmbVulnTitle.FormattingEnabled = true;
            this.cmbVulnTitle.Location = new System.Drawing.Point(302, 68);
            this.cmbVulnTitle.Name = "cmbVulnTitle";
            this.cmbVulnTitle.Size = new System.Drawing.Size(378, 21);
            this.cmbVulnTitle.TabIndex = 16;
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 520);
            this.Controls.Add(this.cmbVulnTitle);
            this.Controls.Add(this.cmbSiteSelect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.expDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbExceptionType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRequestor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTicket);
            this.Controls.Add(this.lblVulnName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIps);
            this.Controls.Add(this.btnSubmit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExceptionForm";
            this.Text = "ExceptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtIps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVulnName;
        private System.Windows.Forms.TextBox txtTicket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRequestor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbExceptionType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker expDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSiteSelect;
        private System.Windows.Forms.ComboBox cmbVulnTitle;
    }
}
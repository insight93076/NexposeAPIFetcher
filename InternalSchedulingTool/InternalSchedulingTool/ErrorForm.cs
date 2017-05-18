using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternalSchedulingTool
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = ScanForm.error;
            lblErrorMessage.Refresh();
            this.Visible = false;
            this.Show();
        }
        private void ErrorForm_Load(object sender, EventArgs e, string titleText)
        {
            lblErrorMessage.Text = ScanForm.error;
            lblErrorMessage.Refresh();
            this.Text = "Success";
            this.Visible = false;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

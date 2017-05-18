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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            ScanForm scan = new ScanForm(txtUser.Text, txtPass.Text);
            scan.ShowDialog();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

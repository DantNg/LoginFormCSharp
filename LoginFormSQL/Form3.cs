using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginFormSQL
{
    public partial class homeForm : Form
    {
        public homeForm()
        {
            InitializeComponent();
        }

        private void homeForm_Load(object sender, EventArgs e)
        {

        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginPage = new LoginForm();
            loginPage.ShowDialog();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginPage = new LoginForm();
            loginPage.ShowDialog();
        }
    }
}

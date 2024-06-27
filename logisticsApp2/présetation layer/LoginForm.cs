using logisticsApp2.business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logisticsApp2.présetation_layer
{
    public partial class LoginForm : Form
    {
        business_layer.clsLogin loginFct = new clsLogin();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            DataTable dt =loginFct.login (login_btn.Text, login_password.Text);
            if (dt.Rows.Count >0 )
            {
                MessageBox.Show("Connecter avec succée");
            }
            else
            {
                MessageBox.Show(" Erreur de se connecter");
            }
        }
    }
}

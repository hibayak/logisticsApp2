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
    
    public partial class Home : Form
    {
        présetation_layer.AccueilServiceVente AccueilServiceVente = new AccueilServiceVente();

        public Home()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            panel1Home.Controls.Clear();
            panel1Home.Controls.Add(AccueilServiceVente.panelAccueil);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}

using logisticsApp2.présetation_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logisticsApp2
{
    public partial class Logistic : Form
    {
        
       présetation_layer.AccueilServiceVente AccueilServiceVente= new AccueilServiceVente();
        présetation_layer.Home Home = new Home();
       
 public Logistic()
        {    
            InitializeComponent();
         }
        //home_page_start
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
           panel1.Controls.Add(Home.panel1Home);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
       
        private void button8_Click(object sender, EventArgs e)
        {
            

        }
        //fermer
        private void button17_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void agrandire_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void réduire_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
           panel1.Controls.Clear();
           panel1.Controls.Add(AccueilServiceVente.panelAccueil);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

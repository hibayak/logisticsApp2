using logisticsApp2;
using logisticsApp2.présetation_layer;
using logisticsApp2.data_access_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using OfficeOpenXml;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;

namespace logisticsApp2.présetation_layer
{
    public partial class AccueilServiceVente : Form

    {
        string path, pos;
        //Connection connection111;
       // DataAdapter da;
        //System.Data.DataTable  dt;
        présetation_layer.LoginForm login = new LoginForm();

        public ConnectionBDD ConnectionBDD;
        public AccueilServiceVente()
        {
            InitializeComponent();
            ConnectionBDD = new ConnectionBDD();
            LoadData();
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void MainForm_Load(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void AccueilventePanel_Paint(object sender, PaintEventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel6_Paint(object sender, PaintEventArgs e) { }
        private void button11_Click(object sender, EventArgs e) { }
        private void button28_Click(object sender, EventArgs e) { }
        private void button32_Click(object sender, EventArgs e) { }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void panel5_Paint(object sender, PaintEventArgs e) { }
        private void panelside_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void button58_Click(object sender, EventArgs e) { }
        private void button98_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {  // Obtenez la valeur de défilement actuelle
            int scrollValue = vScrollBar1.Value;
            // en fonction de la valeur de défilement déplacez les contrôles dans le formulaire
            //panel9.Location = new Point(panel9.Location.X, -scrollValue);
        }
        private void vScrollBar2_Scroll_1(object sender, ScrollEventArgs e)
        {
            int scrollValue2 = vScrollBar2.Value;
            //panel1p5.Location = new Point(panel1p5.Location.X, -scrollValue2);
        }
        private void AccueilServiceVente_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(DataGridHelper.GetValueFromDataGridView(dataGridView3, "Id"));
        }
        private void button102_Click(object sender, EventArgs e)
        {
            clearDatabase();
            clearDataGridView();
        }
        private void button103_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionBDD cBd = new ConnectionBDD();
                cBd.Diconnect_fct();
                using (SqlConnection conn = cBd.Connect_fct())
                {
                    string sqlDelete = "DELETE FROM Table_Produit WHERE Id = @Id";
                    int Id = int.Parse(DataGridHelper.GetValueFromDataGridView(dataGridView3, "Id"));

                    SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("supprission  avec succès");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                ConnectionBDD.Diconnect_fct();
            }
        }
        private void button104_Click(object sender, EventArgs e)
        {
            update();
        }
        private void button106_Click(object sender, EventArgs e)
        {
            search();
        }
        private void button107_Click_1(object sender, EventArgs e)
        { 
            LoadData();
            save();
            this.Close();
        }
        void LoadData()
        {
            try
            {
                ConnectionBDD cBd = new ConnectionBDD();
                cBd.Diconnect_fct();
                using (SqlConnection conn = cBd.Connect_fct())
                {
                    string query = "SELECT * FROM Table_Produit";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dataGridView3.DataSource = dt;
                    dataGridView3.RowHeadersVisible = false;
                    dataGridView3.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                ConnectionBDD.Diconnect_fct();
            }
        }
        void save()
        {
            ConnectionBDD cBd = new ConnectionBDD();
            cBd.Diconnect_fct();
            string sqltab = "INSERT into Table_Produit (Catégorie,Produit,Référence, Libellé,Code,Date,Qte_en_stock,Prix_unitaire,Totale) values (@Catégorie,@Produit,@Référence,@Libellé,@Code,@Date,@Qte_en_stock,@Prix_unitaire,@Totale) ";
            SqlCommand cmd = new SqlCommand(sqltab);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cBd.Connect_fct();

            //cmd.Parameters.AddWithValue("@Id", textBox11.Text);
            cmd.Parameters.AddWithValue("@Catégorie", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Produit", textBox111.Text);
            cmd.Parameters.AddWithValue("@Référence", textBox222.Text);
            cmd.Parameters.AddWithValue("@Libellé", textBox333.Text);
            cmd.Parameters.AddWithValue("@Code", textBox4.Text);
            cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@Qte_en_stock", textBox5.Text);
            cmd.Parameters.AddWithValue("@Prix_unitaire", textBox6.Text);
            //cmd.Parameters.AddWithValue("@Totale", textBox5 * textBox7.Text);
            try
            {
                decimal Prix_unitaire = Convert.ToDecimal(textBox5.Text);
                int Qte_en_stock = Convert.ToInt32(textBox6.Text);
                decimal totale = Prix_unitaire * Qte_en_stock;
                cmd.Parameters.AddWithValue("@Totale", totale);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                MessageBox.Show("Enregistré avec succès");
                LoadData();

                textBox111.Clear();
                textBox222.Clear();
                textBox333.Clear();
                textBox4.Clear();
                comboBox2.Text = "";
                comboBox1.Text = "";
                //dateTimePicker1.Text = dateTimePicker1.Text;
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                
                cBd.connx.Close();
            }
        }
        void search()
        {
            ConnectionBDD cBd = new ConnectionBDD();
            cBd.Diconnect_fct();
            string sqltab = "SELECT Produit, Qte_en_stock, Prix_unitaire,Totale FROM Table_Produit WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(sqltab);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cBd.Connect_fct();
            cmd.Parameters.AddWithValue("@Id", textBox11.Text);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox111.Text = reader["Produit"].ToString();
                    textBox5.Text = reader["Qte_en_stock"].ToString();
                    textBox6.Text = reader["Prix_unitaire"].ToString();
                    textBox7.Text = reader["Totale"].ToString();
                }
                else
                {
                    MessageBox.Show("Produit non trouvé");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                ConnectionBDD.Diconnect_fct();
            }
        }

        // Méthode pour modifier un produit
        void update()
        {
            ConnectionBDD cBd = new ConnectionBDD();
            cBd.Diconnect_fct();

            string sqltab = "UPDATE Table_Produit SET Produit = @Produit, Qte_en_stock = @Qte_en_stock, Prix_unitaire = @Prix_unitaire,Totale=@Totale WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(sqltab);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cBd.Connect_fct();
            cmd.Parameters.AddWithValue("@Id", textBox11.Text);
            cmd.Parameters.AddWithValue("@Produit", textBox111.Text);
            cmd.Parameters.AddWithValue("@Qte_en_stock", textBox5.Text);
            cmd.Parameters.AddWithValue("@Prix_unitaire", textBox6.Text);
            cmd.Parameters.AddWithValue("@Totale", textBox7.Text);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Produit mis à jour avec succès");
                }
                else
                {
                    MessageBox.Show("Aucun produit trouvé avec cet ID");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                ConnectionBDD.Diconnect_fct();
            }
        }
        void clearDataGridView()
        {
            if (dataGridView3.DataSource != null)
            {
                dataGridView3.DataSource = null;
            }
            else
            {
                dataGridView3.Rows.Clear();
            }
        }
        void clearDatabase()
        {
            ConnectionBDD cBd = new ConnectionBDD();
            cBd.Diconnect_fct();

            string sqltab = "DELETE FROM Table_Produit";
            SqlCommand cmd = new SqlCommand(sqltab);

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cBd.Connect_fct();

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tous les enregistrements ont été supprimés de la base de données");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                ConnectionBDD.Diconnect_fct();
            }
        }


        string[] arrayBatna = { "Aïn Djasser", "Aïn Touta", "Arris", "Barika", "Batna", "Bouzina", "Chemora", "Djezzar", "El Madher", "Ichmoul", "Menaa", "Merouana", "N'Gaous", "Ouled Si Slimane", "Ras El Aioun", "Seggana", "Seriana", "Tazoult", "Teniet El Abed", "Timgad", "T'kout" };

        string[] arraySétif = {
    "Aïn Abessa", "Aïn Arnat", "Aïn Azel", "Aïn El Kebira",
    "Aïn Legraj", "Aïn Oulmène", "Aïn Roua", "Aïn Sebt",
    "Aïn Smara", "Aïn Tadjel", "Azzaba", "Babor",
    "Beidha Bordj", "Beidha Mokhtar", "Béni Ourtilane",
    "Beni Chebana", "Beni Aziz", "Beni Hocine",
    "Bir El Arch", "Bir Haddada", "Bir Lahmar",
    "Bir Mezoui", "Bir Djebah", "Bouandas", "Bougaa",
    "Bousselam", "Boutaleb", "Cedar", "Djemila",
    "Draa Kebila", "El Eulma", "El Ouricia",
    "Foum Toub", "Guenzet", "Guidjel", "Harbil",
    "Hamma", "Hammam Essokhna", "Hamma Laarbi",
    "Hidoussa", "Ksar El Abtal", "Ksar Sbahi",
    "Laaroussa", "Lahlaf", "Maoklane", "Mazer",
    "Mezloug", "Oued El Abtal", "Oued El Barad",
    "Oued El Haddadj", "Ouled Addi Guebala",
    "Ouled Abed", "Ouled Abbes", "Ouled Adouane",
    "Ouled Aissa", "Ouled Ali", "Ouled Boumenna",
    "Ouled Boumahdi", "Ouled Brahim", "Ouled Derradj",
    "Ouled Djaber", "Ouled Djellal", "Ouled Fadhel",
    "Ouled Feradj", "Ouled Gacem", "Ouled Hadj Khaled",
    "Ouled Harkat", "Ouled Khellouf", "Ouled Lachkar",
    "Ouled Madhi", "Ouled Mimoun", "Ouled Nasrallah",
    "Ouled Sabor", "Ouled Sassi", "Ouled Sidi Brahim",
    "Ouled Si Tahar", "Ouled Tebben", "Ouled Tlidjene",
    "Ouled Yahia Khedrouche", "Ouled Youb", "Ouled Zouai",
    "Ouled Zouaoui", "Rasfa", "Rehamna", "Rouisset",
    "Salah Bey", "Serdj El Ghoul", "Sétif",
    "Sidi Aissa", "Sidi Abderahmane", "Tachouda",
    "Talaifacene", "Talba", "Taya", "Tella",
    "Tibane", "Tizi N'Bechar", "Zerrouk"
};
        string[] arrayConstantine = {
    "Aïn Abid", "Aïn Bouziane", "Aïn El Bey",
    "Aïn Kerma", "Aïn Smara", "Aïn Touta",
    "Beni Hamiden", "Beni M'hamed", "Beni M'hidi",
    "Beni Milleuk", "Beni Ouartilane", "Beni Oulid",
    "Bir Bouhouche", "Bir El Arch", "Bir El Hammam",
    "Bir El Mokadem", "Bouzina", "Chahna",
    "Constantine", "Djemila", "El Haria",
    "El Khroub", "El M'Ghair", "El Meridj",
    "El Milia", "Fenaïa Il Maten", "Guelta Zerga",
    "Hamma Bouziane", "Ibn Ziad", "Kahoua",
    "Khroub", "Ksar El Abtal", "Ksar El Boukhari",
    "Messaoud Boudjeriou", "Oued El Abtal",
    "Ouled Rahmoun", "Ouled Sidi Mihoub",
    "Ouled Slimane", "Ouled Soltane", "Ouled Tebben",
    "Oum Laadham", "Ras El Aïn", "Remila",
    "Sellaoua Announa", "Zighoud Youcef"
};
        string[] arrayAlger = {
    "Aïn Bénian", "Aïn Taya", "Baba Hassen",
    "Bab El Oued", "Bab Ezzouar", "Baraki",
    "Béni Messous", "Birkhadem", "Bir Mourad Raïs",
    "Birtouta", "El Harrach", "El Madania",
    "El Magharia", "Hussein Dey", "Khraïcia",
    "Kouba", "Mahelma", "Mohammadia", "Oued Koriche",
    "Ouled Chebel", "Ouled Fayet", "Raïs Hamidou",
    "Rouïba", "Saoula", "Sidi M'Hamed",
    "Souidania", "Staoueli", "Tessala El Merdja",
    "Zéralda"
};
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void btnColabsProd_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                //panel3.Width = 100;
                //panel3.Height = 692;
                panel3.Visible = false;
            }
            else
            {
                //panel3.Width = 209;
                //panel3.Height = 692;
                panel3.Visible = true;
            }
        }

        private void btnColabsDist_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == true)
            {
                //panel7.Width = 100;
                //panel7.Height = 692;
                panel7.Visible = false;
            }
            else
            {
                //panel7.Width = 209;
                //panel7.Height = 692;
                panel7.Visible = true;
            }
        }
        private void btnColabs_Click(object sender, EventArgs e)
        {
            if (NaveBarre.Width == 209)
            {
                NaveBarre.Width = 100;
                NaveBarre.Height = 678;
                userHeaderNavbar.Visible = false;
            }
            else
            {
                NaveBarre.Width = 209;
                NaveBarre.Height = 678;
                userHeaderNavbar.Visible = true;
            }
        }

        /*private void btnColabsAS_Click(object sender, EventArgs e)
        {
            
            if (NaveBarreAS.Width == 211)
            {
                NaveBarreAS.Width = 100;
                NaveBarreAS.Height = 663;
                userHeaderNB.Visible = false;
            }
            else
            {
                NaveBarreAS.Width = 211;
                NaveBarreAS.Height = 663;
                userHeaderNB.Visible = true;
            }
        }*/

        private void Planification_Click(object sender, EventArgs e)
        {
            OpenFile();
            /*OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files |*.*| Excel Files |*.xlsx";
          
            if (op.ShowDialog()== DialogResult.OK)
            {
                path = op.FileName;
                dataGridViewexcelProduction.TabIndex = 0;
            }*/
        }
        public void OpenFile()
        {
          //  Excel excel_open()= new excel_open(@"Localhost\\Documents\\gestion logistique\\planification.xlsx\", 1);
        }
        private void button33_Click(object sender, EventArgs e)
        {
            OpenFileDialog pcc = new OpenFileDialog();
            if (pcc.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(pcc.FileName);
            }
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string wilaya = comboBox3.Text;
            comboBox4.Items.Clear();
            comboBox4.Text = "";
            switch (wilaya)
            {
                case "Batna":
                    foreach (string daira in arrayBatna)
                    {
                        comboBox4.Items.Add(daira);
                    }
                    break;
                case "Constantine ":
                    foreach (string daira in arrayConstantine)
                    {
                        comboBox4.Items.Add(daira);
                    }
                    break;
                case "Sétif":
                    foreach (string daira in arraySétif)
                    {
                        comboBox4.Items.Add(daira);
                    }
                    break;
                case "Alger":
                    foreach (string daira in arrayAlger)
                    {
                        comboBox4.Items.Add(daira);
                    }
                    break;
                default:
                    comboBox4.Items.Add("Erreur");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog video = new OpenFileDialog() { Multiselect= false, Filter= "MP4 File |*.MP4| All File|*.*"};
            if (video.ShowDialog() == DialogResult.OK) { 
                path = video.FileName;
                pos = video.SafeFileName;
                lectureV.URL = path;
                this.Text = "" + pos;
            }
        }
        


    }
    
}
    
   


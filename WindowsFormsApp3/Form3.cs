using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da = new SqlDataAdapter("select oyuncu_adi from oyuncu", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "oyuncu");
            //comboBox1.DataSource = ds.Tables["oyuncu"];
            //comboBox1.DisplayMember = "oyuncu_adi";
            comboBox2.DataSource = ds.Tables["oyuncu"];
            comboBox2.DisplayMember = "oyuncu_adi";
            con.Close();

            /* con.Open();
               chart2.Series.Clear();
               foreach (DataRow row in ds.Tables["oyuncu"].Rows)
               {
                   string oyuncuismi = row["oyuncu_adi"].ToString();
                   chart2.Series.Add(oyuncuismi);
                   chart2.Series[oyuncuismi].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
               }
               con.Close(); */
        }

        private void Form3_Load(object sender, EventArgs e)
        {
 

            chart2.ChartAreas[0].AxisY.Minimum = 0;  
            chart2.ChartAreas[0].AxisY.Maximum = 20;
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // karsilastir();

        }
       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // karsilastir();

            if (chart2.Series.Count > 0)
            {
                chart2.Series.RemoveAt(0);
            }

            string selectedPlayer = comboBox2.Text;

            if (!string.IsNullOrEmpty(selectedPlayer))
            {

                chart2.Series.Add(selectedPlayer);
                chart2.Series[selectedPlayer].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                string query = "select * from oyuncu where oyuncu_adi = @oyuncu_adi";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@oyuncu_adi", selectedPlayer);

                con.Open();
                SqlDataReader r = com.ExecuteReader();

                if (r.Read())
                {
                    int gol = Convert.ToInt32(r["oyuncu_gol"]);
                    int mac = Convert.ToInt32(r["oyuncu_mac_sayi"]);
                    //int müc;
                    /*if (!Convert.IsDBNull(r["oyuncu_mucadele_kazanilan"]))
                    {
                        müc = Convert.ToInt32(r["oyuncu_mucadele_kazanilan"]);
                    }
                    else
                    {
                        müc = 0;
                    }*/
                    int rating;
                    if (!Convert.IsDBNull(r["oyuncu_mucadele_kazanilan"]))
                    {
                        rating = Convert.ToInt32(r["oyuncu_rating"]);
                    }
                    else
                    {
                        rating = 100;
                    }
                    int asist = Convert.ToInt32(r["oyuncu_asist"]);
                    int sari = Convert.ToInt32(r["oyuncu_sari"]);
                    int kirmizi = Convert.ToInt32(r["oyuncu_kirmizi"]);

                    chart2.Series[selectedPlayer].Points.AddXY("Rating x100", rating/100);
                    chart2.Series[selectedPlayer].Points.AddXY("Maç Sayısı", mac);
                    chart2.Series[selectedPlayer].Points.AddXY("Gol", gol);
                    chart2.Series[selectedPlayer].Points.AddXY("Asist", asist);
                    //chart2.Series[selectedPlayer].Points.AddXY("Kazanılan Mücadele", müc);
                    chart2.Series[selectedPlayer].Points.AddXY("Sarı Kart", sari);
                    chart2.Series[selectedPlayer].Points.AddXY("Kırmızı Kart", kirmizi);
                }

                r.Close();
                con.Close();
            }
        }

        private void karsilastir()
        {
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //string secilioyuncu = comboBox1.Text;
            string secilioyuncu2 = comboBox2.Text;
            if (!string.IsNullOrEmpty(secilioyuncu2))
            { 
                SqlCommand com = new SqlCommand("select * from oyuncu where oyuncu_adi in (@secilioyuncu, @secilioyuncu2)", con);
                //com.Parameters.AddWithValue("@secilioyuncu", secilioyuncu);
                com.Parameters.AddWithValue("@secilioyuncu2", secilioyuncu2);

                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    string oyuncuismi = r["oyuncu_adi"].ToString();
                    int gol = Convert.ToInt32(r["oyuncu_gol"]);
                    int asist = Convert.ToInt32(r["oyuncu_asist"]);
                    int sari = Convert.ToInt32(r["oyuncu_sari"]);
                    int kirmizi = Convert.ToInt32(r["oyuncu_kirmizi"]);

                    chart2.Series[oyuncuismi].Points.Clear();
                    chart2.Series[oyuncuismi].Points.AddXY("Gol", gol);
                    chart2.Series[oyuncuismi].Points.AddXY("Asist", asist);
                    chart2.Series[oyuncuismi].Points.AddXY("Sarı kart", sari);
                    chart2.Series[oyuncuismi].Points.AddXY("Kırmızı kart", kirmizi);
                }
                r.Close();
                con.Close();
            }
        }

    }
}


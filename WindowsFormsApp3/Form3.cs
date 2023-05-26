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
            comboBox2.DataSource = ds.Tables["oyuncu"];
            comboBox2.DisplayMember = "oyuncu_adi";
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            chart2.ChartAreas[0].AxisY.Maximum = 20;
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


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
                    int gol;
                    if (!Convert.IsDBNull(r["oyuncu_gol"]))
                    {
                        gol = Convert.ToInt32(r["oyuncu_gol"]);
                    }
                    else
                    {
                        gol = 0;
                    }
                    int mac;
                    if (!Convert.IsDBNull(r["oyuncu_mac_sayi"]))
                    {
                        mac = Convert.ToInt32(r["oyuncu_mac_sayi"]);
                    }
                    else
                    {
                        mac = 0;
                    }
                    int rating;
                    if (!Convert.IsDBNull(r["oyuncu_rating"]))
                    {
                        rating = Convert.ToInt32(r["oyuncu_rating"]);
                    }
                    else
                    {
                        rating = 0;
                    }
                    int asist;
                    if (!Convert.IsDBNull(r["oyuncu_asist"]))
                    {
                        asist = Convert.ToInt32(r["oyuncu_asist"]);
                    }
                    else
                    {
                        asist = 0;
                    }
                    int sari;
                    if (!Convert.IsDBNull(r["oyuncu_sari"]))
                    {
                        sari = Convert.ToInt32(r["oyuncu_sari"]);
                    }
                    else
                    {
                        sari = 0;
                    }
                    int kirmizi;
                    if (!Convert.IsDBNull(r["oyuncu_kirmizi"]))
                    {
                        kirmizi = Convert.ToInt32(r["oyuncu_kirmizi"]);
                    }
                    else
                    {
                        kirmizi = 0;
                    }

                    chart2.Series[selectedPlayer].Points.AddXY("Rating", rating/100);
                    chart2.Series[selectedPlayer].Points.AddXY("Maç Sayısı", mac);
                    chart2.Series[selectedPlayer].Points.AddXY("Gol", gol);
                    chart2.Series[selectedPlayer].Points.AddXY("Asist", asist);
                    chart2.Series[selectedPlayer].Points.AddXY("Sarı Kart", sari);
                    chart2.Series[selectedPlayer].Points.AddXY("Kırmızı Kart", kirmizi);
                }

                r.Close();
                con.Close();
            }

            if (chart1.Series.Count > 0)
            {
                chart1.Series.RemoveAt(0);
            }

            if (!string.IsNullOrEmpty(selectedPlayer))
            {

                chart1.Series.Add(selectedPlayer);
                chart1.Series[selectedPlayer].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                string query = "select * from oyuncu where oyuncu_adi = @oyuncu_adi";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@oyuncu_adi", selectedPlayer);

                con.Open();
                SqlDataReader r = com.ExecuteReader();

                if (r.Read())
                {
                    int pas;
                    if (!Convert.IsDBNull(r["oyuncu_pas"]))
                    {
                        pas = Convert.ToInt32(r["oyuncu_pas"]);
                    }
                    else
                    {
                        pas = 0;
                    }
                    int pas_is;
                    if (!Convert.IsDBNull(r["oyuncu_pas_isabetli"]))
                    {
                        pas_is = Convert.ToInt32(r["oyuncu_pas_isabetli"]);
                    }
                    else
                    {
                        pas_is = 0;
                    }
                    
                    chart1.Series[selectedPlayer].Points.AddXY("Pas", pas);
                    chart1.Series[selectedPlayer].Points.AddXY("İsabetli Pas", pas_is);
                }

                r.Close();
                con.Close();
            }

            if (chart3.Series.Count > 0)
            {
                chart3.Series.RemoveAt(0);
            }

            if (!string.IsNullOrEmpty(selectedPlayer))
            {

                chart3.Series.Add(selectedPlayer);
                chart3.Series[selectedPlayer].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                string query = "select * from oyuncu where oyuncu_adi = @oyuncu_adi";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@oyuncu_adi", selectedPlayer);

                con.Open();
                SqlDataReader r = com.ExecuteReader();

                if (r.Read())
                {
                    int mudahale;
                    if (!Convert.IsDBNull(r["oyuncu_mudahale"]))
                    {
                        mudahale = Convert.ToInt32(r["oyuncu_mudahale"]);
                    }
                    else
                    {
                        mudahale = 0;
                    }
                    int mucadele;
                    if (!Convert.IsDBNull(r["oyuncu_mucadele"]))
                    {
                        mucadele = Convert.ToInt32(r["oyuncu_mucadele"]);
                    }
                    else
                    {
                        mucadele = 0;
                    }
                    int mucadele_kaz;
                    if (!Convert.IsDBNull(r["oyuncu_mucadele_kazanilan"]))
                    {
                        mucadele_kaz = Convert.ToInt32(r["oyuncu_mucadele_kazanilan"]);
                    }
                    else
                    {
                        mucadele_kaz = 0;
                    }
                    int paskesme;
                    if (!Convert.IsDBNull(r["oyuncu_pas_kesme"]))
                    {
                        paskesme = Convert.ToInt32(r["oyuncu_pas_kesme"]);
                    }
                    else
                    {
                        paskesme = 0;
                    }

                    chart3.Series[selectedPlayer].Points.AddXY("Müdehale", mudahale);
                    chart3.Series[selectedPlayer].Points.AddXY("Mücadele", mucadele);
                    chart3.Series[selectedPlayer].Points.AddXY("Kazanılan Mücadele", mucadele_kaz);
                    chart3.Series[selectedPlayer].Points.AddXY("Pas Kesme", paskesme);
                }

                r.Close();
                con.Close();
            }
            
            if (chart4.Series.Count > 0)
            {
                chart4.Series.RemoveAt(0);
            }

            if (!string.IsNullOrEmpty(selectedPlayer))
            {

                chart4.Series.Add(selectedPlayer);
                chart4.Series[selectedPlayer].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                string query = "select * from oyuncu where oyuncu_adi = @oyuncu_adi";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@oyuncu_adi", selectedPlayer);

                con.Open();
                SqlDataReader r = com.ExecuteReader();

                if (r.Read())
                {
                    int kurtaris;
                    if (!Convert.IsDBNull(r["oyuncu_kurtaris"]))
                    {
                        kurtaris = Convert.ToInt32(r["oyuncu_kurtaris"]);
                    }
                    else
                    {
                        kurtaris = 0;
                    }
                    int cskurtaris;
                    if (!Convert.IsDBNull(r["oyuncu_cezasahasi_kurtaris"]))
                    {
                        cskurtaris = Convert.ToInt32(r["oyuncu_cezasahasi_kurtaris"]);
                    }
                    else
                    {
                        cskurtaris = 0;
                    }
                    int yenengol;
                    if (!Convert.IsDBNull(r["oyuncu_yenen_gol"]))
                    {
                        yenengol = Convert.ToInt32(r["oyuncu_yenen_gol"]);
                    }
                    else
                    {
                        yenengol = 0;
                    }

                    chart4.Series[selectedPlayer].Points.AddXY("Kurtarış", kurtaris);
                    chart4.Series[selectedPlayer].Points.AddXY("Ceza Sahası Kurtarış", cskurtaris);
                    chart4.Series[selectedPlayer].Points.AddXY("Yenen Gol", yenengol);

                }

                r.Close();
                con.Close();
            }
            if (chart5.Series.Count > 0)
            {
                chart5.Series.RemoveAt(0);
            }

            if (!string.IsNullOrEmpty(selectedPlayer))
            {

                chart5.Series.Add(selectedPlayer);
                chart5.Series[selectedPlayer].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                string query = "select * from oyuncu where oyuncu_adi = @oyuncu_adi";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@oyuncu_adi", selectedPlayer);

                con.Open();
                SqlDataReader r = com.ExecuteReader();

                if (r.Read())
                {
                    int dribgirisim;
                    if (!Convert.IsDBNull(r["oyuncu_dribbling_girisimi"]))
                    {
                        dribgirisim = Convert.ToInt32(r["oyuncu_dribbling_girisimi"]);
                    }
                    else
                    {
                        dribgirisim = 0;
                    }
                    int dribbasarili;
                    if (!Convert.IsDBNull(r["oyuncu_dribbling_basarili"]))
                    {
                        dribbasarili = Convert.ToInt32(r["oyuncu_dribbling_basarili"]);
                    }
                    else
                    {
                        dribbasarili = 0;
                    }

                    chart5.Series[selectedPlayer].Points.AddXY("Dribbling Girişimi", dribgirisim);
                    chart5.Series[selectedPlayer].Points.AddXY("Başarılı Dribbling", dribbasarili);
                }

                r.Close();
                con.Close();
            }

        }

       
    }
}


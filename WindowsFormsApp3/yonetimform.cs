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
using Zuby.ADGV;

namespace WindowsFormsApp3
{
    public partial class yonetimform : Form
    {
        int k_id = k_session.Instance.k_id;
        int t_id = k_session.Instance.k_id;
        public yonetimform()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand("select oyuncu_id, oyuncu_adi from oyuncu where takim_id = @t_id", con);
            cmd.Parameters.AddWithValue("@t_id", t_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            comboBox2.ValueMember = "oyuncu_id";
            comboBox2.DisplayMember = "oyuncu_adi";
            comboBox2.DataSource = dt;
            con.Close();
            
            SqlCommand cmd2 = new SqlCommand("select ulke_id, ulke_ad from ulke", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            con.Open();
            da2.Fill(dt2);
            comboBox1.ValueMember = "ulke_id";
            comboBox1.DisplayMember = "ulke_ad";
            comboBox1.DataSource = dt2;
            con.Close();

            SqlCommand cmd3 = new SqlCommand("select ayak_id, ayak from ayak", con);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            con.Open();
            da3.Fill(dt3);
            comboBox3.ValueMember = "ayak_id";
            comboBox3.DisplayMember = "ayak";
            comboBox3.DataSource = dt3;
            con.Close();




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False");
            SqlCommand cmd2 = new SqlCommand("select o.oyuncu_adi, o.oyuncu_yas,m.mevki_adi,m.mevki_id, t.takim_ad,t.takim_id,oyuncu_mac_sayi," +
                "o.oyuncu_gol, o.oyuncu_asist, o.oyuncu_sari, o.oyuncu_kirmizi, o.oyuncu_sakatlik, o.oyuncu_oyundan_cikis," +
                " o.oyuncu_yedek,o.oyuncu_dogumgunu, o.oyuncu_kaptan, o.oyuncu_sut, o.oyuncu_yenen_gol, o.oyuncu_yaptıgı_faul," +
                " o.oyuncu_mudahale, o.oyuncu_blok, o.oyuncu_orta, o.oyuncu_pas_kesme, o.oyuncu_uzaklastirma, o.oyuncu_top_kaybi," +
                " o.oyuncu_kurtaris,o.oyuncu_cezasahasi_kurtaris, o.oyuncu_mucadele, o.oyuncu_mucadele_kazanilan," +
                " o.oyuncu_dribbling_girisimi,o.oyuncu_dribbling_basarili, o.oyuncu_penalti_yaptigi," +
                " o.oyuncu_penalti_kazanilan, o.oyuncu_penalti_gol,o.oyuncu_penalti_kacan," +
                " o.oyuncu_pas, o.oyuncu_pas_isabetli, o.oyuncu_pas_kilit, o.oyuncu_rating, o.oyuncu_kilo, o.oyuncu_boy, o.oyuncu_kosu," +
                " o.oyuncu_id,a.ayak,a.ayak_id , u.ulke_ad,u.ulke_id" +
                "  from oyuncu o left join ayak a on a.ayak_id=o.ayak_id left join  mevki m on o.mevki_id= m.mevki_id left join takim t on t.takim_id=o.takim_id left join ulke u on u.ulke_id=o.ulke_id where oyuncu_id = @oyuncu_id", con);
            cmd2.Parameters.AddWithValue("@oyuncu_id", comboBox2.SelectedValue.ToString());
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            con.Open();
            da2.Fill(dt2);
            comboBox4.ValueMember = "takim_id";
            comboBox4.DisplayMember = "takim_ad";
            comboBox4.DataSource = dt2;
            comboBox5.ValueMember = "mevki_id";
            comboBox5.DisplayMember = "mevki_adi";
            comboBox5.DataSource = dt2;
            con.Close();
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select o.oyuncu_adi, o.oyuncu_yas,m.mevki_adi,m.mevki_id, t.takim_ad,t.takim_id,oyuncu_mac_sayi," +
              "o.oyuncu_gol, o.oyuncu_asist, o.oyuncu_sari, o.oyuncu_kirmizi, o.oyuncu_sakatlik, o.oyuncu_oyundan_cikis," +
              " o.oyuncu_yedek,o.oyuncu_dogumgunu, o.oyuncu_kaptan, o.oyuncu_sut, o.oyuncu_yenen_gol, o.oyuncu_yaptıgı_faul," +
              " o.oyuncu_mudahale, o.oyuncu_blok, o.oyuncu_orta, o.oyuncu_pas_kesme, o.oyuncu_uzaklastirma, o.oyuncu_top_kaybi," +
              " o.oyuncu_kurtaris,o.oyuncu_cezasahasi_kurtaris, o.oyuncu_mucadele, o.oyuncu_mucadele_kazanilan," +
              " o.oyuncu_dribbling_girisimi,o.oyuncu_dribbling_basarili, o.oyuncu_penalti_yaptigi," +
              " o.oyuncu_penalti_kazanilan, o.oyuncu_penalti_gol,o.oyuncu_penalti_kacan," +
              " o.oyuncu_pas, o.oyuncu_pas_isabetli, o.oyuncu_pas_kilit, o.oyuncu_rating, o.oyuncu_kilo, o.oyuncu_boy, o.oyuncu_kosu," +
              " o.oyuncu_id,a.ayak,a.ayak_id , u.ulke_ad,u.ulke_id" +
              "  from oyuncu o left join ayak a on a.ayak_id=o.ayak_id left join  mevki m on o.mevki_id= m.mevki_id left join takim t on t.takim_id=o.takim_id left join ulke u on u.ulke_id=o.ulke_id where oyuncu_id = @oyuncu_id", con);
            cmd3.Parameters.AddWithValue("@oyuncu_id", comboBox2.SelectedValue.ToString());
            SqlDataReader r = cmd3.ExecuteReader();
            while (r.Read())
            {
                
                yastext.Text = r["oyuncu_yas"].ToString();
                dogumgunutext.Text = r["oyuncu_dogumgunu"].ToString();
                yastext.Text = r["oyuncu_yas"].ToString();
                boytext.Text = r["oyuncu_boy"].ToString();
                kilotext.Text = r["oyuncu_kilo"].ToString();
                macsayısıtext.Text = r["oyuncu_mac_sayi"].ToString();
                goltext.Text = r["oyuncu_gol"].ToString();
                asisttext.Text = r["oyuncu_asist"].ToString();
                sarikarttext.Text = r["oyuncu_sari"].ToString();
                kirmizikarttext.Text = r["oyuncu_kirmizi"].ToString();
                sakatliktext.Text = r["oyuncu_sakatlik"].ToString();
                oyuncıkıstext.Text = r["oyuncu_oyundan_cikis"].ToString();
                yedekmaclartext.Text = r["oyuncu_yedek"].ToString();
                tkaptanlıgıtext.Text = r["oyuncu_kaptan"].ToString();
                suttext.Text = r["oyuncu_sut"].ToString();
                ortatext.Text = r["oyuncu_orta"].ToString();
                faultext.Text = r["oyuncu_yaptıgı_faul"].ToString();
                mudahaletext.Text = r["oyuncu_mudahale"].ToString();
                bloktext.Text = r["oyuncu_blok"].ToString();
                kesilenpastext.Text = r["oyuncu_pas_kesme"].ToString();
                uzeklastırmatext.Text = r["oyuncu_uzaklastirma"].ToString();
                topkaybıtext.Text = r["oyuncu_top_kaybi"].ToString();
                kurtaristext.Text = r["oyuncu_kurtaris"].ToString();
                cezasahakurtaristext.Text = r["oyuncu_cezasahasi_kurtaris"].ToString();
                yenengoltext.Text = r["oyuncu_yenen_gol"].ToString();
                ikilimuctext.Text = r["oyuncu_mucadele"].ToString();
                kazanmuctext.Text = r["oyuncu_mucadele_kazanilan"].ToString();
                yappenaltitext.Text = r["oyuncu_yas"].ToString();
                dribblingtext.Text = r["oyuncu_dribbling_girisimi"].ToString();
                basdribblingtext.Text = r["oyuncu_dribbling_basarili"].ToString();
                alinanpenaltitext.Text = r["oyuncu_penalti_yaptigi"].ToString();
                penaltigolutext.Text = r["oyuncu_penalti_gol"].ToString();
                kacanpenaltıtext.Text = r["oyuncu_penalti_kacan"].ToString();
                pastext.Text = r["oyuncu_pas"].ToString();
                isabetlipastext.Text = r["oyuncu_pas_isabetli"].ToString();
                kilitpastext.Text = r["oyuncu_pas_kilit"].ToString();
                kosutext.Text = r["oyuncu_kosu"].ToString();
                ratingtext.Text = r["oyuncu_rating"].ToString();
            }
            con.Close();
            SqlCommand cmd8 = new SqlCommand("select ulke_ad, ayak from oyuncu o left join ayak a on a.ayak_id=o.ayak_id left join ulke u on u.ulke_id=o.ulke_id where oyuncu_id = @oyuncu_id", con);
            cmd8.Parameters.AddWithValue("@oyuncu_id", comboBox2.SelectedValue);
            con.Open();

            SqlDataReader r8 = cmd8.ExecuteReader();
            
                if (r8.Read())
                {
                    if (!Convert.IsDBNull(r8["ulke_ad"]))
                    {
                        comboBox3.Text = r8["ayak"].ToString();

                        comboBox1.Text = r8["ulke_ad"].ToString();
                    }
                }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False");
            SqlCommand com = new SqlCommand("update oyuncu set oyuncu_boy = @boy , oyuncu_kilo = @kilo , ulke_id = @ulkeid , ayak_id = @ayakid where oyuncu_id = @oyuncuid", con);
            con.Open();
           string boy = boytext.Text;
           string kilo = kilotext.Text;

            com.Parameters.AddWithValue("@boy", boy);
            com.Parameters.AddWithValue("@kilo", kilo);
            com.Parameters.AddWithValue("@ayakid", comboBox3.SelectedValue.ToString());
            com.Parameters.AddWithValue("@ulkeid", comboBox1.SelectedValue.ToString());
            com.Parameters.AddWithValue("@oyuncuid", comboBox2.SelectedValue.ToString());


            com.ExecuteNonQuery();
            con.Close();
            label41.Text = "Başarı ile güncellendi..";
        }
    }
}

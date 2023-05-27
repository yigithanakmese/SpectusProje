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

namespace WindowsFormsApp3
{
    public partial class profilform : Form
    {
        int k_id = k_session.Instance.k_id;

        public profilform()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand($"select k.kullanici_id, k.kullanici_adi, k.sifre, k.kullanici_pp, g.giris_tipi, k.adi, k.soyadi," +
                $" k.email, t.takim_ad, k.tel_no, k.kulup_gorev from kullanici k left join giris_tipi g on k.giris_tipi_id = g.giris_tipi_id" +
                $" left join takim t on t.takim_id = k.takim_id where kullanici_id = @k_id", con);
            cmd.Parameters.AddWithValue("@k_id", k_id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string kullanciadi = dr["kullanici_adi"].ToString();
                string ad = dr["adi"].ToString();
                string soyad = dr["soyadi"].ToString();
                string email = dr["email"].ToString();
                string giristipi = dr["giris_tipi"].ToString();
                string tel;
                if (!Convert.IsDBNull(dr["tel_no"]))
                {
                    tel = dr["tel_no"].ToString();
                }
                else
                {
                    tel = "Kulüp yetkilisi Değilsiniz";
                }
                string takimadi;
                if (!Convert.IsDBNull(dr["takim_ad"]))
                {
                    takimadi = dr["takim_ad"].ToString();
                    if (takimadi == "takımyok")
                    {
                        label17.Text = "Kulüp yetkilisi Değilsiniz";
                    }

                }
                else
                {
                    label17.Text = "Kulüp yetkilisi Değilsiniz";
                }
                string gorev;
                if (!Convert.IsDBNull(dr["kulup_gorev"]))
                {
                    gorev = dr["kulup_gorev"].ToString();
                }
                else
                {
                    gorev = "Kulüp yetkilisi Değilsiniz";
                }
                label14.Text = kullanciadi;
                label13.Text = ad;
                label7.Text = soyad;
                label3.Text = email;
                label2.Text = giristipi;
                label16.Text = tel;
                label15.Text = gorev;


            }
            dr.Close();
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void profilform_Load(object sender, EventArgs e)
        {
           
        }
    }
}

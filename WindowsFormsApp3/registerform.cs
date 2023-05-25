using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class registerform : Form
    {
        public registerform()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False");
        private void registerform_Load(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;

            SqlCommand cmd = new SqlCommand("select * from giris_tipi where giris_tipi_id not like 1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            comboBox1.ValueMember = "giris_tipi_id";
            comboBox1.DisplayMember = "giris_tipi";
            comboBox1.DataSource = dt;
            con.Close();

            SqlCommand cmd2 = new SqlCommand("select * from takim where takim_id not like 21", con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            con.Open();
            da2.Fill(dt2);
            comboBox2.ValueMember = "takim_id";
            comboBox2.DisplayMember = "takim_ad";
            comboBox2.DataSource = dt2;
            con.Close();
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedValue.ToString() == "3")
            {
                comboBox2.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
            }

            else
            {   
                comboBox2.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string k_ismi = textBox1.Text;
            string sifre = textBox2.Text;
            string sifretekrar = textBox3.Text;
            string ad = textBox4.Text;
            string soyad = textBox5.Text;
            string email = textBox6.Text;
            string emailtekrar = textBox7.Text;

            if (string.IsNullOrEmpty(k_ismi))
            {
                label13.Text = "Kullanıcı adı boş olamaz.";

            }
            else
            {
                label13.Text = " ";
            }
            if (turkcekarakterkontrol(k_ismi))
            {
                label13.Text = "Kullanıcı adı Türkçe karakterler içeremez.";
            }
            else
            {
                label13.Text = " ";
            }
            if (k_ismi.Length > 16)
            {
               label13.Text = "Kullanıcı adı en fazla 16 karakter olabilir.";
            }
            else
            {
                label13.Text = " ";
            }
            if (string.IsNullOrEmpty(sifre))
            {
                label14.Text = "Şifre boş olamaz.";
            }
            else
            {
                label14.Text = " ";
            }
            if (string.IsNullOrEmpty(sifretekrar))
            {
                label15.Text = "Şifre tekrarı boş olamaz.";
            }
            else
            {
                label15.Text = " ";
            }
            if (string.IsNullOrEmpty(ad))
            {
                label16.Text = "Ad boş olamaz.";
            }
            else
            {
                label16.Text = " ";
            }
            if (string.IsNullOrEmpty(soyad))
            {
                label17.Text = "Soyad boş olamaz.";
            }
            else
            {
                label17.Text = " ";
            }
            if (string.IsNullOrEmpty(email))
            {
                label18.Text = "Email boş olamaz.";
            }
            else
            {
                label18.Text = " ";
            }
            if (string.IsNullOrEmpty(emailtekrar))
            {
                label19.Text = "Email tekrarı boş olamaz.";
            }
            else
            {
                label19.Text = " ";
            }
            if (sifre != sifretekrar)
            {
                label15.Text = "Şifre tekrarı aynı değil.";
            }
            else
            {
                label15.Text = " ";
            }
            if (email!=emailtekrar)
            {
                label19.Text = "Email tekrarı aynı değil.";
            }
            else
            {
                label19.Text = " ";
            }
            if (comboBox1.SelectedItem == null)
            {
                label20.Text = "Kullanıcı tipi seçmelisiniz.";
            }
            else
            {
                label20.Text = " ";
            }
            if ((string.IsNullOrEmpty(k_ismi)) || (turkcekarakterkontrol(k_ismi)) || (k_ismi.Length > 16) || (string.IsNullOrEmpty(sifre)) || (string.IsNullOrEmpty(sifretekrar)) || (string.IsNullOrEmpty(ad)) || (string.IsNullOrEmpty(soyad)) || (string.IsNullOrEmpty(email)) || (string.IsNullOrEmpty(emailtekrar)) || (sifre != sifretekrar) || (email != emailtekrar))
            {
                return;
            }
           
            SqlCommand com = new SqlCommand("insert into kullanici (giris_tipi_id, kullanici_adi, sifre, adi, soyadi, email, takim_id, tel_no, kulup_gorev) values (@girisid, @k_ad, @sifre, @ad, @soyad, @email, @kulupismi, @tel, @gorev)", con);
            con.Open();
            com.Parameters.AddWithValue("@k_ad", textBox1.Text);
            com.Parameters.AddWithValue("@sifre", textBox2.Text);
            com.Parameters.AddWithValue("@ad", textBox4.Text);
            com.Parameters.AddWithValue("@soyad", textBox5.Text);
            com.Parameters.AddWithValue("@email", textBox6.Text);
            com.Parameters.AddWithValue("@girisid", comboBox1.SelectedValue.ToString());
            if (comboBox2.Enabled == false)
            {
                com.Parameters.AddWithValue("@kulupismi", 21);
                com.Parameters.AddWithValue("@tel", "");
                com.Parameters.AddWithValue("@gorev", "");
            }
            else 
            {
                com.Parameters.AddWithValue("@kulupismi", comboBox2.SelectedValue.ToString());
                com.Parameters.AddWithValue("@tel", textBox9.Text);
                com.Parameters.AddWithValue("@gorev", textBox8.Text);
            }
            com.ExecuteNonQuery();
            con.Close();
            this.Hide();

        }
        private bool turkcekarakterkontrol(string text)
        {
            string turkcekarakterler = "çÇğĞıİöÖşŞüÜ";

            foreach (char c in text)
            {
                if (turkcekarakterler.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

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
    
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        
      

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            registerform registerform = new registerform();
            registerform.Show();
        }
         
        public void button1_Click(object sender, EventArgs e)
        {
            string kullanici = textBox1.Text;
            string sifre = textBox2.Text;
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "select * from kullanici where kullanici_adi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                k_session.Instance.k_id = dr.GetInt32(dr.GetOrdinal("kullanici_id"));
                k_session.Instance.t_id = dr.GetInt32(dr.GetOrdinal("takim_id"));
                Form1 Form1 = new Form1();
                Form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız veya şifreniz hatalı.");
            }
            con.Close();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

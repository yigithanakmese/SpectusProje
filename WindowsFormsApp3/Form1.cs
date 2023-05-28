using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {
        int k_id = k_session.Instance.k_id;

        public Form1()
        {
            InitializeComponent();
            
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da = new SqlDataAdapter("select oyuncu_adi, oyuncu_gol from oyuncu where oyuncu_gol >8 order by oyuncu_gol desc", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            SqlDataAdapter da2 = new SqlDataAdapter("select oyuncu_adi, oyuncu_asist from oyuncu where oyuncu_asist >4 order by oyuncu_asist desc", con);
            ds = new DataSet();
            con.Open();
            da2.Fill(ds);
            dataGridView2.DataSource= ds.Tables[0];
            con.Close();
            SqlDataAdapter da3 = new SqlDataAdapter("select oyuncu_adi, oyuncu_kurtaris from oyuncu where oyuncu_kurtaris >60 order by oyuncu_kurtaris desc", con);
            ds = new DataSet();
            con.Open();
            da3.Fill(ds);
            dataGridView3.DataSource= ds.Tables[0];
            con.Close();
        }
        private profilform profilform;
        
        private void label1_Click(object sender, EventArgs e)
        {
            if (profilform == null || profilform.IsDisposed)
            {
                profilform = new profilform();
                profilform.FormClosed += profilformkapanis;
                profilform.Show();
            }
            else
            {
                profilform.Focus();
            }
        }

        private void profilformkapanis(object sender, FormClosedEventArgs e)
        {
            profilform = null;
        }
        private Form activeForm = null;
        private void openminiform(Form miniform)
        {
           
                if (activeForm != null)
                    activeForm.Close();
                activeForm = miniform;
                miniform.TopLevel = false;
                miniform.FormBorderStyle = FormBorderStyle.None;
                miniform.Dock = DockStyle.Fill;
                panel3ana.Controls.Add(miniform);
                panel3ana.Tag = miniform;
                miniform.BringToFront();
                miniform.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {          
           openminiform(new Form2());            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openminiform(new Form3());
        }
        private void button6_Click(object sender, EventArgs e)
        {
            openminiform(new yonetimform());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
        }

        private void panel3ana_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openminiform(new Form5());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand($"select k.adi, k.soyadi from kullanici k where kullanici_id = @k_id", con);
            cmd.Parameters.AddWithValue("@k_id", k_id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            { 
            string ad = dr["adi"].ToString();
            string soyad = dr["soyadi"].ToString();
            label1.Text = ad + " " + soyad;
            }
            dr.Close();
            con.Close();
        }
        
        Form4 form4 = new Form4();
       
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            form4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openminiform(new notlatform());
        }

        
    }
}

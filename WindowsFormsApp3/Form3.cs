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
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "oyuncu_adi";
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            con.Close();

            SqlDataAdapter da2 = new SqlDataAdapter("select oyuncu_adi from oyuncu", con);
            DataTable dt2 = new DataTable();
            con.Open();
            da2.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "oyuncu_adi";
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            con.Close();


        }








        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}


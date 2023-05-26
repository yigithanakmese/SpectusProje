using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        int k_id = k_session.Instance.k_id;
        public Form2()
        {
            InitializeComponent();
            

            textBox5.TextChanged += textBox5_TextChanged;
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False");
            SqlDataAdapter da = new SqlDataAdapter("select o.oyuncu_adi, o.oyuncu_yas,m.mevki_adi, t.takim_ad,oyuncu_mac_sayi," +
                "o.oyuncu_gol, o.oyuncu_asist, o.oyuncu_sari, o.oyuncu_kirmizi, o.oyuncu_sakatlik, o.oyuncu_oyundan_cikis," +
                " o.oyuncu_yedek,o.oyuncu_dogumgunu, o.oyuncu_kaptan, o.oyuncu_sut, o.oyuncu_yenen_gol, o.oyuncu_yaptıgı_faul," +
                " o.oyuncu_mudahale, o.oyuncu_blok, o.oyuncu_orta, o.oyuncu_pas_kesme, o.oyuncu_uzaklastirma, o.oyuncu_top_kaybi," +
                " o.oyuncu_kurtaris,o.oyuncu_cezasahasi_kurtaris, o.oyuncu_mucadele, o.oyuncu_mucadele_kazanilan," +
                " o.oyuncu_dribbling_girisimi,o.oyuncu_dribbling_basarili, o.oyuncu_penalti_yaptigi," +
                " o.oyuncu_penalti_kazanilan, o.oyuncu_penalti_gol,o.oyuncu_penalti_kacan," +
                " o.oyuncu_pas, o.oyuncu_pas_isabetli, o.oyuncu_pas_kilit, o.oyuncu_rating, o.oyuncu_kilo, o.oyuncu_boy, o.oyuncu_kosu," +
                " o.oyuncu_id,a.ayak , u.ulke_ad" +
                "  from oyuncu o left join ayak a on a.ayak_id=o.ayak_id left join  mevki m on o.mevki_id= m.mevki_id left join takim t on t.takim_id=o.takim_id left join ulke u on u.ulke_id=o.ulke_id", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            advancedDataGridView1.DataSource = ds.Tables[0];
            con.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Form4 form4 = new Form4();

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand($"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'oyuncu' and COLUMN_NAME not in ('oyuncu_id','mevki_id','takim_id','ayak_id','ulke_id','oyuncu_resim')", con);
            SqlCommand cmd2 = new SqlCommand($"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'mevki' and COLUMN_NAME not like 'mevki_id'", con);
            SqlCommand cmd3 = new SqlCommand($"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'takim' and COLUMN_NAME not in ('takim_id','takim_logo')", con);
            SqlCommand cmd4 = new SqlCommand($"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'ayak' and COLUMN_NAME not like 'ayak_id'", con);
            SqlCommand cmd5 = new SqlCommand($"select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'ulke' and COLUMN_NAME not like 'ulke_id'", con);

            con.Open();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                string kolonismi = r["COLUMN_NAME"].ToString();
                comboBox1.Items.Add(kolonismi);
            }
            r.Close();
            con.Close();

            con.Open();
            SqlDataReader r2 = cmd2.ExecuteReader();
            while (r2.Read())
            {
                string kolonismi2 = r2["COLUMN_NAME"].ToString();
                comboBox1.Items.Add(kolonismi2);
            }
            r2.Close();
            con.Close();

            con.Open();
            SqlDataReader r3 = cmd3.ExecuteReader();
            while (r3.Read())
            {
                string kolonismi3 = r3["COLUMN_NAME"].ToString();
                comboBox1.Items.Add(kolonismi3);
            }
            r3.Close();
            con.Close();

            con.Open();
            SqlDataReader r4 = cmd4.ExecuteReader();
            while (r4.Read())
            {
                string kolonismi4 = r4["COLUMN_NAME"].ToString();
                comboBox1.Items.Add(kolonismi4);
            }
            r4.Close();
            con.Close();

            con.Open();
            SqlDataReader r5 = cmd5.ExecuteReader();
            while (r5.Read())
            {
                string kolonismi5 = r5["COLUMN_NAME"].ToString();
                comboBox1.Items.Add(kolonismi5);
            }
            r5.Close();
            con.Close();
        }



        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {


        }
        private void favoriteItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = advancedDataGridView1.CurrentRow;

            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand("insert into favoriler (kullanici_id, oyuncu_id) VALUES ('"+k_id+"', @oyuncu)", con);
            cmd.Parameters.AddWithValue("@oyuncu", selectedRow.Cells["oyuncu_id"].Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void advancedDataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void advancedDataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menuStrip = new ContextMenuStrip();

                ToolStripMenuItem favoriteItem = new ToolStripMenuItem();
                favoriteItem.Text = "Favorilere Ekle";
                favoriteItem.Click += new EventHandler(favoriteItem_Click);

                menuStrip.Items.Add(favoriteItem);

                advancedDataGridView1.ContextMenuStrip = menuStrip;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string secilikolon = comboBox1.SelectedItem.ToString();
            string aratext = textBox5.Text;

            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da2 = new SqlDataAdapter($"select o.oyuncu_adi, o.oyuncu_yas,m.mevki_adi, t.takim_ad,oyuncu_mac_sayi," +
                "o.oyuncu_gol, o.oyuncu_asist, o.oyuncu_sari, o.oyuncu_kirmizi, o.oyuncu_sakatlik, o.oyuncu_oyundan_cikis," +
                " o.oyuncu_yedek,o.oyuncu_dogumgunu, o.oyuncu_kaptan, o.oyuncu_sut, o.oyuncu_yenen_gol, o.oyuncu_yaptıgı_faul," +
                " o.oyuncu_mudahale, o.oyuncu_blok, o.oyuncu_orta, o.oyuncu_pas_kesme, o.oyuncu_uzaklastirma, o.oyuncu_top_kaybi," +
                " o.oyuncu_kurtaris,o.oyuncu_cezasahasi_kurtaris, o.oyuncu_mucadele, o.oyuncu_mucadele_kazanilan," +
                " o.oyuncu_dribbling_girisimi,o.oyuncu_dribbling_basarili, o.oyuncu_penalti_yaptigi," +
                " o.oyuncu_penalti_kazanilan, o.oyuncu_penalti_gol,o.oyuncu_penalti_kacan," +
                " o.oyuncu_pas, o.oyuncu_pas_isabetli, o.oyuncu_pas_kilit, o.oyuncu_rating," +
                " o.oyuncu_id,a.ayak , u.ulke_ad" +
                "  from oyuncu o left join ayak a on a.ayak_id=o.ayak_id left join  mevki m on o.mevki_id= m.mevki_id left join takim t on t.takim_id=o.takim_id left join ulke u on u.ulke_id=o.ulke_id" +
                $" where {secilikolon} like '%{aratext}%'", con);
            con.Open();
            DataTable dt = new DataTable();
            da2.Fill(dt);
            advancedDataGridView1.DataSource = dt;
            con.Close();
        }

        private void advancedDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (advancedDataGridView1.CurrentRow.Index != -1)
            {
                Form6 Form6 = new Form6();
                DataGridViewRow selectedRow = advancedDataGridView1.CurrentRow;
                string adi = selectedRow.Cells[0].Value.ToString();
                string yas = selectedRow.Cells[1].Value.ToString();
                string mevki = selectedRow.Cells[2].Value.ToString();
                string takim = selectedRow.Cells[3].Value.ToString();
                string mac = selectedRow.Cells[4].Value.ToString();
                string gol = selectedRow.Cells[5].Value.ToString();
                string asist = selectedRow.Cells[6].Value.ToString();
                string sari = selectedRow.Cells[7].Value.ToString();
                string kirmizi = selectedRow.Cells[8].Value.ToString();
                string sakatlik = selectedRow.Cells[9].Value.ToString();
                string oyundan_cik = selectedRow.Cells[10].Value.ToString();
                string yedek = selectedRow.Cells[11].Value.ToString();
                string dgun = selectedRow.Cells[12].Value.ToString();
                string kaptan = selectedRow.Cells[13].Value.ToString();
                string sut = selectedRow.Cells[14].Value.ToString();
                string yenengol = selectedRow.Cells[15].Value.ToString();
                string faul = selectedRow.Cells[16].Value.ToString();
                string mud = selectedRow.Cells[17].Value.ToString();
                string blok = selectedRow.Cells[18].Value.ToString();
                string orta = selectedRow.Cells[19].Value.ToString();
                string paskes = selectedRow.Cells[20].Value.ToString();
                string uzaklastirma = selectedRow.Cells[21].Value.ToString();
                string topkaybi = selectedRow.Cells[22].Value.ToString();
                string kurtaris = selectedRow.Cells[23].Value.ToString();
                string cezakurtaris = selectedRow.Cells[24].Value.ToString();
                string muc = selectedRow.Cells[25].Value.ToString();
                string muckazan = selectedRow.Cells[26].Value.ToString();
                string drib = selectedRow.Cells[27].Value.ToString();
                string dribbasarili = selectedRow.Cells[28].Value.ToString();
                string penyap = selectedRow.Cells[29].Value.ToString();
                string penal = selectedRow.Cells[30].Value.ToString();
                string pengol = selectedRow.Cells[31].Value.ToString();
                string penkac = selectedRow.Cells[32].Value.ToString();
                string pas = selectedRow.Cells[33].Value.ToString();
                string pasisabetli = selectedRow.Cells[34].Value.ToString();
                string kilitpas = selectedRow.Cells[35].Value.ToString();
                string rating = selectedRow.Cells[36].Value.ToString();
                string kilo = selectedRow.Cells[37].Value.ToString();
                string boy = selectedRow.Cells[38].Value.ToString();
                string kosu = selectedRow.Cells[39].Value.ToString();
                string ayak = selectedRow.Cells[41].Value.ToString();
                string ulke = selectedRow.Cells[42].Value.ToString();


                Form6.textBox1.Text = adi;
                Form6.textBox2.Text = yas;
                Form6.textBox3.Text = mevki;
                Form6.textBox4.Text = takim;
                Form6.textBox5.Text = mac;
                Form6.textBox6.Text = gol;
                Form6.textBox7.Text = asist;
                Form6.textBox8.Text = sari;
                Form6.textBox9.Text = kirmizi;
                Form6.textBox10.Text = sakatlik;
                Form6.textBox11.Text = oyundan_cik;
                Form6.textBox12.Text = yedek;
                Form6.textBox13.Text = dgun;
                Form6.textBox14.Text = kaptan;
                Form6.textBox15.Text = sut;
                Form6.textBox16.Text = yenengol;
                Form6.textBox17.Text = faul;
                Form6.textBox18.Text = mud;
                Form6.textBox19.Text = blok;
                Form6.textBox20.Text = orta;
                Form6.textBox21.Text = paskes;
                Form6.textBox22.Text = uzaklastirma;
                Form6.textBox23.Text = topkaybi;
                Form6.textBox24.Text = kurtaris;
                Form6.textBox25.Text = cezakurtaris;
                Form6.textBox26.Text = muc;
                Form6.textBox27.Text = muckazan;
                Form6.textBox28.Text = drib;
                Form6.textBox29.Text = dribbasarili;
                Form6.textBox30.Text = penyap;
                Form6.textBox31.Text = penal;
                Form6.textBox32.Text = pengol;
                Form6.textBox33.Text = penkac;
                Form6.textBox34.Text = pas;
                Form6.textBox35.Text = pasisabetli;
                Form6.textBox36.Text = kilitpas;
                Form6.textBox44.Text = rating;
                Form6.textBox39.Text = kilo;
                Form6.textBox37.Text = boy;
                Form6.textBox41.Text = kosu;
                Form6.textBox42.Text = ayak;
                Form6.textBox43.Text = ulke;


                Form6.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string secilikolon = comboBox1.SelectedItem.ToString();

            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da2 = new SqlDataAdapter($"select oyuncu_adi, oyuncu_yas, mevki_adi, takim_ad, oyuncu_mac_sayi, oyuncu_gol, oyuncu_asist, oyuncu_sari, oyuncu_kirmizi, oyuncu_sakatlik, oyuncu_oyundan_cikis, oyuncu_yedek, oyuncu_dogumgunu, oyuncu_kaptan, oyuncu_sut, oyuncu_yenen_gol, oyuncu_yaptıgı_faul, oyuncu_mudahale, oyuncu_blok, oyuncu_orta, oyuncu_pas_kesme, oyuncu_uzaklastirma, oyuncu_top_kaybi, oyuncu_kurtaris, oyuncu_cezasahasi_kurtaris, oyuncu_mucadele, oyuncu_mucadele_kazanilan, oyuncu_dribbling_girisimi, oyuncu_dribbling_basarili, oyuncu_penalti_yaptigi, oyuncu_penalti_kazanilan, oyuncu_penalti_gol, oyuncu_penalti_kacan, oyuncu_pas, oyuncu_pas_isabetli, oyuncu_pas_kilit, oyuncu_rating, oyuncu_id from oyuncu,takim,mevki where oyuncu.takim_id = takim.takim_id and oyuncu.mevki_id = mevki.mevki_id order by {secilikolon} DESC", con);
            con.Open();
            DataTable dt = new DataTable();
            da2.Fill(dt);
            advancedDataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {

        }
    }
}
/*using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageSaveToDatabaseExample
{
    public partial class MainForm : Form
    {
        private const string ConnectionString = "your_connection_string_here";

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;
                pbImage.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pbImage.Image == null)
            {
                MessageBox.Show("Lütfen bir resim seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] imageBytes = ImageToByteArray(pbImage.Image);

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Images (ImageData) VALUES (@ImageData)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ImageData", imageBytes);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Resim başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim kaydedilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}
*/
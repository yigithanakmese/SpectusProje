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
    public partial class Form5 : Form
    {
        int k_id = k_session.Instance.k_id;
        public Form5()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection("Data Source=ETHN-BILGISAYAR\\SQLEXPRESS;Initial Catalog=futbol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter da = new SqlDataAdapter("select o.oyuncu_adi, o.oyuncu_yas,m.mevki_adi, t.takim_ad,oyuncu_mac_sayi,o.oyuncu_gol," +
                " o.oyuncu_asist, o.oyuncu_sari, o.oyuncu_kirmizi, o.oyuncu_sakatlik, o.oyuncu_oyundan_cikis, o.oyuncu_yedek,o.oyuncu_dogumgunu," +
                " o.oyuncu_kaptan, o.oyuncu_sut, o.oyuncu_yenen_gol, o.oyuncu_yaptıgı_faul, o.oyuncu_mudahale, o.oyuncu_blok, o.oyuncu_orta," +
                " o.oyuncu_pas_kesme, o.oyuncu_uzaklastirma, o.oyuncu_top_kaybi, o.oyuncu_kurtaris,o.oyuncu_cezasahasi_kurtaris, o.oyuncu_mucadele," +
                " o.oyuncu_mucadele_kazanilan, o.oyuncu_dribbling_girisimi,o.oyuncu_dribbling_basarili, o.oyuncu_penalti_yaptigi, o.oyuncu_penalti_kazanilan," +
                " o.oyuncu_penalti_gol,o.oyuncu_penalti_kacan, o.oyuncu_pas, o.oyuncu_pas_isabetli, o.oyuncu_pas_kilit, o.oyuncu_rating, o.oyuncu_id,a.ayak ," +
                " u.ulke_ad" +
                "  from oyuncu o left join ayak a on a.ayak_id=o.ayak_id left join  mevki m on o.mevki_id= m.mevki_id" +
                " left join takim t on t.takim_id=o.takim_id left join ulke u on u.ulke_id=o.ulke_id inner join favoriler f on o.oyuncu_id= f.oyuncu_id" +
                " where f.kullanici_id = '"+k_id+"'", con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

       



        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
    }
}

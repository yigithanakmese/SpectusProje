using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp3.notlarkaydetme;

namespace WindowsFormsApp3
{
    public partial class notlatform : Form
    {
        private string aktifdosyayolu;

        public notlatform()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                aktifdosyayolu = openFileDialog.FileName;
                string dosyaicerigi = File.ReadAllText(aktifdosyayolu);
                richTextBox1.Text = dosyaicerigi;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(aktifdosyayolu))
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    aktifdosyayolu = saveFileDialog.FileName;
                    string dosyayolu = aktifdosyayolu;
                    File.WriteAllText(dosyayolu, richTextBox1.Text);
                }
            }
            else
            {
                string dosyayolu = aktifdosyayolu;
                File.WriteAllText(dosyayolu, richTextBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                aktifdosyayolu = saveFileDialog.FileName;
                string dosyayolu = aktifdosyayolu;
                File.WriteAllText(dosyayolu, richTextBox1.Text);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            notlarkaydetme.degisiklikdurum(true);
        }

        private void notlatform_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool d1 = notlarkaydetme.gecis();
            if (d1 == false)
            {
                if (string.IsNullOrEmpty(aktifdosyayolu))
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        aktifdosyayolu = saveFileDialog.FileName;
                        string dosyayolu = aktifdosyayolu;
                        File.WriteAllText(dosyayolu, richTextBox1.Text);
                    }
                }
                else
                {
                    string dosyayolu = aktifdosyayolu;
                    File.WriteAllText(dosyayolu, richTextBox1.Text);
                }
            }


        }

        /* public bool gecis()
         {
             if (string.IsNullOrEmpty(richTextBox1.Text))
             {
                 return true;
             }

             DialogResult result = MessageBox.Show("Kaydedilmemiş değişiklikler var. Uygulamayı kapatmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

             if (result == DialogResult.Yes)
             {
                 if (string.IsNullOrEmpty(aktifdosyayolu))
                 {
                     System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                     saveFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";

                     if (saveFileDialog.ShowDialog() == DialogResult.OK)
                     {
                         aktifdosyayolu = saveFileDialog.FileName;
                         string dosyayolu = aktifdosyayolu;
                         File.WriteAllText(dosyayolu, richTextBox1.Text);
                     }
                 }
                 else
                 {
                     string dosyayolu = aktifdosyayolu;
                     File.WriteAllText(dosyayolu, richTextBox1.Text);
                 }
                 return true;
             }
             else if (result == DialogResult.No)
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }*/

        /*private void notlatform_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text) || MessageBox.Show("Kaydedilmemiş değişiklikler var. Uygulamayı kapatmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = false;
                return;
            }

        }*/
    }
}

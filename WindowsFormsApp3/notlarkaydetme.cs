using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class notlarkaydetme
    {
       
            private static bool dirtyFlag;
            public static void degisiklikdurum(bool degisiklik)
            {
                dirtyFlag = degisiklik;
            }
            public static bool gecis()
            {
                
                if (dirtyFlag == false)
                {
                    return false;
                }
                else
                {
                    DialogResult result = MessageBox.Show("Kaydedilmemiş değişiklikler var. Kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        return false;
                    }
                    else if (result == DialogResult.No)
                    {
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            
        
    }
}

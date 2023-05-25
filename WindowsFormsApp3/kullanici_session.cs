using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3;

namespace WindowsFormsApp3
{
    
    
        public class k_session
        {
            private static k_session instance;

            public int k_id { get; set; }


            private k_session() { }

            public static k_session Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new k_session();
                    }
                    return instance;
                }
            }
        }
    
}

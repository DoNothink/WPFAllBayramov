using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAllBayramov.ClassFolder
{
    class GlobalClass
    {
        public static string sqlConnection
        {
            get
            {
                return @"Data Source=DESKTOP-D69MI98;
                        Initial Catalog=HousingDemoBayramov;
                        Integrated Security=True";
            }
        }
    }
}

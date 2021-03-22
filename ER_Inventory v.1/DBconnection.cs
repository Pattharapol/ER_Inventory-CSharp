using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER_Inventory_v._1
{
    class DBconnection
    {
        public string myConnection()
        {
            string conn = "server=localhost;user id=root;password=;database=inventory";
            return conn;
        }
    }
}

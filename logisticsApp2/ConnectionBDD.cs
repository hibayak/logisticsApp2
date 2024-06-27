using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logisticsApp2
{
    public  class ConnectionBDD
    {

            public  SqlConnection connx;

            public  ConnectionBDD() 
            {
                connx = new SqlConnection(@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=DBStock;Integrated Security=True");
            }
        public SqlConnection Connect_fct()
        {
            if (connx.State != ConnectionState.Open == true)
                connx.Open();
            return connx;

        }
        public void Diconnect_fct()
        {
            if (connx.State == ConnectionState.Open == true)
                connx.Close();
        }
    }
}


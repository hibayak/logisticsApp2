using logisticsApp2.data_access_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logisticsApp2.business_layer
{
    internal class clsLogin
    {
        
        public DataTable login(string ID_user ,string passe_word)
        {
            ConnectionBDD2 data_access_layer = new ConnectionBDD2();
            SqlParameter[] prmtr = new SqlParameter[2];
            prmtr[0]  = new SqlParameter(ID_user, SqlDbType.VarChar, 50);
            prmtr[0].Value = ID_user;
            prmtr[1] = new SqlParameter(passe_word, SqlDbType.VarChar, 50);
            prmtr[1].Value = passe_word;
            data_access_layer.Connect_fct();
            DataTable dt = new DataTable();
            dt = data_access_layer.readSelectData("login_proc ", prmtr);
            return dt;
        }

             //clsLogin() { }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logisticsApp2.data_access_layer
{

    public class ConnectionBDD2
    {

        public SqlConnection connx;

        public ConnectionBDD2()
        {
            connx = new SqlConnection(@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=DB_users;Integrated Security=True");
        }

        public SqlConnection Connect_fct()
        {
            if (connx.State != ConnectionState.Open == true)
            {
                connx.Open();
            }
            return connx;

        }
        public void Diconnect_fct()
        {
            if (connx.State == ConnectionState.Open == true)
            {
                connx.Close();
            }
        }


        public DataTable readSelectData(string stored_procedure, SqlParameter[] parametres)
        {
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = stored_procedure;

            if (parametres != null)
            {
                for (int i = 0; i < parametres.Length; i++)
                {
                    sqlcomm.Parameters.Add(parametres[i]);
                }
            }
            SqlDataAdapter datasAdapter = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            datasAdapter.Fill(dt);
            return dt;
        }
        //Procedure 
        public void ExeCommande(string stored_procedure, SqlParameter[] parametres)
        {
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = stored_procedure;
            if (parametres != null)
            {
                sqlcomm.Parameters.AddRange(parametres);
            }
            sqlcomm.ExecuteNonQuery();
        }
    }
}


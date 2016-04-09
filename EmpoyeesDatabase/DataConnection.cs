using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoyeesDatabase
{
    class DataConnection
    {
        private string sql_string;
        private string strCon;
        System.Data.SqlClient.SqlDataAdapter dataAdap1;

        public string Sql
        {
            set { sql_string = value; }
        }

        public string ConnectionString
        {
            set { strCon = value;  }
        }

        public System.Data.DataSet GetConnection
        {
            get { return MyDataSet(); }
        }

        private System.Data.DataSet MyDataSet()
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(strCon);
            con.Open();

            dataAdap1 = new System.Data.SqlClient.SqlDataAdapter(sql_string, con);
            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataAdap1.Fill(dataSet, "Table_Data_1");
            con.Close();
            return dataSet;
        }

        public void UpdateDatabase(System.Data.DataSet ds)
        {
            System.Data.SqlClient.SqlCommandBuilder cb = new System.Data.SqlClient.SqlCommandBuilder(dataAdap1);
            cb.DataAdapter.Update(ds.Tables[0]);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Database
{
    class ConnectionString
    {
        SqlConnection cnn;
        SqlDataAdapter da;
        DataSet ds;
        public ConnectionString()
        {
            string str = "Data Source=.;Initial Catalog=QuanLyBanHang;Integrated Security=True";
            cnn = new SqlConnection(str);
        }
        public DataTable Execute(string ex)
        {
            da = new SqlDataAdapter(ex, cnn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void ExecuteNonQuery(string Nonex)
        {
            SqlCommand cmd = new SqlCommand(Nonex, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public int getInt(string s)
        {
            object result = null;
            SqlCommand cmd = new SqlCommand(s, cnn);
            cnn.Open();
            result = cmd.ExecuteScalar();
            cnn.Close();
            if (result != null)
            {
                return int.Parse(result.ToString());
            }
            return 0;
        }
        public string getString(string s)
        {
            object result = null;
            SqlCommand cmd = new SqlCommand(s, cnn);
            cnn.Open();
            result = cmd.ExecuteScalar();
            cnn.Close();
            if (result != null)
            {
                return result.ToString();
            }
            return "";
        }
    }
}

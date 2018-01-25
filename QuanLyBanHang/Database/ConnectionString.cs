using QuanLyBanHang.Log;
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
        //Log 
        log_error log = new log_error();
        SqlConnection cnn;
        SqlDataAdapter da;
        DataSet ds;
        public ConnectionString()
        {
            try
            {
                string str = "Data Source=DESKTOP-A4KCVQU\\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
                cnn = new SqlConnection(str);
                log.WriteLogSystem("Connect database success");
            }
            catch(Exception ex)
            {
                log.WriteLogError("Lỗi connect database: " + ex.ToString());
            }
           
        }
        public DataTable Execute(string query)
        {
            da = new SqlDataAdapter(query, cnn);
            ds = new DataSet();
            var result = ds.Tables[null];
            try
            { 
                da.Fill(ds);
                result = ds.Tables[0];
                log.WriteLogDatabase("Query success.");
            }
            catch(Exception ex)
            {
                log.WriteLogError("Lỗi truy vấn database : "+ ex.ToString());
            }
            return result;
        }
        public bool ExecuteNonQuery(string Nonex)
        {
            bool check = false;
            SqlCommand cmd = new SqlCommand(Nonex, cnn);
            cnn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                check = true;
                log.WriteLogDatabase("Query success.");
            }
            catch(Exception ex)
            {
                check = false;
                log.WriteLogError("Lỗi thay đổi database : " + ex.ToString());
            }
            cnn.Close();
            return check;
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
        public string getString(string query)
        {
            object result = null;
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            try
            {
                result = cmd.ExecuteScalar();
                log.WriteLogDatabase("Query success.");
                if (result != null)
                {
                    result = result.ToString();
                }
                else
                {
                    result = "";
                }
            }
            catch (Exception ex)
            {
                log.WriteLogError("Lỗi truy vấn database : " + ex.ToString());
            }
            cnn.Close();
            return result.ToString(); 
        }
    }
}

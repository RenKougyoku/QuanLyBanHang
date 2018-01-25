using QuanLyBanHang.Database;
using QuanLyBanHang.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Model
{
    class unit_model
    {
        //Log 
        log_error log = new log_error();
        ConnectionString db;
        public unit_model()
        {
            db = new ConnectionString();
        }
        public DataTable getAllUnit()
        {
            string sql_query = "select row_number()OVER(ORDER BY unit_id asc) as STT"
                            + ",unit_id"
                            + ",unit_name"
                            + " from tb_unit";
            log.WriteLogDatabase("Query getAllUnit : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
    }
}

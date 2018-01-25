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
    class person_model
    {
        log_error log = new log_error();
        ConnectionString db;

        public person_model()
        {
            db = new ConnectionString();
        }
        public DataTable getAllPersionInfo()
        {
            String sql_query = " select person_id "
                + ", person_name "
                + ", person_address"
                + ", person_phone "
                + ", typeperson "
                + " from tb_person"
                + " where del_fg = 0";
            log.WriteLogDatabase("Query getAllPersionInfo : " + sql_query);
            DataTable dt = new DataTable();
            dt = db.Execute(sql_query);
            return dt;
        }
    }
}

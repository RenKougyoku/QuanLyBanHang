﻿using QuanLyBanHang.Database;
using QuanLyBanHang.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Model
{
    class category_model
    {
        //Log 
        log_error log = new log_error();
        ConnectionString db;
        public category_model()
        {
            db = new ConnectionString();
        }
        public DataTable getAllCategory()
        {
            string sql_query = "select row_number()OVER(ORDER BY category_id asc) as STT"
                            + ",category_id"
                            + ",category_name"
                            + " from tb_category";
            log.WriteLogDatabase("Query getAllCategory : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
    }
}

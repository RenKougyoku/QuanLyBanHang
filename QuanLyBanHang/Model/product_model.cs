using QuanLyBanHang.Database;
using QuanLyBanHang.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Model
{
    class product_model
    {
        //Log 
        log_error log = new log_error();
        ConnectionString db;
        public product_model()
        {
            db = new ConnectionString();
        }
        public DataTable getAllProduct()
        {
            string sql_query = "select row_number()OVER(ORDER BY product_id asc) as STT"
                            + ",product_id"
                            + ",product_name"
                            + ",price_in"
                            + ",price_out"
                            + ",quantity"
                            + ",modifi"
                            + ",(case pro.category_id when NULL then '' else (select category_name from tb_category cate where cate.category_id = pro.category_id ) end ) as category_name "
                            + ",(case pro.unit_id when NULL then '' else (select unit_name from tb_unit uni where uni.unit_id = pro.unit_id ) end ) as unit_name "
                            + ",brandname"
                            + ",size"
                            + ",photo"
                            + ",del_fg"
                            + " from tb_product pro"
                            + " where del_fg = 0";
            log.WriteLogDatabase("Query getAllProduct : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public DataTable getAllProductByKey(string key)
        {
            string sql_query = string.Format("select row_number()OVER(ORDER BY product_id asc) as STT"
                            + ",product_id"
                            + ",product_name"
                            + ",price_in"
                            + ",price_out"
                            + ",quantity"
                            + ",modifi"
                            + ",(case pro.category_id when 0 then '' else (select category_name from tb_category cate where cate.category_id = pro.category_id ) end ) as category_name "
                            + ",(case pro.unit_id when 0 then '' else (select unit_name from tb_unit uni where uni.unit_id = pro.unit_id ) end ) as unit_name "
                            + ",brandname"
                            + ",size"
                            + ",photo"
                            + ",del_fg"
                            + " from tb_product pro"
                            + ",tb_category cate"
                            + ",tb_unit unit"
                            + " where (pro.product_id like '%{0}%' "
                            + " OR product_name like N'%{0}%'"
                            + " OR brandname like N'%{0}%'"
                            + " Or category_name like N'%{0}%')"
                            + " and del_fg = 0",key);
            log.WriteLogDatabase("Query getAllProductByKey : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public bool delProduct(string id)
        {
            bool check = false;
            string sql_query = string.Format("UPDATE tb_product SET del_fg = 1 where product_id = '{0}'", id);
            log.WriteLogDatabase("Query delProduct : " + sql_query);
            if (db.ExecuteNonQuery(sql_query) == true)
            {
                log.WriteLogDatabase("Result database : Đã update del_fg của ID :" + id + " thành 1");
                check = true;
            }
            else
            {
                log.WriteLogDatabase("Result database : delProduct => Fail");
                check = false;

            }
            return check;
        }
        public bool checkProductIdExists(string id)
        {
            bool check = false;
            string sql_query = string.Format("SELECT product_id FROM tb_product where product_id = '{0}'", id);
            log.WriteLogDatabase("Query checkProductIdExists : " + sql_query);
            if (!db.getString(sql_query).Equals(""))
            {
                log.WriteLogDatabase(id+": Tồn tại.");
                check = true;
            }
            else
            {
                log.WriteLogDatabase(id + ": Chưa tồn tại.");
                check = false;
            }
            return check;
        }
        public bool insProduct(string id,string name, string price_i, string price_o,string sl, string mota,string cate, string unit,string brand,string size)
        {
            bool check = false;
            decimal price_in = Convert.ToDecimal(price_i);
            decimal price_out = Convert.ToDecimal(price_o);
            var slg = Convert.ToInt32(sl);
            var ca = Convert.ToInt32(cate);
            var un = Convert.ToInt32(unit);
            string sql_query = string.Format("INSERT INTO tb_product"
                                                    + " (product_id "
                                                    + ", product_name"
                                                    + ", price_in"
                                                    + ", price_out"
                                                    + ", quantity"
                                                    + ", modifi"
                                                    + ", category_id"
                                                    + ", unit_id"
                                                    + ", brandname"
                                                    + ", size"
                                                    + ", photo"
                                                    + ", del_fg)"
                                                    + " VALUES('{0}',N'{1}',{2},{3},{4}, N'{5}',{6},{7},N'{8}',N'{9}',NULL,0)"
                                                               ,id,name,price_in,price_out,slg,mota,ca,un,brand,size);
            log.WriteLogDatabase("Query insProduct : " + sql_query);
            if (db.ExecuteNonQuery(sql_query) == true)
            {
                log.WriteLogDatabase("Result database : Đã insert  ID :" + id + " thành công!");
                check = true;
            }
            else
            {
                check = false;
                log.WriteLogDatabase("Result database : insProduct => Fail");
            }
            return check;
        }
        public bool uptProduct(string id, string name, string price_i, string price_o, string sl, string mota, string cate, string unit, string brand, string size)
        {
            bool check = false;
            decimal price_in = Convert.ToDecimal(price_i);
            decimal price_out = Convert.ToDecimal(price_o);
            var slg = Convert.ToInt32(sl);
            var ca = Convert.ToInt32(cate);
            var un = Convert.ToInt32(unit);
            string sql_query = string.Format("UPDATE tb_product SET "
                                                + "  product_name = N'{1}'"
                                                + ", price_in = {2} "
                                                + ", price_out = {3} "
                                                + ", quantity = {4}"
                                                + ", modifi = N'{5}'"
                                                + ", category_id = {6}"
                                                + ", unit_id = {7}"
                                                + ", brandname = N'{8}'"
                                                + ", size = N'{9}'"
                                                + " where product_id = '{0}'"
                                                , id, name, price_in, price_out, slg, mota, ca, un, brand, size);
            log.WriteLogDatabase("Query uptProduct : " + sql_query);
            if (db.ExecuteNonQuery(sql_query) == true)
            {
                log.WriteLogDatabase("Result database : Đã update  ID :" + id + " thành công!");
                check = true;
            }
            else
            {
                check = false;
                log.WriteLogDatabase("Result database : uptProduct => Fail");
            }
            return check;
        }

    }
}

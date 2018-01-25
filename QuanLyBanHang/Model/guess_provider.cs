using QuanLyBanHang.Content;
using QuanLyBanHang.Database;
using QuanLyBanHang.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Model
{
    class guess_provider
    {
        //Log 
        log_error log = new log_error();
        Error err = new Error();
        ConnectionString db;
        public guess_provider()
        {
            db = new ConnectionString();
        }
        public DataTable getLstGuessProvider()
        {
            string sql_query = "select row_number()OVER(ORDER BY per.person_id asc) as STT"
                            + ", per.person_id"
                            + ", person_name"
                            + ", person_address"
                            + ", person_phone"
                            + ", (case when deal.num_deal IS NULL THEN 0 ELSE deal.num_deal END ) as num_deal"
                            + ", (case deal.date_deal when NULL THEN '' ELSE deal.date_deal END ) as date_deal"
                            + ", (case typeperson when 1 then 'Khách hàng' else N'Nhà cung cấp' end) as typeperson"
                            + " from tb_person per" 
                            + " left outer join"
                            + "     (select count(per.person_id) as num_deal"
                            + "     ,per.person_id"
                            + "     ,max(bill_date) as date_deal"
                            + "     From tb_person per left join tb_bill bi"
                            + "     on per.person_id = bi.person_id"
                            + "     where bi.del_fg = 0"
                            + "     group by per.person_id) deal"
                            + " on per.person_id = deal.person_id"
                            + " where per.del_fg = 0"
                            + " and per.person_id not in ('000','111')"
                            + " group by deal.date_deal"
                            + ",deal.num_deal"
                            + ",per.person_id"
                            + ",person_name"
                            + ",person_address"
                            + ",person_phone"
                            + ",typeperson";
            DataTable dt = null;
            try
            {
                log.WriteLogDatabase("Query getLstGuessProvider : " + sql_query);
                dt = db.Execute(sql_query);
            }
            catch(Exception ex)
            {
                log.WriteLogError("Query getLstGuessProvider : " + ex.ToString());
                MessageBox.Show(err.MD_ERR_G01);
            }
            return dt;
        }
        public DataTable getLstGuessProviderByType(int type) 
        {
            string sql_query = "select row_number()OVER(ORDER BY per.person_id asc) as STT"
                            + ", per.person_id"
                            + ", person_name"
                            + ", person_address"
                            + ", person_phone"
                            + ", (case when deal.num_deal IS NULL THEN 0 ELSE deal.num_deal END ) as num_deal"
                            + ", (case deal.date_deal when NULL THEN '' ELSE deal.date_deal END ) as date_deal"
                            + ", (case typeperson when 1 then 'Khách hàng' else 'Nhà cung câp' end) as typeperson"
                            + " from tb_person per"
                            + " left outer join"
                            + "     (select count(per.person_id) as num_deal"
                            + "     ,per.person_id"
                            + "     ,max(bill_date) as date_deal"
                            + "     From tb_person per left join tb_bill bi"
                            + "     on per.person_id = bi.person_id"
                            + "     where bi.del_fg = 0"
                            + "     group by per.person_id) deal"
                            + " on per.person_id = deal.person_id"
                            + " where per.del_fg = 0"
                            + " and per.person_id not in ('000','111')"
                            + " and typeperson = " + type + " "
                            + " and per.person_id not in ('000','111')"
                            + " group by deal.date_deal"
                            + ",deal.num_deal"
                            + ",per.person_id"
                            + ",person_name"
                            + ",person_address"
                            + ",person_phone"
                            + ",typeperson";
            DataTable dt = null;
            try
            {
                log.WriteLogDatabase("Query getLstGuessProviderByType : " + sql_query);
                dt = db.Execute(sql_query);
            }
            catch (Exception ex)
            {
                log.WriteLogError("Query getLstGuessProviderByType : " + ex.ToString());
                MessageBox.Show(err.MD_ERR_G02);
            }
            return dt;
        }
        public DataTable getLstGuessProviderByKeyType(string key,int type)
        {
            string sql_query = string.Format("select row_number()OVER(ORDER BY per.person_id asc) as STT"
                            + ", per.person_id"
                            + ", person_name"
                            + ", person_address"
                            + ", person_phone"
                            + ", (case when deal.num_deal IS NULL THEN 0 ELSE deal.num_deal END ) as num_deal"
                            + ", (case deal.date_deal when NULL THEN '' ELSE deal.date_deal END ) as date_deal"
                            + ", (case typeperson when 1 then 'Khách hàng' else 'Nhà cung câp' end) as typeperson"
                            + " from tb_person per"
                            + " left outer join"
                            + "     (select count(per.person_id) as num_deal"
                            + "     ,per.person_id"
                            + "     ,max(bill_date) as date_deal"
                            + "     From tb_person per left join tb_bill bi"
                            + "     on per.person_id = bi.person_id"
                            + "     where bi.del_fg = 0"
                            + "     group by per.person_id) deal"
                            + " on per.person_id = deal.person_id"
                            + " where per.del_fg = 0"
                            + " and typeperson = " + type + " "
                            + " and per.person_id not in ('000','111')"
                            + " and (per.person_id like '%{0}%' "
                            + " OR person_name like '%{0}%' "
                            + " OR person_phone = '{0}' "
                            + " OR person_address like '%{0}%')"
                            + " group by deal.date_deal"
                            + ",deal.num_deal"
                            + ",per.person_id"
                            + ",person_name"
                            + ",person_address"
                            + ",person_phone"
                            + ",typeperson", key);
            DataTable dt = null;
            try
            {
                log.WriteLogDatabase("Query getLstGuessProviderByKeyType : " + sql_query);
                dt = db.Execute(sql_query);
            }
            catch (Exception ex)
            {
                log.WriteLogError("Query getLstGuessProviderByKeyType : " + ex.ToString());
                MessageBox.Show(err.MD_ERR_G03);
            }
            return dt;
        }
        public DataTable getLstGuessProviderByKey(string key)
        {
            string sql_query = string.Format("select row_number()OVER(ORDER BY per.person_id asc) as STT"
                            + ", per.person_id"
                            + ", person_name"
                            + ", person_address"
                            + ", person_phone"
                            + ", (case when deal.num_deal IS NULL THEN 0 ELSE deal.num_deal END ) as num_deal"
                            + ", (case deal.date_deal when NULL THEN '' ELSE deal.date_deal END ) as date_deal"
                            + ", (case typeperson when 1 then 'Khách hàng' else 'Nhà cung câp' end) as typeperson"
                            + " from tb_person per"
                            + " left outer join"
                            + "     (select count(per.person_id) as num_deal"
                            + "     ,per.person_id"
                            + "     ,max(bill_date) as date_deal"
                            + "     From tb_person per left join tb_bill bi"
                            + "     on per.person_id = bi.person_id"
                            + "     where bi.del_fg = 0"
                            + "     group by per.person_id) deal"
                            + " on per.person_id = deal.person_id"
                            + " where per.del_fg = 0"
                            + " and (per.person_id like '%{0}%' "
                            + " OR person_name like '%{0}%' "
                            + " OR person_phone = '{0}' "
                            + " OR person_address like '%{0}%')"
                            + " group by deal.date_deal"
                            + ",deal.num_deal"
                            + ",per.person_id"
                            + ",person_name"
                            + ",person_address"
                            + ",person_phone"
                            + ",typeperson", key);
            DataTable dt = null;
            try
            {
                log.WriteLogDatabase("Query getLstGuessProviderByKey : " + sql_query);
                dt = db.Execute(sql_query);
            }
            catch (Exception ex)
            {
                log.WriteLogError("Query getLstGuessProviderByKey : " + ex.ToString());
                MessageBox.Show(err.MD_ERR_G04);
            }
            return dt;
        }
        public bool delGuessProviderById(string id)
        {
            bool check = false;
            string sql_query = string.Format("UPDATE tb_Person SET del_fg = 1 where person_id = '{0}'", id);
            log.WriteLogDatabase("Query delGuessProviderById : " + sql_query);
            if(db.ExecuteNonQuery(sql_query) == true)
            {
                log.WriteLogDatabase("Result database : Đã update del_fg của ID :" + id + " thành 1");
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public bool insGuessPeoviderById(string id, string name, string address, string phone, int type)
        {
            bool check = false;
            string sql_query = string.Format(" INSERT INTO tb_person "
                                              + " ( person_id "
                                              + " , person_name"
                                              + " , person_address"
                                              + " , person_phone"
                                              + " , typeperson"
                                              + " , del_fg )"
                                              + " VALUES"
                                              + " ( '{0}'"
                                              + " , N'{1}'"
                                              + " , N'{2}'"
                                              + " , '{3}'"
                                              + " , {4}"
                                              + " , 0)",id,name,address,phone,type);
            log.WriteLogDatabase("Query insGuessPeoviderById : " + sql_query);
            if (db.ExecuteNonQuery(sql_query) == true)
            {
                log.WriteLogDatabase("Result database : Đã insert thành công ID :" + id + " vào database.");
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public bool uptGuessPeoviderById(string id, string name, string address, string phone, int type)
        {
            bool check = false;
            string sql_query = string.Format(" UPDATE tb_person "
                                              + " SET person_name = N'{1}'"
                                              + " , person_address = N'{2}'"
                                              + " , person_phone = '{3}'"
                                              + " , typeperson = {4}"
                                              + " WHERE person_id = '{0}'"
                                              , id, name, address, phone, type);
            log.WriteLogDatabase("Query uptGuessPeoviderById : " + sql_query);
            if (db.ExecuteNonQuery(sql_query) == true)
            {
                log.WriteLogDatabase("Result database : Đã update thành công ID :" + id + " vào database.");
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public bool checkGuessProviderExists(string id)
        {
            bool check = false;
            string sql_query = string.Format("SELECT person_id FROM tb_person where person_id = '{0}'", id);
            log.WriteLogDatabase("Query checkGuessProviderExists : " + sql_query);
            if (!db.getString(sql_query).Equals(""))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public DataTable getLstProvider()
        {
            string sql_query = "  Select (case person_id when '111' then N'<Trống>' else person_id end) as person_id "
                            + ", person_name"
                            + ", person_address"
                            + ", person_phone"
                            + ", typeperson"
                            + " from tb_person"
                            + " where typeperson = 2"
                            + " and   del_fg = 0 ";
            DataTable dt = null;
            try
            {
                log.WriteLogDatabase("Query getLstProvider : " + sql_query);
                dt = db.Execute(sql_query);
            }
            catch (Exception ex)
            {
                log.WriteLogError("Query getLstProvider : " + ex.ToString());
                MessageBox.Show(err.MD_ERR_G05);
            }
            return dt;
        }
        public string getNameProvider(string id)
        {
            string sql_query = string.Format("SELECT person_name FROM tb_person Where person_id = '{0}' and typeperson = 2 and del_fg = 0", id);
            log.WriteLogDatabase("Query getNameProvider : " + sql_query);
            log.WriteLogDatabase("Result getNameProvider : " + db.getString(sql_query));
            return db.getString(sql_query);
        }
        public DataTable getLstGuess()
        {
            string sql_query = "  Select (case person_id when '000' then N'<Trống>' else person_id end) as person_id "
                            + ", person_name"
                            + ", person_address"
                            + ", person_phone"
                            + ", typeperson"
                            + " from tb_person"
                            + " where typeperson = 1"
                            + " and   del_fg = 0 ";
            DataTable dt = null;
            try
            {
                log.WriteLogDatabase("Query getLstGuess : " + sql_query);
                dt = db.Execute(sql_query);
            }
            catch (Exception ex)
            {
                log.WriteLogError("Query getLstGuess : " + ex.ToString());
                MessageBox.Show(err.MD_ERR_G06);
            }
            return dt;
        }
        public string getNameGuess(string id)
        {
            string sql_query = string.Format("SELECT person_name FROM tb_person Where person_id = '{0}' and typeperson = 1 and del_fg = 0", id);
            log.WriteLogDatabase("Query getNameGuess : " + sql_query);
            log.WriteLogDatabase("Result getNameGuess : " + db.getString(sql_query));
            return db.getString(sql_query);
        }

    }
}

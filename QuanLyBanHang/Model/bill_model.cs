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
    class bill_model
    {
        //Log 
        log_error log = new log_error();
        ConnectionString db;
        public bill_model()
        {
            db = new ConnectionString();
        }
        public DataTable getBillInfoByDate(string date)
        {
            string sql_query = "select row_number()OVER (ORDER BY bi.bill_id asc ) as STT"
                                + ",(case typebill when 1 then 'Nhâp hàng' else 'Bán hàng' end) as typebill"
                                + ",bi.bill_id"
                                +",bill_date"
                                +",sum(quantity*price_one)"
                                +" from tb_bill bi"
                                +",tb_billdetail bide"
                                +" where bi.bill_id = bide.bill_id"
                                +" and bill_date = '"+date+"'"
                                +" and bi.del_fg = 0"
                                +" and bide.del_fg = 0"
                                +"group by typebill,bi.bill_id,bill_date";
            log.WriteLogDatabase("Query getBillInfo : "+ sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public DataTable getAllBillNhapHang()
        {
            string sql_query = "select row_number()OVER (ORDER BY bill_date desc ) as STT"
                                + ",bill_id"
                                + ",bill_date"
                                + ",(case person_id when '000' then N'<Trống>' else person_id end) as person_id"
                                + ",person_name"
                                + ",note"
                                + ",typebill"
                                + ",del_fg"
                                + " from tb_bill "
                                + " where typebill = 1 "
                                + " and del_fg = 0"
                                + " order by bill_date desc ";
            log.WriteLogDatabase("Query getAllBillNhapHang : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public int countBillInDate(string date)
        {
            int count = 0;
            string sql_query = string.Format( "select count(bill_id) "
                             + " from tb_bill "
                             + " where typebill = 1 "
                             + " and bill_date = '{0}'"
                             + " and del_fg = 0",date);
            log.WriteLogDatabase("Query countBillInDate : " + sql_query);
            count = db.getInt(sql_query);
            log.WriteLogDatabase("Result countBillInDate : " + count.ToString());
            return count;
        }
        public DataTable getAllBillBanHang()
        {
            string sql_query = "select row_number()OVER(ORDER BY bill_date desc) as STT"
                            + ", bill_id"
                            + ", bill_date"
                            + ", (case person_id when '111' then N'<Trống>' else person_id end) as person_id"
                            + ", person_name"
                            + ", note"
                            + ", typebill"
                            + ", del_fg"
                            + " from tb_bill"
                            + " where typebill=2"
                            + " and del_fg = 0";
            log.WriteLogDatabase("Query getBillInfo : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public void addNewBillNhapHang(String billId, String productId, String date, String note, int typebill, int flag, String personName)
        {
            String sql_query = string.Format("insert into tb_bill values( "
                                            + "'{0}', N'{1}', convert(datetime,'{2}',103), N'{3}', {4}, {5}, N'{6}')"
                                            , billId, productId, date, note, typebill, flag, personName);
            log.WriteLogDatabase("Query addNewBill : " + sql_query);
            db.ExecuteNonQuery(sql_query);
        }
        public void addBillDetailNhapHang(String billID, String productID, int quality, int priceOne, String note, int chietkhau)
        {
            String sql_query = "insert into tb_billdetail values('" + billID + "','" + productID + "'," + quality + "," + priceOne + ",'" + note + "',0," + chietkhau + ")";
            log.WriteLogDatabase("Query addNewBillDetail : " + sql_query);
            db.ExecuteNonQuery(sql_query);
        }
    }
}

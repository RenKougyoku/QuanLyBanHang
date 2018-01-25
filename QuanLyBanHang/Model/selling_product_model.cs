using QuanLyBanHang.Database;
using QuanLyBanHang.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanHang.Model
{
    class selling_product_model
    {
        log_error log = new log_error();
        ConnectionString db;
        public selling_product_model()
        {
            db = new ConnectionString();
        }

        public DataTable getAllBill()
        {
            string sql_query = "select row_number()OVER(ORDER BY bill_date desc) as STT" 
                            +", bill_id" 
                            +", bill_date"
                            +", person_id"
                            +", person_name"
                            +", note"
                            +", typebill"
                            +", del_fg"
                            + " from tb_bill"
                            + " where typebill=2"
                            + " and del_fg = 0";
            log.WriteLogDatabase("Query getBillInfo : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }

        public DataTable getAllProductByKey(string key)
        {
            string sql_query = string.Format("select row_number()OVER(ORDER BY product_id asc) as STT"
                           + " ,product_id"
                           + " ,product_name"
                           + " ,quantity" 
                           + " ,price_in"
                           + " from tb_product"
                           + " where product_name like '%{0}%'"
                           + " or product_id like '%{0}%'", key);
            log.WriteLogDatabase("Query getAllProductByKey : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }

        public int getBillCountToday(String date)
        {
            string sql_query = "select count(*)"
                                + " from tb_bill bi"
                                + " where bill_date = '" + date + "'";
            log.WriteLogDatabase("Query getBillCountToday : " + sql_query);
            int result = db.getInt(sql_query);
            return result;
        }

        public void addNewBill(String billId, String personId, String date, String note, int typebill, int flag, String personName)
        {
            String sql_query = string.Format("insert into tb_bill values( "
                                            +"'{0}', N'{1}', '{2}', '{3}', '{4}', {5},N'{6}', 0)" 
                                            , billId, personId, date,note, typebill, flag, personName);
            log.WriteLogDatabase("Query addNewBill : " + sql_query);
            db.ExecuteNonQuery(sql_query);
        }
        public void addBillDetail(String billID, String productID, int quality, int priceOne, String note, int chietkhau)
        {
            String sql_query = "insert into tb_billdetail values('" + billID + "','" + productID + "'," + quality + "," + priceOne + ",'" + note + "',0," + chietkhau + ")";
            log.WriteLogDatabase("Query addNewBillDetail : " + sql_query);
            db.ExecuteNonQuery(sql_query);
        }

        public void deleteBill(String billId)
        {
            String sql_query = "update tb_bill set del_fg = 1 where bill_id = " + billId;
            log.WriteLogDatabase("Query deleteBill : " + sql_query);
            db.ExecuteNonQuery(sql_query);
        }

        public void deleteBillDetail(String billId)
        {
            String sql_query  = "update tb_billdetail set del_fg = 1 where bill_id =" + billId;
            log.WriteLogDatabase("Query deleteBillDetail : " + sql_query);
            db.ExecuteNonQuery(sql_query);
        }

        public DataTable loadBillbyId(String billId)
        {
            String sql_query = "select row_number()OVER(ORDER BY billdetail_id asc) as STT " +
                ", bill_id" +
                ", product_id" +
                ", quantity" +
                ", price_one" +
                ", note" +
                ", chietkhau" +
                " from tb_billdetail" +
                " where del_fq = 0 " +
                " and bill_id =" + billId;
            log.WriteLogDatabase("Query loadBillbyId : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }

        public DataTable getAllProductByBillId(String billId)
        {
            String sql_query = "select row_number()OVER(ORDER BY bi.product_id asc) as STT" +
                ", bi.bill_id" +
                ", bi.product_id" +
                ", rp.product_name" +
                ", bi.quantity " +
                "from tb_billdetail bi, tb_product rp " +
                "where bi.product_id = rp.product_id " +
                "and bi.bill_id = '" + billId + "'";
            log.WriteLogDatabase("Query getAllProductByBillId : " + sql_query);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }

        public void updateBillDetail(String billID, String productID, String productName, String productQuality, String productNote, String productPriceOne, String productChietKhau)
        {
            String sql_query = "update tb_billdetail " +
                "set quantity = " + productQuality +
                ", price_one = " + productPriceOne +
                ", note = '" + productNote + "'" +
                ",chietkhau = " + productChietKhau +
                " where bill_id = '" + billID + "'" +
                " and product_id = '" + productID + "'";
            log.WriteLogDatabase("Query updateBillDetail : " + sql_query);
            db.ExecuteNonQuery(sql_query);
        }
    }
}

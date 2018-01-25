using QuanLyBanHang.Log;
using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Controller
{
    class Homecontroller
    {
        //LOG 
        log_error log = new log_error();
        //khai bao model 
        bill_model bm = new bill_model();
        product_model pm = new product_model();
        public int loadLstBillByDate(ListView lv,string date)
        {
            DataTable dt = bm.getBillInfoByDate(date);
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//type 
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//id 
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//date
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//bill money
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
            return numrow;
        }
        public void loadLstProduct(ListView lv)
        {
            DataTable dt = pm.getAllProduct();
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id  
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//name
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//gia in 
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//gia out 
                lvi.SubItems.Add(dt.Rows[i][8].ToString());//don vi
                lvi.SubItems.Add(dt.Rows[i][10].ToString());//kich thuoc 
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//so luong con
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
        }
    }
}

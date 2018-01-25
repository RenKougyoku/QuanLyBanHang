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
    class NhaphangController
    {
        log_error log = new log_error();
        product_model pm = new product_model();
        category_model ct = new category_model();
        unit_model un = new unit_model();
        bill_model bi = new bill_model();
        guess_provider gu = new guess_provider();
        HamChung hc = new HamChung();
        public void loadLstBillNhaphang(ListView lv)
        {
            DataTable dt = bi.getAllBillNhapHang();
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index 
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id 
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//date 
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//per id
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//pername
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//so luong con 
                lvi.SubItems.Add(dt.Rows[i][6].ToString());//modify
                lvi.SubItems.Add(dt.Rows[i][7].ToString());//cate
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
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
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//so luong con 
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//price in 
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//price out 
                lvi.SubItems.Add(dt.Rows[i][6].ToString());//modify
                lvi.SubItems.Add(dt.Rows[i][7].ToString());//cate
                lvi.SubItems.Add(dt.Rows[i][8].ToString());//unit
                lvi.SubItems.Add(dt.Rows[i][9].ToString());//brandname
                lvi.SubItems.Add(dt.Rows[i][10].ToString());//size
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
        }
        public void loadLstProductByKey(ListView lv,string key)
        {

        }
        public string itemLstBillNhaphang_click(ListView lv, TextBox txtNhapMHD,ComboBox cbbNhapNCC, TextBox txtNhapTNCC, TextBox txtNhapND, TextBox txtNhapDate)
        {
            txtNhapMHD.Text = lv.SelectedItems[0].SubItems[1].Text.ToString();
            txtNhapDate.Text = lv.SelectedItems[0].SubItems[2].Text.ToString();
            cbbNhapNCC.SelectedIndex = cbbNhapNCC.FindStringExact(lv.SelectedItems[0].SubItems[3].Text.ToString());
            txtNhapTNCC.Text = loadTenNcc(lv.SelectedItems[0].SubItems[3].Text.ToString());
            txtNhapND.Text = lv.SelectedItems[0].SubItems[5].Text.ToString();
            return lv.SelectedItems[0].SubItems[1].Text.ToString();
        }
        public void loadCbbNhaCC(ComboBox cbb)
        {
            string displayCBB = "person_id";
            string valueCBB = "person_id";
            DataTable dt = gu.getLstProvider();
            hc.loadComboBox(cbb, dt, displayCBB, valueCBB);
        }
        public string loadTenNcc(string id)
        {
            return gu.getNameProvider(id);
        }
        public int  countBillInDate(string date)
        {
            return bi.countBillInDate(date);
        }
        public void itemLstProduct_click(ListView lv,TextBox txtNhapMH, TextBox txtNhapSL, TextBox txtNhapTH, TextBox txtNhap1Price)
        {
            txtNhapMH.Text = lv.SelectedItems[0].SubItems[1].Text.ToString();
            txtNhapTH.Text = lv.SelectedItems[0].SubItems[2].Text.ToString();
            txtNhap1Price.Text = lv.SelectedItems[0].SubItems[4].Text.ToString();
        }
        public void loadLstDetailBill(ListView lv,string []data )
        {
            var listViewItem = new ListViewItem(data);
            lv.Items.Add(listViewItem);
        }

        public void addBill(ListView lv, String billId, String productId, String date, String note, int typebill, int flag, String personName)
        {
            int intdex = 0;
            bi.addNewBillNhapHang(billId, productId, date, note, typebill, flag, personName);
            if (lv.Items.Count > 0)
            {
                ListViewItem lvi = lv.Items[intdex];
                /*lvi.SubItems[1].Text = billID;
                lvi.SubItems[2].Text = productID;
                lvi.SubItems[3].Text = productName;
                lvi.SubItems[4].Text = productQuality;
                lvi.SubItems[5].Text = productNote;
                lvi.SubItems[6].Text = productPriceOne;
                lvi.SubItems[7].Text = productChietKhau;*/
                bi.addBillDetailNhapHang(lvi.SubItems[1].Text, lvi.SubItems[2].Text, Int32.Parse(lvi.SubItems[4].Text), Int32.Parse(lvi.SubItems[6].Text), lvi.SubItems[5].Text, Int32.Parse(lvi.SubItems[7].Text));
                intdex++;
            }
            log.WriteLogSystem("Add Bill with  " + intdex + " Item susscess");
        }
    }
}

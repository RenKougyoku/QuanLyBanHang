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
    class KhoController
    {
        log_error log = new log_error();
        product_model pm = new product_model();
        category_model ct = new category_model();
        unit_model un = new unit_model();
        HamChung hc = new HamChung();
        public int loadKhoProduct(ListView lv)
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
            return numrow;
        }
        public int loadKhoProductByKey(ListView lv,string key)
        {
            DataTable dt = pm.getAllProductByKey(key);
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
            return numrow;
        }
        public void loadCategory(ComboBox cbb)
        {
            string displayCBB = "category_name";
            string valueCBB = "category_id";
            DataTable dt = ct.getAllCategory();
            hc.loadComboBox(cbb,dt,displayCBB,valueCBB);
            cbb.SelectedIndex = -1;
        }
        public void loadUnit(ComboBox cbb)
        {
            string displayCBB = "unit_name";
            string valueCBB = "unit_id";
            DataTable dt = un.getAllUnit();
            hc.loadComboBox(cbb, dt, displayCBB, valueCBB);
            cbb.SelectedValue = -1;
        }
        public string loadItemKhohang_Click(ListView lv, TextBox txtKhoMH, ComboBox cbbKhoLH, TextBox txtKhoSL, ComboBox cbbKhoDV, TextBox txtKhoSize, TextBox txtKhoTH, TextBox txtKhoInPr, TextBox txtKhoOPr, TextBox txtKhoBrand, TextBox txtKhoMT)
        {
            txtKhoMH.Text = lv.SelectedItems[0].SubItems[1].Text.ToString();
            cbbKhoLH.SelectedIndex = cbbKhoLH.FindStringExact(lv.SelectedItems[0].SubItems[7].Text.ToString());
            txtKhoSL.Text = lv.SelectedItems[0].SubItems[3].Text.ToString();
            cbbKhoDV.SelectedIndex = cbbKhoDV.FindStringExact(lv.SelectedItems[0].SubItems[8].Text.ToString());
            txtKhoSize.Text = lv.SelectedItems[0].SubItems[10].Text.ToString();
            txtKhoTH.Text = lv.SelectedItems[0].SubItems[2].Text.ToString();
            txtKhoInPr.Text = lv.SelectedItems[0].SubItems[4].Text.ToString();
            txtKhoOPr.Text = lv.SelectedItems[0].SubItems[5].Text.ToString();
            txtKhoBrand.Text = lv.SelectedItems[0].SubItems[9].Text.ToString();
            txtKhoMT.Text = lv.SelectedItems[0].SubItems[6].Text.ToString();
            return lv.SelectedItems[0].SubItems[1].Text.ToString();
        }
        public bool delProductById(string id)
        {
            return pm.delProduct(id); 
        }
        public bool checkProductIdExists(string id)
        {
            return pm.checkProductIdExists(id);
        }
        public bool insProduct(string id, string name, string price_i, string price_o, string sl, string mota, string cate, string unit, string brand, string size)
        {
            if(price_i.Trim() == "")
            {
                price_i = "0";
            }
            if (price_o.Trim() == "")
            {
                price_o = "0";
            }
            if (sl.Trim() == "")
            {
                sl = "0";
            }
            return pm.insProduct(id,name,price_i,price_o,sl,mota,cate,unit,brand,size);
        }
        public bool uptProduct(string id, string name, string price_i, string price_o, string sl, string mota, string cate, string unit, string brand, string size)
        {
            if (price_i.Trim() == "")
            {
                price_i = "0";
            }
            if (price_o.Trim() == "")
            {
                price_o = "0";
            }
            if (sl.Trim() == "")
            {
                sl = "0";
            }
            return pm.uptProduct(id, name, price_i, price_o, sl, mota, cate, unit, brand, size);
        }
    }
}

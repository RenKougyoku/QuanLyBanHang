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
    class SellingProductController
    {
        log_error log = new log_error();
        selling_product_model spm = new selling_product_model();
        guess_provider gu = new guess_provider();
        bill_model bm = new bill_model();
        product_model pm = new product_model();
        HamChung hc = new HamChung();
        public int loadLstAllBillBanhang(ListView lv)
        {
            DataTable dt = bm.getAllBillBanHang();
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//date
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//Person_id
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//person_name
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//note
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
            return numrow;
        }

        public int loadLstAllProDuct(ListView lv)
        {
            DataTable dt = pm.getAllProduct();
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//name
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//so luon con
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
        

        public void itemLstBillBanhang_click(ListView lv,TextBox txtBanIdBill, TextBox txtBanBillDate,ComboBox cbbBanIDProvider, TextBox txtBanNameCustomer, TextBox txtBanContent, ListView lv2)
        {
            txtBanIdBill.Text = lv.SelectedItems[0].SubItems[1].Text.ToString();
            txtBanBillDate.Text = lv.SelectedItems[0].SubItems[2].Text.ToString();
            cbbBanIDProvider.SelectedIndex = cbbBanIDProvider.FindStringExact(lv.SelectedItems[0].SubItems[3].Text.ToString());
            txtBanNameCustomer.Text = lv.SelectedItems[0].SubItems[4].Text.ToString();
            txtBanContent.Text = lv.SelectedItems[0].SubItems[5].Text.ToString();
            DataTable dt = spm.getAllProductByBillId(txtBanIdBill.Text);
            lv2.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//bill id
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//product id
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//product name
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//quatity
            }
        }
        public int loadLstBanSearchResult(ListView lv, String key)
        {
            DataTable dt = spm.getAllProductByKey(key);
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//Prodcuct_name
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//Quality
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//price_one
                lvi.SubItems.Add("0");//chietkhau
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
            return numrow;
        }

        public String createBillID(String date)
        {
            String result = "";
            int index = spm.getBillCountToday(date);

            result = "BH" + date.Substring(2, 2) + date.Substring(5, 2) + date.Substring(8, 2) + (index + 1).ToString().PadLeft(3,'0');
            return result;
        }

        public void loadCbbGuess(ComboBox cbb)
        {
            string displayCBB = "person_id";
            string valueCBB = "person_id";
            DataTable dt = gu.getLstGuess();
            hc.loadComboBox(cbb, dt, displayCBB, valueCBB);
        }

        public string loadTenGuess(string id)
        {
            return gu.getNameGuess(id);
        }

        public void addNewItem(ListView lv, String billID, String productID, String productName, String productQuality, String productNote, String productPriceOne, String productChietKhau)
        {
            int index = lv.Items.Count;
            index++;
            ListViewItem lvi = lv.Items.Add(index.ToString());//index
                lvi.SubItems.Add(billID);
                lvi.SubItems.Add(productID);
                lvi.SubItems.Add(productName);
                lvi.SubItems.Add(productQuality);
                lvi.SubItems.Add(productNote);
                lvi.SubItems.Add(productPriceOne);
                lvi.SubItems.Add(productChietKhau);
            log.WriteLogSystem("Add item " + productID + " to Listview susscess");
        }

        public void updateItem(ListView lv, String billID, String productID, String productName, String productQuality, String productNote, String productPriceOne, String productChietKhau)
        {
            ListViewItem lvi = lv.SelectedItems[0];
                lvi.SubItems[1].Text = billID;
                lvi.SubItems[2].Text = productID;
                lvi.SubItems[3].Text = productName;
                lvi.SubItems[4].Text = productQuality;
                lvi.SubItems[5].Text = productNote;
                lvi.SubItems[6].Text = productPriceOne;
                lvi.SubItems[7].Text = productChietKhau;
            log.WriteLogSystem("Update item " + productID + " to Listview susscess");
        }

        public void addBill(ListView lv, String billId, String per_id, String date, String note, int typebill, int flag, String personName )
        {
            int intdex = 0;
            if (per_id.Equals("<Trống>"))
            {
                per_id = "000";
            }
            String tmpDate = date.Substring(6, 4) + "/" + date.Substring(3, 2) + "/" + date.Substring(0, 2);
            spm.addNewBill(billId, per_id, tmpDate, note, typebill, flag, personName);
            if(lv.Items.Count > 0)
            {
                ListViewItem lvi = lv.Items[intdex];
                /*lvi.SubItems[1].Text = billID;
                lvi.SubItems[2].Text = productID;
                lvi.SubItems[3].Text = productName;
                lvi.SubItems[4].Text = productQuality;
                lvi.SubItems[5].Text = productNote;
                lvi.SubItems[6].Text = productPriceOne;
                lvi.SubItems[7].Text = productChietKhau;*/
                spm.addBillDetail(lvi.SubItems[1].Text, lvi.SubItems[2].Text, Int32.Parse(lvi.SubItems[4].Text), Int32.Parse(lvi.SubItems[6].Text), lvi.SubItems[5].Text, Int32.Parse(lvi.SubItems[7].Text));
                intdex++;
            }
            log.WriteLogSystem("Add Bill with  " + intdex + " Item susscess");
        }

        public void deleteBill(String billId)
        {
            spm.deleteBill(billId);
            log.WriteLogSystem("deleteBill with  " + billId + " Item susscess");
            
        }

        public void deleteBillDetail(String billId)
        {
            spm.deleteBillDetail(billId);
            log.WriteLogSystem("deleteBillDetail with  " + billId + " Item susscess");

        }

        public int loadBillById(ListView lv, String billId)
        {
            DataTable dt = spm.loadBillbyId(billId);
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//billid
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//Prodcuct_id
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//Quality
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//price_one
                lvi.SubItems.Add("0");//chietkhau
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
            return numrow;
        }

        public Boolean checkquanlityfield(TextBox txtBanQuality, TextBox txtBanPriceOne, TextBox txtBanChietKhau, TextBox txtBanIdBill)
        {
            try { 
            if (txtBanQuality.Text.Equals("") || txtBanPriceOne.Text.Equals("") || txtBanChietKhau.Text.Equals("") || txtBanIdBill.Text.Equals(""))
            {
                    return false;
            }
            else
                return true;
            }catch (Exception e)
            {
                return false;
            }
        }

        public void updateBill(ListView lv, String billId, String productId, String date, String note, int typebill, int flag, String personName)
        {
            int intdex = 0;
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
                spm.updateBillDetail(lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text, lvi.SubItems[4].Text, lvi.SubItems[5].Text, lvi.SubItems[6].Text,lvi.SubItems[7].Text);
                intdex++;
            }
            log.WriteLogSystem("Add Bill with  " + intdex + " Item susscess");
        }
    }
}

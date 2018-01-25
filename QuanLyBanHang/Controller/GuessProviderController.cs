using QuanLyBanHang.Content;
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
    class GuessProviderController
    {
        //LOG 
        log_error log = new log_error();
        Message_ct me = new Message_ct();
        //khai bao model 
        guess_provider gp = new guess_provider();
        public int loadLstGuessProvider(ListView lv)
        {
            DataTable dt = gp.getLstGuessProvider();
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id 
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//ho va ten 
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//dia chi 
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//sdt
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//so lan giao dich
                lvi.SubItems.Add(dt.Rows[i][6].ToString());// so lan giao dich gan nhat
                lvi.SubItems.Add(dt.Rows[i][7].ToString());// loai giao dich
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
            return numrow;
        }
        public int loadLstBillByDateByType(ListView lv,int type)
        {
            DataTable dt = gp.getLstGuessProviderByType(type);
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id 
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//ho va ten 
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//dia chi 
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//sdt
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//so lan giao dich
                lvi.SubItems.Add(dt.Rows[i][6].ToString());// so lan giao dich gan nhat
                lvi.SubItems.Add(dt.Rows[i][7].ToString());// loai giao dich
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
            return numrow;
        }
        public int loadLstGuessProviderByKey(ListView lv, string key)
        {
            DataTable dt = gp.getLstGuessProviderByKey(key);
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id 
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//ho va ten 
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//dia chi 
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//sdt
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//so lan giao dich
                lvi.SubItems.Add(dt.Rows[i][6].ToString());// so lan giao dich gan nhat
                lvi.SubItems.Add(dt.Rows[i][7].ToString());// loai giao dich
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
            return numrow;
        }
        public int loadLstGuessProviderByKeyType(ListView lv, string key,int type)
        {
            DataTable dt = gp.getLstGuessProviderByKeyType(key,type);
            lv.Items.Clear();
            int numrow = dt.Rows.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id 
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//ho va ten 
                lvi.SubItems.Add(dt.Rows[i][3].ToString());//dia chi 
                lvi.SubItems.Add(dt.Rows[i][4].ToString());//sdt
                lvi.SubItems.Add(dt.Rows[i][5].ToString());//so lan giao dich
                lvi.SubItems.Add(dt.Rows[i][6].ToString());// so lan giao dich gan nhat
                lvi.SubItems.Add(dt.Rows[i][7].ToString());// loai giao dich
            }
            log.WriteLogDatabase("Có " + numrow + " dòng data");
            return numrow;
        }
        public bool delGuessProviderById(string id)
        {
            bool check = false;
            if (gp.delGuessProviderById(id) == true)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public string loadItemLstGuessProvider_Click(ListView lv,TextBox txtGuessID, TextBox txtGuessName, TextBox txtGuessSDT, TextBox txtGuessAddress, ComboBox cbbGuessType)
        {
            txtGuessID.Text = lv.SelectedItems[0].SubItems[1].Text.ToString();
            txtGuessName.Text = lv.SelectedItems[0].SubItems[2].Text.ToString();
            txtGuessSDT.Text = lv.SelectedItems[0].SubItems[4].Text.ToString();
            txtGuessAddress.Text = lv.SelectedItems[0].SubItems[3].Text.ToString();
            if(lv.SelectedItems[0].SubItems[7].Text.ToString().Equals("Khách hàng"))
            {
                cbbGuessType.SelectedIndex = 0;
            }
            if (lv.SelectedItems[0].SubItems[7].Text.ToString().Equals("Nhà cung cấp"))
            {
                cbbGuessType.SelectedIndex = 1;
            }
            return lv.SelectedItems[0].SubItems[1].Text.ToString(); 
        }
        public void insGuessProvider(string id, string name, string address, string phone, int type)
        {
            if (gp.insGuessPeoviderById(id,name,address,phone,type) == true)
            {
                MessageBox.Show(me.MES_GE_02);
            }
            else
            {
                MessageBox.Show(me.MES_GE_03);
            }
        }
        public void uptGuessPeoviderById(string id, string name, string address, string phone, int type)
        {
            if (gp.uptGuessPeoviderById(id, name, address, phone, type) == true)
            {
                MessageBox.Show(me.MES_GE_04);
            }
            else
            {
                MessageBox.Show(me.MES_GE_05);
            }
        }
        
        public bool checkGuessProviderExists(string id)
        {
            return gp.checkGuessProviderExists(id);
        }
        public bool checkAllTxtEmpty(string txtGuessID, string txtGuessName, string txtGuessAddress, string txtGuessSDT, string cbbGuessType)
        {
            bool check = true; 
            if(txtGuessID.Trim() != "" || txtGuessName.Trim() != "" || txtGuessAddress.Trim() != "" || txtGuessSDT.Trim() != "" || cbbGuessType.Trim() != "")
            {
                check = false;
            }
            return check;
        }
    }
}

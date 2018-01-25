using QuanLyBanHang.Retreive;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Controller
{
    class ctrl_Kho
    {
        
        retrieve pro = new retrieve();
        public void loadKho(ListView lvkho)
        {
            DataTable dt = pro.getAllProduct();
            lvkho.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lvkho.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//name product
                lvi.SubItems.Add(dt.Rows[i][3].ToString());// in price
                lvi.SubItems.Add(dt.Rows[i][4].ToString());// out price
                lvi.SubItems.Add(dt.Rows[i][5].ToString());// quantity
                lvi.SubItems.Add(dt.Rows[i][6].ToString());// unit
                lvi.SubItems.Add(dt.Rows[i][7].ToString());// cate
                lvi.SubItems.Add(dt.Rows[i][8].ToString());// modify 
                lvi.SubItems.Add(dt.Rows[i][9].ToString());// brand
                lvi.SubItems.Add(dt.Rows[i][10].ToString());// size
                lvi.SubItems.Add(dt.Rows[i][11].ToString());
                lvi.SubItems.Add(dt.Rows[i][12].ToString());
                lvi.SubItems.Add(dt.Rows[i][13].ToString());
            }
        }
        public void loadKhoSearch(ListView lvKho,string key)
        {
            DataTable dt = pro.getAllProductById(key);
            lvKho.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lvKho.Items.Add(dt.Rows[i][0].ToString());//index
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//name product
                lvi.SubItems.Add(dt.Rows[i][3].ToString());// in price
                lvi.SubItems.Add(dt.Rows[i][4].ToString());// out price
                lvi.SubItems.Add(dt.Rows[i][5].ToString());// quantity
                lvi.SubItems.Add(dt.Rows[i][6].ToString());// unit
                lvi.SubItems.Add(dt.Rows[i][7].ToString());// cate
                lvi.SubItems.Add(dt.Rows[i][8].ToString());// modify 
                lvi.SubItems.Add(dt.Rows[i][9].ToString());// brand
                lvi.SubItems.Add(dt.Rows[i][10].ToString());// size
            }
        }
       
    }
}

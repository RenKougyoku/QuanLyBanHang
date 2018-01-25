using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Controller
{
    class HamChung
    {
        public void loadListView(DataTable dt,ListView lv)
        {
            lv.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
                lvi.SubItems.Add(dt.Rows[i][6].ToString());
                lvi.SubItems.Add(dt.Rows[i][7].ToString());
                lvi.SubItems.Add(dt.Rows[i][8].ToString());
                lvi.SubItems.Add(dt.Rows[i][9].ToString());
                lvi.SubItems.Add(dt.Rows[i][10].ToString());        
                lvi.SubItems.Add(dt.Rows[i][11].ToString());
                lvi.SubItems.Add(dt.Rows[i][12].ToString());
                lvi.SubItems.Add(dt.Rows[i][13].ToString());
                lvi.SubItems.Add(dt.Rows[i][14].ToString());
                lvi.SubItems.Add(dt.Rows[i][15].ToString());
                lvi.SubItems.Add(dt.Rows[i][16].ToString());
                lvi.SubItems.Add(dt.Rows[i][17].ToString());
            }
        }
        public int DialogYesNo(string message, string title)
        {
            int result = 0;
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                result = 1;
            }
            else if (dialogResult == DialogResult.No)
            {
                result = 0;
            }
            return result;
        }
        public void loadComboBox(ComboBox cbb, DataTable dt, string display, string value)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = display;
            cbb.ValueMember = value;
        }
    }
}

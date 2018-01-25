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

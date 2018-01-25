using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.View
{
    class frmProductSelling
    {
            public void clearTextBox(List<TextBox> lst)
            {
                foreach (TextBox tmp in lst)
                    tmp.Clear();
            }

            public void clearListView(List<ListView> lst)
            {
                foreach (ListView tmp in lst)
                    tmp.Items.Clear();
            }

            public void clearTextBoxandListView(List<TextBox> lstTxt, List<ListView> lstLv)
            {
                clearTextBox(lstTxt);
                clearListView(lstLv);
            }
        }
}

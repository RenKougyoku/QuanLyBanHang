using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.View
{
    class frmNhaphang
    {
        public void loadBtnThemVao(TextBox txtNhapMH, TextBox txtNhapTH, TextBox txtNhapSL, TextBox txtNhap1Price)
        {
            txtNhapMH.Text = "";
            txtNhapTH.Text = "";
            txtNhapSL.Text = "";
            txtNhap1Price.Text = "";
        }
        public void FirstLoad(TextBox txtNhapMHD
                                    , ComboBox cbbNhapNCC
                                    , TextBox txtNhapDate
                                    , TextBox txtNhapTNCC
                                    , TextBox txtNhapND
                                    , TextBox txtNhapMH
                                    , TextBox txtNhapSL
                                    , TextBox txtNhapTH
                                    , TextBox txtNhap1Price
                                    , TextBox txtNhapGC
                                    , ListView lvNhapBillDetail)
        {
            txtNhapMHD.Text = "";
            txtNhapMHD.Enabled = true;
            cbbNhapNCC.SelectedIndex = cbbNhapNCC.FindStringExact("<Trống>") ;
            txtNhapDate.Text = "";
            txtNhapTNCC.Text = "";
            txtNhapND.Text = "";
            txtNhapMH.Text = "";
            txtNhapSL.Text = "";
            txtNhapTH.Text = "";
            txtNhap1Price.Text = "";
            txtNhapGC.Text = "";
            lvNhapBillDetail.Items.Clear();
        }
        public void itemLstProduct_click(TextBox txtNhapMH, TextBox txtNhapTH)
        {
            txtNhapMH.Enabled = false;
            txtNhapTH.Enabled = false;
        }

        public void loadNutHuy(TextBox txtNhapMHD, ComboBox cbbNhapNCC, TextBox txtNhapDate, TextBox txtNhapTNCC, TextBox txtNhapND, TextBox txtNhapMH, TextBox txtNhapTH, TextBox txtNhapSL, TextBox txtNhap1Price, TextBox txtNhapGC, ListView lvNhapBillDetail)
        {
            txtNhapMHD.Text = "";
            cbbNhapNCC.SelectedIndex = 0;
            txtNhapDate.Text = "";
            txtNhapTNCC.Text = "";
            txtNhapND.Text = "";
            txtNhapMH.Text = "";
            txtNhapTH.Text = "";
            txtNhapSL.Text = "";
            txtNhap1Price.Text = "";
            txtNhapGC.Text = "";
            lvNhapBillDetail.Items.Clear();
        }
    }
}

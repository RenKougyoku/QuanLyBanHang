using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.View
{
    class frmKhohang
    {
        public void btnKhoImClick(TextBox txtKhoMH
            , ComboBox cbbKhoLH
            , TextBox txtKhoSL
            , ComboBox cbbKhoDV
            , TextBox txtKhoSize
            , TextBox txtKhoTH
            , TextBox txtKhoInPr
            , TextBox txtKhoOPr
            , TextBox txtKhoBrand
            , TextBox txtKhoMT)
        {
            txtKhoMH.Enabled = true;
            txtKhoMH.Text = "";
            cbbKhoLH.SelectedValue = 0;
            txtKhoSL.Text = "";
            cbbKhoDV.SelectedValue = 0;
            txtKhoSize.Text = "";
            txtKhoTH.Text = "";
            txtKhoInPr.Text = "";
            txtKhoOPr.Text = "";
            txtKhoBrand.Text = "";
            txtKhoMT.Text = "";
        }
        public void btnKhoDelClick(TextBox txtKhoMH
            , ComboBox cbbKhoLH
            , TextBox txtKhoSL
            , ComboBox cbbKhoDV
            , TextBox txtKhoSize
            , TextBox txtKhoTH
            , TextBox txtKhoInPr
            , TextBox txtKhoOPr
            , TextBox txtKhoBrand
            , TextBox txtKhoMT)
        {
            txtKhoMH.Enabled = false;
            txtKhoMH.Text = "";
            cbbKhoLH.SelectedValue = 0;
            txtKhoSL.Text = "";
            cbbKhoDV.SelectedValue = 0;
            txtKhoSize.Text = "";
            txtKhoTH.Text = "";
            txtKhoInPr.Text = "";
            txtKhoOPr.Text = "";
            txtKhoBrand.Text = "";
            txtKhoMT.Text = "";
        }

    }
}

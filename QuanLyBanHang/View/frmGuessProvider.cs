using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.View
{
    class frmGuessProvider
    {
        
        public void FirstLoad(ComboBox cbbGP
            , TextBox txtGuessID
            , TextBox txtGuessName
            , TextBox txtGuessSDT
            , TextBox txtGuessAddress
            , ComboBox cbbGuessType
            , Button btnGuessDel
            , Button btnGuessSave
            , Button btnGuessCancel)
        {
            cbbGP.SelectedIndex = 0;
            cbbGuessType.SelectedIndex = -1;
            txtGuessID.Enabled = true;
            //txtGuessName.Enabled = false;
            //txtGuessSDT.Enabled = false;
            //txtGuessAddress.Enabled = false;
            txtGuessID.Text = "";
            txtGuessName.Text = "";
            txtGuessAddress.Text = "";
            txtGuessSDT.Text = "";

            //btnGuessDel.Enabled = false;
            //btnGuessSave.Enabled = false;
            //btnGuessCancel.Enabled = true;
        }
        public void frmbtnGuessAdd_click(ComboBox cbbGP
            , TextBox txtGuessID
            , TextBox txtGuessName
            , TextBox txtGuessSDT
            , TextBox txtGuessAddress
            , ComboBox cbbGuessType
            , Button btnGuessAdd
            , Button btnGuessDel
            , Button btnGuessSave
            , Button btnGuessCancel)
        {
            txtGuessID.Enabled = true;
            txtGuessName.Enabled = true;
            txtGuessSDT.Enabled = true;
            txtGuessAddress.Enabled = true;

            txtGuessID.Text = "";
            txtGuessName.Text = "";
            txtGuessSDT.Text = "";
            txtGuessAddress.Text = "";
            cbbGuessType.Enabled = true;
            btnGuessAdd.Enabled = false;
            btnGuessDel.Enabled = false;
            btnGuessSave.Enabled = true;
            btnGuessCancel.Enabled = true;
        }
        public void frmbtnGuessDel_Click(ComboBox cbbGP
              , TextBox txtGuessID
              , TextBox txtGuessName
              , TextBox txtGuessSDT
              , TextBox txtGuessAddress
              , ComboBox cbbGuessType
              , Button btnGuessAdd
              , Button btnGuessDel
              , Button btnGuessSave
              , Button btnGuessCancel)
        {
            txtGuessID.Enabled = false;
            txtGuessName.Enabled = false;
            txtGuessSDT.Enabled = false;
            txtGuessAddress.Enabled = false;
            txtGuessID.Text = "";
            txtGuessName.Text = "";
            txtGuessSDT.Text = "";
            txtGuessAddress.Text = "";
            cbbGuessType.Enabled = false;
            cbbGuessType.Text = "";

            btnGuessAdd.Enabled = true;
            btnGuessDel.Enabled = false;
            btnGuessSave.Enabled = false;
            btnGuessCancel.Enabled = true;
            MessageBox.Show("Đã xóa!");
        }
        public void frmbtnGuessSave_Click(ComboBox cbbGP
              , TextBox txtGuessID
              , TextBox txtGuessName
              , TextBox txtGuessSDT
              , TextBox txtGuessAddress
              , ComboBox cbbGuessType
              , Button btnGuessAdd
              , Button btnGuessDel
              , Button btnGuessSave
              , Button btnGuessCancel)
        {

            txtGuessID.Enabled = false;
            txtGuessName.Enabled = false;
            txtGuessSDT.Enabled = false;
            txtGuessAddress.Enabled = false;
            cbbGuessType.Enabled = false;
            txtGuessID.Text = "";
            txtGuessName.Text = "";
            txtGuessSDT.Text = "";
            txtGuessAddress.Text = "";
            cbbGuessType.Text = "";
            btnGuessAdd.Enabled = true;
            btnGuessDel.Enabled = false;
            btnGuessSave.Enabled = false;
            btnGuessCancel.Enabled = false;
            MessageBox.Show("Thành công!");
        }
        public void frmitemListGuessProvider_Click( TextBox txtGuessID
              , TextBox txtGuessName
              , TextBox txtGuessSDT
              , TextBox txtGuessAddress
              , ComboBox cbbGuessType
              , Button btnGuessAdd
              , Button btnGuessDel
              , Button btnGuessSave
              , Button btnGuessCancel)
        {
            txtGuessID.Enabled = false;
        }

    }
}

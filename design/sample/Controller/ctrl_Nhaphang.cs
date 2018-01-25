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
    class ctrl_Nhaphang
    {
        // load category nhap hang
        public void loadCategory()
        {
            //DataTable dt = pro.getAllCategory();
            //
        }
        public void loadComboBox(ComboBox cbb, DataTable dt, string display,string value)
        {
            cbb.DataSource = dt;
            cbb.DisplayMember = display;
            cbb.ValueMember = value;
        }
        
        //load date nhap hang
        public void loadDate(TextBox txtDateImport)
        {
            var dd = DateTime.Now.Day;
            var mth = DateTime.Now.Month;
            var yy = DateTime.Now.Year;
            string theDate = yy + "-" + mth + "-" + dd;
            var hour = DateTime.Now.Hour;
            var min = DateTime.Now.Minute;
            var se = DateTime.Now.Second;
            txtDateImport.Text = theDate.ToString() + " " + hour + ":" + min + ":" + se;
        }
        public void cbbNCC_Selected(ComboBox cbb,DataTable dt,TextBox tb)
        {
            string id = Convert.ToString(cbb.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                tb.Text = dt.Rows[0][1].ToString() + "-" + dt.Rows[0][4].ToString();
            }
        }
        public string getrealDatetime()
        {
            var dd = DateTime.Now.Day;
            var mth = DateTime.Now.Month;
            var yy = DateTime.Now.Year;
            string theDate = yy + "-" + mth + "-" + dd;
            var hour = DateTime.Now.Hour;
            var min = DateTime.Now.Minute;
            var se = DateTime.Now.Second;
            string datetime = theDate.ToString() + " " + hour + ":" + min + ":" + se;
            return datetime;
        }
        //done
        public void loadBillInList(DataTable dt, ListView lv)
        {
            lv.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//content
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
            }
        }
        public void loadDTBillInList(DataTable dt, ListView lv,int id)
        {
            lv.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lv.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());//id
                lvi.SubItems.Add(dt.Rows[i][2].ToString());//content
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
        }
        public void cbbMaHang_Selected(DataTable dt,ComboBox cbb,TextBox tb)
        {
            string id = Convert.ToString(cbb.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                tb.Text = dt.Rows[0][1].ToString();
            }
        }
        /*
        private void btnDanhsachHD_Click(object sender, EventArgs e)
        {
            loadBillInList();
        }
        private void btnDelNhaphang_Click(object sender, EventArgs e)
        {
            if (idhd != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Xóa hóa đơn: " + idhd.ToString() + "?", "Thông báo!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dbnhap.delBillIn(idhd);
                    idhd = 0;
                    loadBillInList();
                    loadmaHd();
                    MessageBox.Show("Đã xóa!");
                }
                else
                {
                    idhd = 0;
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn để xóa!");
            }
        }*/
        /*
        private void lvBillIn_Click(object sender, EventArgs e)
        {
            idhd = Convert.ToInt32(lvBillIn.SelectedItems[0].SubItems[1].Text.ToString());
            cbbMahd.Text = idhd.ToString();
            txtDateImport.Text = lvBillIn.SelectedItems[0].SubItems[2].Text.ToString();
            cbbNCC.Text = lvBillIn.SelectedItems[0].SubItems[3].Text.ToString();
            loadDTBillInList(idhd);
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            //case available product
            string mahang = Convert.ToString(cbbMaHang.Text.ToString());
            //co ma hoa don roi
            if (idhd != 0)
            {
                //cbb ma hang co luon
                if (mahang.ToString().Length > 0)
                {
                    if (txtQuantityNhap.Text.ToString().Length > 0)
                    {
                        if (pro.checkProExists(mahang) == false)
                        {
                            DialogResult dialogResult = MessageBox.Show(mahang + " chưa có trong kho.\nBạn muốn thêm mới hàng hóa này ?", "Thông báo!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                bool result = dbpro.addProduct(mahang, txtTenhang.Text.ToString(), 0, 0, 0, "", 1, 1);
                                if (result == true)
                                {
                                    dbnhap.addPro_toBillIn(idhd, mahang, Convert.ToInt32(txtQuantityNhap.Text.ToString()), "");
                                    MessageBox.Show("Thêm hàng thành công!");
                                }
                            }
                            else
                            {
                                idhd = 0;
                            }
                        }
                        else
                        {
                            //note co 
                            if (txtNoteDT.Text.ToString().Length > 0)
                            {
                                dbnhap.addPro_toBillIn(idhd, mahang, Convert.ToInt32(txtQuantityNhap.Text.ToString()), txtNoteDT.Text.ToString());
                                MessageBox.Show("Thêm hàng thành công!");
                            }
                            //note ko 
                            else
                            {
                                dbnhap.addPro_toBillIn(idhd, mahang, Convert.ToInt32(txtQuantityNhap.Text.ToString()), "");
                                MessageBox.Show("Thêm hàng thành công!");
                            }
                            loadDTBillInList(idhd);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập số lượng hàng!");
                    }

                }
                //case 
                else
                {

                    MessageBox.Show("Không có mã hàng");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn nhập hàng!");
            }
            //case new product 

        }
       
        */
    }
}

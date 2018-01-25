

using QuanLyBanHang.Content;
using QuanLyBanHang.Controller;
using QuanLyBanHang.Database;
using QuanLyBanHang.Log;
using QuanLyBanHang.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace QuanLyBanHang
{
    public partial class Form1 : Form
    {
        //LOG
        log_error lg_e = new log_error();
        //Content 
        Error ct_er = new Error();
        Message_ct ct_me = new Message_ct();
        Static stic = new Static();
        //Controller
        Homecontroller home = new Homecontroller();
        GuessProviderController gu_ctl = new GuessProviderController();
        HamChung hc = new HamChung();
        KhoController kho_ctl = new KhoController();
        NhaphangController nhap_ctl = new NhaphangController();
        //tam
        SellingProductController spc = new SellingProductController();
        frmProductSelling fps = new frmProductSelling();
        int flag = 0;
        //Static
        ScreenIndex scr = new ScreenIndex();
        //Using library
        Timer tm = new Timer();
        //View 
        frmGuessProvider gu_scr = new frmGuessProvider();
        frmKhohang kho_scr = new frmKhohang();
        frmNhaphang nhap_scr = new frmNhaphang();
        public Form1()
        {
            InitializeComponent();
        }
        private void tabBanhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabBanhang.SelectedIndex == 0)
            {
                loadFormHome();
            }
            if (tabBanhang.SelectedIndex == 1)
            {
                loadFormGuessProvider();
            }
            if (tabBanhang.SelectedIndex == 2)
            {
                loadFormNhaphang();
            }
            if (tabBanhang.SelectedIndex == 3)
            {
                loadFromSellingProduct();
            }
            if (tabBanhang.SelectedIndex == 4)
            {
                loadFormKhohang();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            clock();
            loadFormHome();
        }


        #region Load time 
        public void clock()
        {
            tm.Interval = 1000;
            tm.Tick += new EventHandler(this.tm_Tick);
            tm.Start();
        }
        public void tm_Tick(object sender, EventArgs e)
        {
            var da = DateTime.Now.DayOfWeek;
            var dd = DateTime.Now.Day;
            var mth = DateTime.Now.Month;
            var yy = DateTime.Now.Year;
            lbHello.Text = "Hôm nay là : " + convertDate(da.ToString()) + ", ngày " + dd.ToString() + ", tháng " + mth.ToString() + ", năm " + yy.ToString() + "";
            string hh = Convert.ToString(DateTime.Now.Hour);
            string mm = Convert.ToString(DateTime.Now.Minute);
            string ss = Convert.ToString(DateTime.Now.Second);
            if (hh.ToString().Length == 1)
            {
                hh = "0" + hh;
            }
            if (mm.ToString().Length == 1)
            {
                mm = "0" + mm;
            }
            if (ss.ToString().Length == 1)
            {
                ss = "0" + ss;
            }
            lbWatch.Text = hh.ToString() + ":" + mm.ToString() + ":" + ss.ToString();
        }
        public string convertDate(string eng_date)
        {
            string vn_date = "";
            if (eng_date.Equals("Monday"))
            {
                vn_date = "Thứ 2";
            }
            if (eng_date.Equals("Tuesday"))
            {
                vn_date = "Thứ 3";
            }
            if (eng_date.Equals("Wednesday"))
            {
                vn_date = "Thứ 4";
            }
            if (eng_date.Equals("Thursday"))
            {
                vn_date = "Thứ 5";
            }
            if (eng_date.Equals("Friday"))
            {
                vn_date = "Thứ 6";
            }
            if (eng_date.Equals("Saturday"))
            {
                vn_date = "Thứ 7";
            }
            if (eng_date.Equals("Sunday"))
            {
                vn_date = "Chủ nhật";
            }
            return vn_date;
        }
        // animation for text 
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lbHello.Left < gbCongviec.Width)
            {
                lbHello.Left = lbHello.Left + 5;
            }
            else
            {
                lbHello.Left = 0;
            }
        }
        #endregion Load time 
        #region HOME 
        private void loadFormHome()
        {
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            txtHomeSumHd.Text = Convert.ToString(home.loadLstBillByDate(lvHomeBill, date));
            home.loadLstProduct(lvHomeProduct);
        }

        private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            DateTime today = monthCalendar1.SelectionStart;
            string selectYear = Convert.ToString(today.Year);
            string selectMonth = Convert.ToString(today.Month);
            string selectDay = Convert.ToString(today.Day);
            if (selectMonth.Length == 1)
            {
                selectMonth = "0" + selectMonth;
            }
            if (selectDay.Length == 1)
            {
                selectDay = "0" + selectDay;
            }
            string selectDate = selectYear + "-" + selectMonth + "-" + selectDay;
            txtHomeSumHd.Text = Convert.ToString(home.loadLstBillByDate(lvHomeBill, selectDate));
        }

        private void btnHomeNhap_Click(object sender, EventArgs e)
        {
            tabBanhang.SelectedIndex = scr.indexTabNhaphang;
        }

        private void btnHomeBan_Click(object sender, EventArgs e)
        {
            tabBanhang.SelectedIndex = scr.indexTabBanhang;
        }

        private void btnHomeThongKe_Click(object sender, EventArgs e)
        {
            tabBanhang.SelectedIndex = scr.indexTabThongKe;
        }
        private void btnHomeKho_Click(object sender, EventArgs e)
        {
            tabBanhang.SelectedIndex = scr.indexTabKhohang;
        }
        private void btnHomeThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion HOME    
        #region Guess/Provider 
        public void loadFormGuessProvider()
        {
            gu_scr.FirstLoad(cbbGuessProvider, txtGuessID, txtGuessName, txtGuessSDT, txtGuessAddress, cbbGuessType, btnGuessDel, btnGuessSave, btnGuessCancel);
            gu_ctl.loadLstGuessProvider(lvGuessProvider);
        }
        private void btnGuessChange_Click(object sender, EventArgs e)
        {
            if (cbbGuessProvider.SelectedIndex == 0)
            {
                gu_ctl.loadLstGuessProvider(lvGuessProvider);
            }
            if (cbbGuessProvider.SelectedIndex == 1)
            {
                gu_ctl.loadLstBillByDateByType(lvGuessProvider, 1);
            }
            if (cbbGuessProvider.SelectedIndex == 2)
            {
                gu_ctl.loadLstBillByDateByType(lvGuessProvider, 2);
            }
        }
        private void btnKHTimKiem_Click(object sender, EventArgs e)
        {
            if (txtKHTimKiem.Text.ToString().Length > 0)
            {
                if (cbbGuessProvider.SelectedIndex == 0)
                {
                    gu_ctl.loadLstGuessProviderByKey(lvGuessProvider, txtKHTimKiem.Text.ToString());
                }
                if (cbbGuessProvider.SelectedIndex == 1)
                {
                    gu_ctl.loadLstGuessProviderByKeyType(lvGuessProvider, txtKHTimKiem.Text.ToString(), 1);
                }
                if (cbbGuessProvider.SelectedIndex == 2)
                {
                    gu_ctl.loadLstGuessProviderByKeyType(lvGuessProvider, txtKHTimKiem.Text.ToString(), 2);
                }
            }
            else
            {
                gu_ctl.loadLstGuessProvider(lvGuessProvider);
            }
        }
        private void txtKHTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtKHTimKiem.Text.ToString().Length == 0)
            {
                if (cbbGuessProvider.SelectedIndex == 0)
                {
                    gu_ctl.loadLstGuessProvider(lvGuessProvider);
                }
                if (cbbGuessProvider.SelectedIndex == 1)
                {
                    gu_ctl.loadLstBillByDateByType(lvGuessProvider, 1);
                }
                if (cbbGuessProvider.SelectedIndex == 2)
                {
                    gu_ctl.loadLstBillByDateByType(lvGuessProvider, 2);
                }
            }
        }
        private void btnGuessAdd_Click(object sender, EventArgs e)
        {
            string guess_id = txtGuessID.Text.ToString();
            string guess_name = txtGuessName.Text.ToString();
            string guess_add = txtGuessAddress.Text.ToString();
            string guess_sdt = txtGuessSDT.Text.ToString();
            string cbbType = cbbGuessType.Text.ToString();
            bool checkEmpty = gu_ctl.checkAllTxtEmpty(guess_id, guess_name, guess_add, guess_sdt, cbbType);
            if(checkEmpty == true)
            {
                scr.insGuessStatus = 1;
                scr.idGuessProviderSelected = null;
            }
            else
            {
                if(hc.DialogYesNo(ct_me.MES_CANCEL,ct_me.MES_00) == 1)
                {
                    gu_scr.FirstLoad(cbbGuessProvider, txtGuessID, txtGuessName, txtGuessSDT, txtGuessAddress, cbbGuessType, btnGuessDel, btnGuessSave, btnGuessCancel);
                    scr.insGuessStatus = 1;
                    scr.idGuessProviderSelected = null;
                }
            }
        }
        private void btnGuessDel_Click(object sender, EventArgs e)
        {
            if(scr.idGuessProviderSelected == null)
            {
                MessageBox.Show(ct_me.MES_GE_00);
            }
            else
            {
                if (hc.DialogYesNo("Xóa người dùng này?", "Thông báo") == 1)
                {
                    if (gu_ctl.delGuessProviderById(scr.idGuessProviderSelected) == true)
                    {
                        gu_ctl.loadLstGuessProvider(lvGuessProvider);
                        scr.insGuessStatus = 0;
                        gu_scr.FirstLoad(cbbGuessProvider, txtGuessID, txtGuessName, txtGuessSDT, txtGuessAddress, cbbGuessType, btnGuessDel, btnGuessSave, btnGuessCancel);
                        scr.idGuessProviderSelected = null;
                    }
                    else
                    {
                        MessageBox.Show(ct_er.ERR_00);
                    }
                }
            }
        }
        private void btnGuessSave_Click(object sender, EventArgs e)
        {
            string guess_id = txtGuessID.Text.ToString();
            string guess_name = txtGuessName.Text.ToString();
            string guess_address = txtGuessAddress.Text.ToString();
            string guess_phone = txtGuessSDT.Text.ToString();
            int guess_type = 0;
            //insert 
            if (scr.insGuessStatus == 1)
            {
                if (guess_id.Trim() == "")
                {
                    MessageBox.Show(ct_er.ERR_01);
                }
                else
                {
                    if (gu_ctl.checkGuessProviderExists(guess_id) == true)
                    {
                        MessageBox.Show(ct_er.ERR_02);
                    }
                    else
                    {
                        if (cbbGuessType.Text.ToString().Trim() == "")
                        {
                            MessageBox.Show(ct_me.MES_GE_01);
                        }
                        else
                        {
                            if (cbbGuessType.SelectedIndex == 0)
                            {
                                guess_type = 1;
                            }
                            if (cbbGuessType.SelectedIndex == 1)
                            {
                                guess_type = 2;
                            }
                            gu_ctl.insGuessProvider(guess_id, guess_name, guess_address, guess_phone, guess_type);
                            scr.insGuessStatus = 1;
                            gu_ctl.loadLstGuessProvider(lvGuessProvider);
                            gu_scr.FirstLoad(cbbGuessProvider, txtGuessID, txtGuessName, txtGuessSDT, txtGuessAddress, cbbGuessType, btnGuessDel, btnGuessSave, btnGuessCancel);
                        }
                    }
                }
            }
            //update
            else
            {
                if(scr.idGuessProviderSelected == null)
                {
                    MessageBox.Show(ct_me.MES_GE_06);
                }
                else
                {
                    if (cbbGuessType.SelectedIndex == 0)
                    {
                        guess_type = 1;
                    }
                    if (cbbGuessType.SelectedIndex == 1)
                    {
                        guess_type = 2;
                    }
                    gu_ctl.uptGuessPeoviderById(guess_id, guess_name, guess_address, guess_phone, guess_type);
                    scr.insGuessStatus = 1;
                    gu_ctl.loadLstGuessProvider(lvGuessProvider);
                    gu_scr.FirstLoad(cbbGuessProvider, txtGuessID, txtGuessName, txtGuessSDT, txtGuessAddress, cbbGuessType, btnGuessDel, btnGuessSave, btnGuessCancel);
                    scr.idGuessProviderSelected = null;
                }
               
            }
        }
        private void btnGuessCancel_Click(object sender, EventArgs e)
        {
            string guess_id = txtGuessID.Text.ToString();
            string guess_name = txtGuessName.Text.ToString();
            string guess_add = txtGuessAddress.Text.ToString();
            string guess_sdt = txtGuessSDT.Text.ToString();
            string cbbType = cbbGuessType.Text.ToString();
            bool checkEmpty = gu_ctl.checkAllTxtEmpty(guess_id, guess_name, guess_add, guess_sdt, cbbType);
            if (checkEmpty == true)
            {
                if (hc.DialogYesNo(ct_me.MES_GE_07, ct_me.MES_00) == 1)
                {
                    tabBanhang.SelectedIndex = scr.indexTabHome;
                }
            }
            else
            {
                if (hc.DialogYesNo(ct_me.MES_CANCEL, ct_me.MES_00) == 1)
                {
                    gu_scr.FirstLoad(cbbGuessProvider, txtGuessID, txtGuessName, txtGuessSDT, txtGuessAddress, cbbGuessType, btnGuessDel, btnGuessSave, btnGuessCancel);
                    scr.insGuessStatus = 1;
                    scr.idGuessProviderSelected = null;
                }
            }
        }
        private void lvGuessProvider_Click(object sender, EventArgs e)
        {
            scr.insGuessStatus = 2;
            gu_scr.frmitemListGuessProvider_Click(txtGuessID, txtGuessName, txtGuessSDT, txtGuessAddress, cbbGuessType, btnGuessAdd, btnGuessDel, btnGuessSave, btnGuessCancel);
            scr.idGuessProviderSelected = gu_ctl.loadItemLstGuessProvider_Click(lvGuessProvider, txtGuessID, txtGuessName, txtGuessSDT, txtGuessAddress, cbbGuessType);
        }
        private void txtGuessSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion Guess/Provider 

        #region NHAP HANG
        public void loadFormNhaphang()
        {
            loadLstHDNhap();
            //load combobox Nha cung cap 
            nhap_ctl.loadCbbNhaCC(cbbNhapNCC);
            loadLstNhapProduct();
        }
        public void loadLstHDNhap()
        {
            nhap_ctl.loadLstBillNhaphang(lvNhapHD);
        }
        public void loadLstNhapProduct()
        {
            nhap_ctl.loadLstProduct(lvNhapPro);
        }
        public void loadTxtDate(string date, string year, string month, string day)
        {
            var hour = DateTime.Now.Hour;
            var min = DateTime.Now.Minute;
            var se = DateTime.Now.Second;
            txtNhapDate.Text = day + "/" + month + "/" + year + " " + hour + ":" + min + ":" + se;
            autoLoadIdBill(date);
        }
        public void autoLoadIdBill(string datetime)
        {
            string highbill = (nhap_ctl.countBillInDate(datetime) + 1).ToString();
            if (highbill.ToString().Length == 1)
            {
                highbill = "00" + highbill;
            }
            if (highbill.ToString().Length == 2)
            {
                highbill = "0" + highbill;
            }
            string year = (dtpkNhap.Value.ToString("yyyy")).Substring(2, 2);
            string month = dtpkNhap.Value.ToString("MM");
            string day = dtpkNhap.Value.ToString("dd");
            string bill_id = "NH" + year + month + day + highbill;
            txtNhapMHD.Text = bill_id;
        }
        private void lvNhapHD_Click(object sender, EventArgs e)
        {
            scr.sttInsBillNhap = 2;
            scr.idBillNhapSelected = nhap_ctl.itemLstBillNhaphang_click(lvNhapHD, txtNhapMHD, cbbNhapNCC, txtNhapTNCC, txtNhapND, txtNhapDate);
        }
        private void cbbNhapNCC_DropDownClosed(object sender, EventArgs e)
        {
            var cbbNCC = cbbNhapNCC.SelectedValue.ToString();
            if (cbbNCC.Equals("<Trống>"))
            {
                txtNhapTNCC.Enabled = true;
                txtNhapTNCC.Text = "";
            }
            else
            {
                txtNhapTNCC.Text = nhap_ctl.loadTenNcc(cbbNCC);
                txtNhapTNCC.Enabled = false;
            }
        }
        private void btnNhapCreate_Click(object sender, EventArgs e)
        {
            if(scr.sttInsBillNhap == 1 && scr.idBillNhapSelected == null)
            {
                loadTxtDate(stic.getCurrentDay().ElementAt(0).ToString()
                    , stic.getCurrentDay().ElementAt(1).ToString()
                    , stic.getCurrentDay().ElementAt(2).ToString()
                    , stic.getCurrentDay().ElementAt(3).ToString());
                cbbNhapNCC.SelectedIndex = cbbNhapNCC.FindStringExact("<Trống>");
                txtNhapTNCC.Text = "";
                txtNhapND.Text = "";
                MessageBox.Show("Đã tạo hóa đơn: "+txtNhapMHD.Text.ToString());
            }
            else
            {
                if(hc.DialogYesNo(ct_me.MES_CANCEL,ct_me.MES_08) == 1)
                {
                    nhap_scr.FirstLoad(txtNhapMHD
                                    ,cbbNhapNCC
                                    ,txtNhapDate
                                    ,txtNhapTNCC
                                    ,txtNhapND
                                    ,txtNhapMH
                                    ,txtNhapSL
                                    ,txtNhapTH
                                    ,txtNhap1Price
                                    ,txtNhapGC
                                    ,lvNhapBillDetail);
                    scr.sttInsBillNhap = 1;
                    scr.idBillNhapSelected = null;
                }
            }
        }
        private void dtpkNhap_ValueChanged(object sender, EventArgs e)
        {
            string date = dtpkNhap.Value.ToString("yyyy-MM-dd");
            string year = dtpkNhap.Value.ToString("yyyy");
            string month = dtpkNhap.Value.ToString("MM");
            string day = dtpkNhap.Value.ToString("dd");
            loadTxtDate(date, year, month, day);
        }
        private void lvNhapPro_Click(object sender, EventArgs e)
        {
            nhap_ctl.itemLstProduct_click(lvNhapPro, txtNhapMH, txtNhapSL, txtNhapTH, txtNhap1Price);
            nhap_scr.itemLstProduct_click(txtNhapMH, txtNhapTH);
        }
        private void btnNhapDAdd_Click(object sender, EventArgs e)
        {
            int index = lvNhapBillDetail.Items.Count;
            index++;
            string pro_id = txtNhapMH.Text.ToString();
            string soluong = txtNhapSL.Text.ToString();
            string tenhang = txtNhapTH.Text.ToString();
            string gia = txtNhap1Price.Text.ToString();
            string bill_id = txtNhapMHD.Text.ToString();
            if(pro_id.Length == 0)
            {
                MessageBox.Show(ct_me.MES_013);
            }
            else
            {
                if (soluong.Length == 0)
                {
                    MessageBox.Show(ct_me.MES_09);
                }
                else
                {
                    if (gia.Length == 0)
                    {
                        MessageBox.Show(ct_me.MES_010);
                    }
                    else
                    {
                        string[] data = { index.ToString(), bill_id, pro_id, tenhang, gia, soluong };
                        nhap_ctl.loadLstDetailBill(lvNhapBillDetail, data);
                        nhap_scr.loadBtnThemVao(txtNhapMH, txtNhapTH, txtNhapSL, txtNhap1Price);
                    }
                }
                
            }
           
        }
        private void lvNhapBillDetail_Click(object sender, EventArgs e)
        {
            //temp
            var text = lvNhapBillDetail.SelectedItems[0].SubItems[1].Text.ToString();
            MessageBox.Show(text);
            //in database
        }
        private void btnNhapSave_Click(object sender, EventArgs e)
        {
            string bill_id = txtNhapMHD.Text.ToString();
            string bill_date = txtNhapDate.Text.ToString();
            string per_id = cbbNhapNCC.SelectedValue.ToString();
            if (per_id.Equals("<Trống>"))
            {
                per_id = "000";
            }
            string per_name = txtNhapTNCC.Text.ToString();
            string note = txtNhapND.Text.ToString();
            string pro_id = txtNhapMH.Text.ToString();
            if(bill_id.Length == 0)
            {
                MessageBox.Show(ct_me.MES_011);
            }
            if(bill_date.Length == 0)
            {
                MessageBox.Show(ct_me.MES_012);
            }
            else
            {
                bill_date = bill_date.Substring(0, 10);
                try
                { 
                    nhap_ctl.addBill(lsvBanDBill, bill_id, per_id, bill_date, note, 1, 0, per_name);
                    MessageBox.Show(ct_me.SUS_00);
                    nhap_scr.loadNutHuy(txtNhapMHD, cbbNhapNCC, txtNhapDate, txtNhapTNCC, txtNhapND, txtNhapMH, txtNhapTH, txtNhapSL, txtNhap1Price, txtNhapGC, lvNhapBillDetail);
                    loadLstHDNhap();
                }
                catch (Exception)
                {
                    MessageBox.Show(ct_er.ERR_00);
                }
            }
            //clearFormBan();
        }

        private void btnNhapBack_Click(object sender, EventArgs e)
        {
            nhap_scr.loadNutHuy(txtNhapMHD, cbbNhapNCC, txtNhapDate, txtNhapTNCC, txtNhapND, txtNhapMH, txtNhapTH, txtNhapSL, txtNhap1Price, txtNhapGC, lvNhapBillDetail);
        }
        #endregion NHAP HANG
        #region KHO HANG 
        public void loadFormKhohang()
        {
            loadLstProduct();
            //load all category
            kho_ctl.loadCategory(cbbKhoLH);
            //load all unit
            kho_ctl.loadUnit(cbbKhoDV);
        }
        public void loadLstProduct()
        {
            kho_ctl.loadKhoProduct(lvKho);
        }
        private void btnSeKho_Click_1(object sender, EventArgs e)
        {
            if (txtSeKho.Text.ToString().Length > 0)
            {
                kho_ctl.loadKhoProductByKey(lvKho, txtSeKho.Text.ToString());
            }
        }
        private void txtSeKho_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSeKho.Text.ToString().Length == 0)
            {
                kho_ctl.loadKhoProduct(lvKho);
            }
        }
        private void txtSeKho_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSeKho.Text.ToString().Length > 0)
                {
                    kho_ctl.loadKhoProductByKey(lvKho, txtSeKho.Text.ToString());
                }
            }
        }
        private void lvKho_Click(object sender, EventArgs e)
        {
            //update kho
            scr.sttInsProduct = 2;
            scr.idProductSelected = kho_ctl.loadItemKhohang_Click(lvKho, txtKhoMH, cbbKhoLH, txtKhoSL, cbbKhoDV, txtKhoSize, txtKhoTH, txtKhoInPr, txtKhoOPr, txtKhoBrand, txtKhoMT);
        }
        private void btnKhoIm_Click(object sender, EventArgs e)
        {
            //insert KHO
            scr.sttInsProduct = 1;
            kho_scr.btnKhoImClick(txtKhoMH, cbbKhoLH, txtKhoSL, cbbKhoDV, txtKhoSize, txtKhoTH, txtKhoInPr, txtKhoOPr, txtKhoBrand, txtKhoMT);
        }
        private void btnKhoDel_Click(object sender, EventArgs e)
        {
            if (scr.idProductSelected != null)
            {
                if (hc.DialogYesNo(ct_me.MES_01, ct_me.MES_00) == 1)
                {
                    if (kho_ctl.delProductById(scr.idProductSelected) == true)
                    {
                        kho_ctl.loadKhoProduct(lvKho);
                        kho_scr.btnKhoDelClick(txtKhoMH, cbbKhoLH, txtKhoSL, cbbKhoDV, txtKhoSize, txtKhoTH, txtKhoInPr, txtKhoOPr, txtKhoBrand, txtKhoMT);
                        scr.idProductSelected = null;
                    }
                    else
                    {
                        MessageBox.Show(ct_er.ERR_00);
                    }
                }
            }
            else
            {
                MessageBox.Show(ct_me.MES_02);
            }
        }
        private void btnKhoSave_Click(object sender, EventArgs e)
        {
            string pro_id = txtKhoMH.Text.ToString();
            string loaihang = "";
            if (cbbKhoLH.SelectedIndex == -1)
            {
                loaihang = "0";
            }
            else
            {
                loaihang = cbbKhoLH.SelectedValue.ToString();
            }
            string soluong = txtKhoSL.Text.ToString();
            string donvi = "";
            if (cbbKhoDV.SelectedIndex == -1)
            {
                donvi = "0";
            }
            else
            {
                donvi = cbbKhoLH.SelectedValue.ToString();
            }
            string size = txtKhoSize.Text.ToString();
            string tenhang = txtKhoTH.Text.ToString();
            string pr_in = txtKhoInPr.Text.ToString();
            string pr_out = txtKhoOPr.Text.ToString();
            string brand = txtKhoBrand.Text.ToString();
            string mota = txtKhoMT.Text.ToString();

            if (pro_id.Trim() != "")
            {
                //case insert 
                if (scr.sttInsProduct == 1)
                {
                    if (kho_ctl.checkProductIdExists(pro_id) == false)
                    {
                        var ins_result = kho_ctl.insProduct(pro_id, tenhang, pr_in, pr_out, soluong, mota, loaihang, donvi, brand, size);
                        if (ins_result == true)
                        {
                            kho_ctl.loadKhoProduct(lvKho);
                            kho_scr.btnKhoDelClick(txtKhoMH, cbbKhoLH, txtKhoSL, cbbKhoDV, txtKhoSize, txtKhoTH, txtKhoInPr, txtKhoOPr, txtKhoBrand, txtKhoMT);
                            scr.sttInsProduct = 0;
                            MessageBox.Show(ct_me.MES_04);
                        }
                        else
                        {
                            MessageBox.Show(ct_er.ERR_00);
                        }
                    }
                    else
                    {
                        MessageBox.Show(ct_me.MES_03);
                    }
                }
                //case update 
                else
                {
                    var upt_result = kho_ctl.uptProduct(pro_id, tenhang, pr_in, pr_out, soluong, mota, loaihang, donvi, brand, size);
                    if (upt_result == true)
                    {
                        kho_ctl.loadKhoProduct(lvKho);
                        kho_scr.btnKhoDelClick(txtKhoMH, cbbKhoLH, txtKhoSL, cbbKhoDV, txtKhoSize, txtKhoTH, txtKhoInPr, txtKhoOPr, txtKhoBrand, txtKhoMT);
                        scr.sttInsProduct = 0;
                        scr.idProductSelected = null;
                        MessageBox.Show(ct_me.MES_06);
                    }
                    else
                    {
                        MessageBox.Show(ct_er.ERR_00);
                    }
                }
            }
            else
            {
                MessageBox.Show(ct_me.MES_05);
            }

        }

        private void btnKhoHuy_Click(object sender, EventArgs e)
        {

        }

        private void btnKhoBack_Click(object sender, EventArgs e)
        {

        }
        private void txtKhoSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtKhoInPr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtKhoOPr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }










        #endregion KHO HANG 
        #region tamhc
        public void loadFromSellingProduct()
        {
            loadLstBillBanHang();
            //load cbb  guess
            spc.loadCbbGuess(cbbBanIDProvider);
        }
        public void loadLstBillBanHang()
        {
            spc.loadLstAllBillBanhang(lsvBanListBill);
            spc.loadLstAllProDuct(lsvBanSearchResult);
        }
        private void lsvBanListBill_Click(object sender, MouseEventArgs e)
        {
            spc.itemLstBillBanhang_click(lsvBanListBill, txtBanIdBill, txtBanDate, cbbBanIDProvider, txtBanNameCustomer, txtBanContent, lsvBanDBill);
        }
        private void txtBanSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBanSearch.Text.ToString().Length != 0)
            {
                spc.loadLstBanSearchResult(lsvBanSearchResult, txtBanSearch.Text.ToString());
            }
            if (txtBanSearch.Text.ToString().Length == 0)
            {
                spc.loadLstBanSearchResult(lsvBanSearchResult, "  ");
            }
        }
        private void btnBanSearch_Click(object sender, EventArgs e)
        {
            if (txtBanSearch.Text.ToString().Length != 0)
            {
                spc.loadLstBanSearchResult(lsvBanSearchResult, txtBanSearch.Text.ToString());
            }
        }
        private void btnBanCreate_Click(object sender, EventArgs e)
        {
            loadTxtBanDate(stic.getCurrentDay().ElementAt(0).ToString()
                    , stic.getCurrentDay().ElementAt(1).ToString()
                    , stic.getCurrentDay().ElementAt(2).ToString()
                    , stic.getCurrentDay().ElementAt(3).ToString());

        }
        public void loadTxtBanDate(string date, string year, string month, string day)
        {
            var hour = DateTime.Now.Hour;
            var min = DateTime.Now.Minute;
            var se = DateTime.Now.Second;
            txtBanDate.Text = day + "/" + month + "/" + year + " " + hour + ":" + min + ":" + se;
            autoLoadBanIdBill(date);
        }
        public void autoLoadBanIdBill(string datetime)
        {
            String bill = spc.createBillID(datetime);
            txtBanIdBill.Text = bill;
        }
        private void cbbBanIDProvider_DropDownClosed(object sender, EventArgs e)
        {
            var cbbBan = cbbBanIDProvider.SelectedValue.ToString();
            if (cbbBan.Equals("<Trống>"))
            {
                txtBanNameCustomer.Enabled = true;
                txtBanNameCustomer.Text = "";
            }
            else
            {
                txtBanNameCustomer.Text = spc.loadTenGuess(cbbBan);
                txtBanNameCustomer.Enabled = false;
            }
        }
        private void lsvBanSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvBanSearchResult.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvBanSearchResult.SelectedItems[lsvBanSearchResult.SelectedItems.Count - 1];
                if (item != null)
                {
                    foreach (ListViewItem lv in lsvBanSearchResult.SelectedItems)
                    {
                        txtBanDetailIdProduct.Text = lv.SubItems[1].Text;
                        txtBanNameProduct.Text = lv.SubItems[2].Text;
                        txtBanQuality.Text = lv.SubItems[3].Text;
                        txtBanPriceOne.Text = lv.SubItems[4].Text;
                        txtBanChietKhau.Text = lv.SubItems[5].Text;
                    }
                    flag = 1;
                    btnBanAdd.Text = "Thêm vào";
                }
            }
        }
      
        private void lsvBanDBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = 2;
            btnBanAdd.Text = "Cập nhập";
        }

        private void btnBanAdd_Click(object sender, EventArgs e)
        {
            if (spc.checkquanlityfield(txtBanQuality, txtBanPriceOne, txtBanChietKhau, txtBanIdBill))
            {
                if (flag == 0)
                {
                    MessageBox.Show(ct_er.ERR_03);
                }
                if (flag == 1)
                {
                    spc.addNewItem(lsvBanDBill, txtBanIdBill.Text, txtBanDetailIdProduct.Text, txtBanNameProduct.Text, txtBanQuality.Text, txtBanNote.Text, txtBanPriceOne.Text, txtBanChietKhau.Text);
                }
                if (flag == 2)
                {
                    spc.updateItem(lsvBanDBill, txtBanIdBill.Text, txtBanDetailIdProduct.Text, txtBanNameProduct.Text, txtBanQuality.Text, txtBanNote.Text, txtBanPriceOne.Text, txtBanChietKhau.Text);
                }   
            }
            else
            {
                MessageBox.Show(ct_er.ERR_03);
            }
        }

        private void btnBanDelete_Click(object sender, EventArgs e)
        {
            if(txtBanDetailIdProduct.Text.Trim().Equals(""))
            {
                MessageBox.Show(ct_me.SUS_02);
            }
            else
            { 
                spc.deleteBill(txtBanIdBill.Text);
                spc.deleteBillDetail(txtBanIdBill.Text);
                MessageBox.Show(ct_me.SUS_01);
                clearFormBan();
            }
        }
        private void btnBanSave_Click(object sender, EventArgs e)
        {
            if (txtBanDetailIdProduct.Text.Trim().Equals(""))
            {
                MessageBox.Show(ct_me.SUS_02);
            }
            else
            { 
                if(flag == 1)
                { 
                    spc.addBill(lsvBanDBill, txtBanIdBill.Text, cbbBanIDProvider.SelectedValue.ToString(), txtBanDate.Text, txtBanNote.Text, 1, 0, txtBanNameCustomer.Text);
                    MessageBox.Show(ct_me.SUS_00);
                    clearFormBan();
                }
                if(flag ==2)
                {
                    spc.addBill(lsvBanDBill, txtBanIdBill.Text, cbbBanIDProvider.SelectedValue.ToString(), txtBanDate.Text, txtBanNote.Text, 1, 0, txtBanNameCustomer.Text);
                    MessageBox.Show(ct_me.SUS_00);
                    clearFormBan();
                }
            }
        }
        private void btnBanCancel_Click(object sender, EventArgs e)
        {
            clearFormBan();
        }
        private void clearFormBan()
        {
            List<TextBox> lstTxt = new List<TextBox>();
            List<ListView> lstLsv = new List<ListView>();
            lstTxt.Add(txtBanIdBill);
            lstTxt.Add(txtBanNameCustomer);
            lstTxt.Add(txtBanContent);
            //lstTxt.Add(txtBanDetailIdProduct);
            lstTxt.Add(txtBanNameProduct);
            lstTxt.Add(txtBanQuality);
            lstTxt.Add(txtBanNote);
            lstTxt.Add(txtBanPriceOne);
            lstTxt.Add(txtBanChietKhau);
            lstTxt.Add(txtBanDetailIdProduct);

            cbbBanIDProvider.SelectedIndex = 0;

            lstLsv.Add(lsvBanDBill);
            lstLsv.Add(lsvBanSearchResult);

            fps.clearTextBoxandListView(lstTxt, lstLsv);
        }
        private void dtBanDate_ValueChanged(object sender, EventArgs e)
        {
            string date = dtBanDate.Value.ToString("yyyy-MM-dd");
            string year = dtBanDate.Value.ToString("yyyy");
            string month = dtBanDate.Value.ToString("MM");
            string day = dtBanDate.Value.ToString("dd");
            loadTxtDateban(date, year, month, day);
        }
        public void loadTxtDateban(string date, string year, string month, string day)
        {
            var hour = DateTime.Now.Hour;
            var min = DateTime.Now.Minute;
            var se = DateTime.Now.Second;
            txtBanDate.Text = day + "/" + month + "/" + year + " " + hour + ":" + min + ":" + se;
            txtBanIdBill.Text = spc.createBillID(date);

        }
        private void txtBanQuality_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtBanPriceOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtBanChietKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        
    }
}

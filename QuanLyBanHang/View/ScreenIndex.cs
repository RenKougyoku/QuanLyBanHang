using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.View
{
    public class ScreenIndex
    {
        public int indexTabHome = 0;
        public int indexTabNhaphang = 2;
        public int indexTabBanhang = 3;
        public int indexTabThongKe = 5;
        public int indexTabKhohang = 4;
        //Guess screen
        public string idGuessProviderSelected = null;
        public int insGuessStatus = 1 ; // 1:  inserts    2 : update   

        //Kho screen 
        public string idProductSelected;
        public int sttInsProduct = 1; // 1: Insert 2: Update

        //Nhap hang
        public string idBillNhapSelected = null;
        public int sttInsBillNhap = 1;// 1: Insert bill 2: Update bill
    }
}

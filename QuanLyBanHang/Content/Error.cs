using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Content
{
    public class Error
    {
        public string ERR_00 = "Đã xãy ra lỗi! Vui lòng thử lại.";
        public string ERR_01 = "Chưa có mã.";
        public string ERR_02 = "Mã đã tồn tại.";
        public string ERR_03 = "Nhập thiếu thông tin";

        //guess model 
        public string MD_ERR_G01 = "Lỗi lấy danh sách khách hàng, nhà cung cấp.";
        public string MD_ERR_G02 = "Lỗi tìm kiếm theo loại.";
        public string MD_ERR_G03 = "Lỗi tìm kiếm theo loại và keyword.";
        public string MD_ERR_G04 = "Lỗi tìm kiếm theo keyword.";
        public string MD_ERR_G05 = "Lỗi lấy danh sách nhà cung cấp.";
        public string MD_ERR_G06 = "Lỗi lấy danh sách khách hàng.";
    }
}

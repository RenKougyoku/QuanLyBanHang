using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Content
{
    class Static
    {
        public List<string> getCurrentDay()
        {
            List<string> data = new List<string>();
            DateTime dt = DateTime.Now;
            string year = dt.ToString("yyyy");
            string month = dt.ToString("MM");
            string day = dt.ToString("dd");
            string date = year + "-" + month + "-" + day;
            data.Add(date);
            data.Add(year);
            data.Add(month);
            data.Add(day);
            return data;
        }
    }
}

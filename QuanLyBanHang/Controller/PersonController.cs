using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Controller
{
    class PersonController
    {
        HamChung hc = new HamChung();
        person_model pm = new person_model();

        public void loadCBBPersionId(ComboBox cbb)
        {
            string display = "person_id";
            string value = "person_name";
            DataTable dt = pm.getAllPersionInfo();
            hc.loadComboBox(cbb,dt,display,value);
        }
    }
}

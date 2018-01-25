using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Database
{
    class db_User
    {
        ConnectionString db;
        public db_User()
        {
            db = new ConnectionString();
        }
        public bool addProvider(string id, string name, string address, string phone, string com)
        {
            var success = false;
            string s = string.Format("INSERT INTO tb_Provider(ID,Providername,Provideraddress,Providerphone,Providercompany) VALUES('{0}',N'{1}',N'{2}','{3}',N'{4}')", id, name, address, phone,com);
            try
            {
                db.ExecuteNonQuery(s);
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                MessageBox.Show("Lỗi thêm mới nhà cung cấp!");
                Console.WriteLine(e.ToString());
            }
            return success;
        }
        public void addAccount(string username, string pass, int role)
        {
            string s = string.Format("INSERT INTO tb_User(USERNAME,PASS,Roles) VALUES ('{0}','{1}',{2})",username,pass,role);
            try
            {
                db.ExecuteNonQuery(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        
       


    }
}

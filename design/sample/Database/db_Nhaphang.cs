using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Database
{
    class db_Nhaphang
    {
        ConnectionString db;
        /*
        public db_Nhaphang()
        {
            db = new ConnectionString();
        }
        public void creBillIn(string id, string date, string proid,string note)
        {
            string s = "";
            if (proid.Equals("NULL"))
            {
                 s = string.Format("INSERT INTO tb_BillIn(ID,DateIn,ProviderID,Note) VALUES('{0}','{1}',{2},N'{3}')", id, date, proid, note);
            }
            else
            {
                 s = string.Format("INSERT INTO tb_BillIn(ID,DateIn,ProviderID,Note) VALUES('{0}','{1}','{2}',N'{3}')", id, date, proid, note);
            }
            Console.WriteLine(s);
            try
            {
                db.ExecuteNonQuery(s);
                MessageBox.Show("Tạo thành công.\n Mã đơn nhập hàng: " + id.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi không thể tạo đơn hàng! Vui lòng thử lại!");
                Console.WriteLine(e.ToString());
            }
        }
        public void delBillIn(int id)
        {
            string s = string.Format("DELETE FROM tb_BillIn where ID = {0}",id);
            try
            {
                db.ExecuteNonQuery(s);
                MessageBox.Show("Đã xóa đơn hàng: "+id.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi xóa đơn hàng!");
                Console.WriteLine(e.ToString());
            }
        }
        public bool delDTBillIn(int id)
        {
            bool check = false;
            string s = string.Format("DELETE FROM tb_DTBillIn where IDBILLIN = {0}", id);
            try
            {
                db.ExecuteNonQuery(s);
                check = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                check = false;
            }
            return check;
        }
        public void addPro_toBillIn(int idhd, string idpro, int quan,string note)
        {
            string s = string.Format("INSERT INTO tb_DTBillIn(IDBILLIN ,IDPRO,Quantity,Note) VALUES({0},'{1}',{2},'{3}')", idhd, idpro, quan,note);
            try
            {
                db.ExecuteNonQuery(s);
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Console.WriteLine("idhd: " + idhd.ToString());
                Console.WriteLine("idpro: " + idpro.ToString());
                Console.WriteLine("quan: " + quan.ToString());
                Console.WriteLine("note: " + note.ToString());
            }
        }
        public void upDate()
        {

        }

        // GUESS
        public bool insertGuess(string id, string name, string address, string phone)
        {
            var success = false;
            string s = string.Format("INSERT INTO tb_Guess (Guess_id,Guessname,Guessaddress,Guessphone) VALUES ('{0}',N'{1}',N'{2}','{3}')", id, name, address, phone);
            try
            {
                db.ExecuteNonQuery(s);
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                Console.WriteLine(e.ToString());
            }
            return success;
        }
        public bool updateGuess(string id, string name, string address, string phone)
        {
            var success = false;
            string s = string.Format("UPDATE tb_Guess Set Guessname = N'{1}', Guessaddress = N'{2}', Guessphone = '{3}' Where guess_id = '{0}'", id, name, address, phone);
            try
            {
                db.ExecuteNonQuery(s);
                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }
            return success;
        }
        public bool delGuessbyId(string id)
        {
            bool check = false;
            string s = string.Format("DELETE FROM tb_Guess where guess_id = '{0}'", id);
            try
            {
                db.ExecuteNonQuery(s);
                check = true;
            }
            catch (Exception e)
            {
                check = false;
            }
            return check;
        }

        //Provider
        public bool delProviderbyId(string id)
        {
            bool check = false;
            string s = string.Format("DELETE FROM tb_Provider where provider_id = '{0}'", id);
            try
            {
                db.ExecuteNonQuery(s);
                check = true;
            }
            catch (Exception e)
            {
                check = false;
            }
            return check;
        }
        */

    }
}

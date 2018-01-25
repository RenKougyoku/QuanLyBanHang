using QuanLyBanHang.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Retreive
{
    class retrieve
    {
        ConnectionString db;
        public retrieve()
        {
            db = new ConnectionString();
        }
        //Product
        public DataTable getAllCategory()
        {
            string sql_query = "Select * from tb_Category";
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public int getIdCatebyName(string name)
        {
            string sql_query = string.Format("Select ID from tb_Category where Categories like N'{0}'",name);
            int value = db.getInt(sql_query);
            return value;
        }
        public DataTable getAllUnit()
        {
            string sql_query = "Select * from tb_Unit";
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public DataTable getAllProduct()
        {
            
            string sql_query = "SELECT row_number()OVER (ORDER BY Productname asc ) as STT, P.ID, Productname,Quantity,OutPrice,InPrice,IdUnit,IdCate,Modifi,Brandname,Size,Photo,Categories,Unitted from tb_Product P, tb_Category C, tb_Unit U where P.IdCate = C.Id AND P.IdUnit = U.Id ORDER BY Productname";
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public DataTable getAllProductById(string key)
        {
            string sql_query = string.Format("SELECT row_number()OVER (ORDER BY Quantity asc ) as STT, PD.ID, Productname,Quantity,OutPrice,InPrice,IdUnit,IdCate,Modifi,Brandname,Size,Photo from tb_Product PD, tb_Category CT WHERE PD.IdCate = CT.ID AND ( PD.ID like '%{0}%'  OR PRODUCTNAME like N'%{0}%'  OR Brandname like N'%{0}%' Or Categories like N'%{0}%') ORDER BY QUANTITY", key);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public DataTable getProById(string id)
        {
            string sql_query = string.Format("SELECT * FROM tb_Product Where ID = '{0}'",id);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public bool checkProExists(string id)
        {
            bool check = false;
            string sql_query = string.Format("SELECT 1 from tb_Product WHERE ID = '{0}'",id);
            int result = db.getInt(sql_query);
            //already
            if(result == 1)
            {
                check = true;
            }
            // not yet
            else
            {
                check = false;
            }
            return check; 
        }
        public bool getLogin(string username, string password)
        {
            bool checkLogin = false;
            int result;
            string sql_query = string.Format("select 1 from tb_Username where Username like '{0}'", username);
            result = db.getInt(sql_query);
            if (result == 1)
            {
                string db_pass;
                string sql_query1 = string.Format("Select Pass from tb_Username where Username like '{0}'", username);
                db_pass = db.getString(sql_query1);
                if (password.Equals(db_pass))
                {
                    checkLogin = true;
                }
                else
                {
                    checkLogin = false;
                    MessageBox.Show("Mật khẩu không đúng!");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }
            return checkLogin;
        }
        //USER
        public DataTable getAllProvider()
        {
            string bonus = ",1,1,1,1,1,1,1,1,1,1,1,1,1";
            string sql_query = "SELECT row_number()OVER (ORDER BY Providername asc ) as STT, Provider_id,Providername,Provideraddress,Providerphone " + bonus + " " +
                               "FROM tb_Provider ORDER BY Providername";
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public DataTable getAllProviderById(string key)
        {
            string bonus = ",1,1,1,1,1,1,1,1,1,1,1,1,1";
            string sql_query = string.Format("SELECT row_number()OVER (ORDER BY Providername asc ) as STT, Provider_id,Providername,Provideraddress,Providerphone " + bonus + " " +
                               "FROM tb_Provider WhERE Provider_id like '%{0}%' OR Providername like '%{0}%' OR Providerphone = '{0}' ORDER BY Providername", key);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public DataTable getInfobyID_Provider(string id)
        {
            string sql_query = string.Format("Select * from tb_Provider where ID = '{0}'", id);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public bool checkProviderExists(string id)
        {
            bool check = false;
            string sql_query = string.Format("SELECT 1 FROM tb_Provider Where ID = '{0}'", id);
            int result = db.getInt(sql_query);
            if (result == 1)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public DataTable getAllGuess()
        {
            string bonus = ",1,1,1,1,1,1,1,1,1,1,1,1,1";
            string sql_query = "SELECT row_number()OVER (ORDER BY Guessname asc ) as STT, Guess_id,Guessname,Guessaddress,Guessphone " + bonus + " " +
                               "FROM tb_Guess ORDER BY Guessname";
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public DataTable getAllGuessById(string key)
        {
            string bonus = ",1,1,1,1,1,1,1,1,1,1,1,1,1";
            string sql_query = string.Format("SELECT row_number()OVER (ORDER BY Guessname asc ) as STT, Guess_id,Guessname,Guessaddress,Guessphone " + bonus + " " +
                               "FROM tb_Guess WhERE Guess_id like '%{0}%' OR Guessname like '%{0}%' OR Guessphone = '{0}' ORDER BY Guessname", key);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public bool checkExistsGuess(string id)
        {
            bool check = false;
            string sql_query = string.Format("SELECT 1 from tb_Guess WHERE Guess_id = '{0}'", id);
            int result = db.getInt(sql_query);
            //already
            if (result == 1)
            {
                check = true;
            }
            // not yet
            else
            {
                check = false;
            }
            return check;
        }
        //BILL
        public DataTable getAllBillIn()
        {
            string sql_query = "Select row_number()OVER (ORDER BY cast([datein] as datetime) desc) as STT, B.ID,DateIn,ProviderID,Note  from tb_BillIn B order by STT asc";
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public bool checkHDexists(int id)
        {
            bool check = false;
            string sql_query = string.Format("Select 1 from tb_BillIn where ID = {0}", id);
            int result = db.getInt(sql_query);
            if (result == 1)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public DataTable getProByIdBillIn(int id)
        {
            string sql_query = string.Format("Select row_number()OVER (ORDER BY D.Quantity desc ) as STT, IDBILLIN, D.IDPRO, Productname, D.Quantity, Note from tb_DTBillIn D, tb_Product T  Where D.IDPRO = T.ID AND IDBILLIN = {0}", id);
            DataTable dt = db.Execute(sql_query);
            return dt;
        }
        public bool checkHDhasProduct(int id)
        {
            bool check = false;
            string sql_query = string.Format("Select 1 from tb_DTBillIn where IDBILLIN = {0}", id);
            int result = db.getInt(sql_query);
            if (result == 1)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
        public int getQuantityDT(int idbill, string pro)
        {
            string sql_query = string.Format("SELECT Quantity FROM tb_DTBillIn WHere IDBILLIN = {0} AND IDPRO = '{1}'", idbill, pro);
            int resul = db.getInt(sql_query);
            return resul;
        }
    }
}

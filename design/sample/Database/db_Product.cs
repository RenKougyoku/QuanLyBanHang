using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Database
{
    class db_Product
    {
        ConnectionString db;
        public db_Product()
        {
            db = new ConnectionString();
        }
        public bool addProduct(string id, string name, int inprice, int outprice, int quan, string modif, int idcate, int idunit,string brand,string size, byte[] photo)
        {
            bool check = false;
            string sql_query = string.Format("INSERT INTO tb_Product(ID,Productname,InPrice,OutPrice,Quantity,Modifi,IdCate,IdUnit,Brandname,Size,Photo) VALUES ('{0}',N'{1}',{2},{3},{4},N'{5}',{6},{7},N'{8}',N'{9}',CONVERT(varbinary(max),'{10}'))", id,name,inprice,outprice,quan,modif, idcate,idunit,brand,size,photo);
            try
            {
                db.ExecuteNonQuery(sql_query);
                check = true;
                Console.WriteLine(sql_query.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                check = false;
                Console.WriteLine(sql_query.ToString());
            }
            return check;
        }
        public bool delProduct(string id)
        {
            bool check = false;
            try
            {
                string sql = string.Format("DELETE FROM tb_PRODUCT WHERE ID = '{0}'", id);
                db.ExecuteNonQuery(sql);
                check = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                check = false;
            }
            return check;
        }
        public bool uptProduct(string name, int inprice, int outprice, int quan, string modif, string brand, string size, int cate, int unit ,string id)
        {
            bool check = false;
            string sql_query = string.Format("UPDATE tb_Product SET Productname = N'{0}', InPrice = {1}, OutPrice = {2}, Quantity = {3}, Modifi = N'{4}', Brandname = N'{5}', Size = N'{6}',IdCate = {7},IdUnit = {8} Where ID = '{9}'",name, inprice, outprice, quan, modif, brand,size,cate,unit,id);
            try
            {
                db.ExecuteNonQuery(sql_query);
                check = true;
                Console.WriteLine(sql_query.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                check = false;
                Console.WriteLine(sql_query.ToString());
            }
            return check;
        }

        
    }
}

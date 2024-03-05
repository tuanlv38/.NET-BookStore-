using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace quanlysachc.Models
{

    public class SachYeuThichModel
    {
        public DataTable dsSachYeuThich;
        public List<object> chan;
        MySqlConnection conn;
        public SachYeuThichModel()
        {  
            String sql = "server=localhost; SachYeuThich=root; database=bookstore; password=";
            conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
                Console.Write("connectcs");
                MySqlDataAdapter dataA = new MySqlDataAdapter("SELECT * FROM `bs_sach_yeu_thich` ;", conn);
                dsSachYeuThich = new DataTable();
                dataA.Fill(dsSachYeuThich);
                chan = new List<object>();
                foreach (DataRow b in dsSachYeuThich.Rows)
                {


                    chan.Add(Convert.ToString(b[3]));

                }
            }
            catch (Exception e) { };

        }



    }
}

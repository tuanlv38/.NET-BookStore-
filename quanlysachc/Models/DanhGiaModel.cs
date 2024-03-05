using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace quanlysachc.Models
{

    public class DanhGiaController
    {
        public DataTable dsDanhGia;
        public List<object> chan;
        MySqlConnection conn;
        public DanhGiaController()
        {
            String sql = "server=localhost; DanhGia=root; database=bookstore; password=";
            conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
                Console.Write("connectcs");
                MySqlDataAdapter dataA = new MySqlDataAdapter("SELECT * FROM `bs_danh_gia` ;", conn);
                dsDanhGia = new DataTable();
                dataA.Fill(dsDanhGia);
                chan = new List<object>();
                foreach (DataRow b in dsDanhGia.Rows)
                {


                    chan.Add(Convert.ToString(b[3]));

                }
            }
            catch (Exception e) { };

        }



    }
}

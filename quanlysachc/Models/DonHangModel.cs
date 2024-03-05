using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace quanlysachc.Models
{

    public class DonHangController
    {
        public DataTable dsDonHang;
        public List<object> chan;
        MySqlConnection conn;
        public DonHangController()
        {
            String sql = "server=localhost; DonHang=root; database=bookstore; password=";
            conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
                Console.Write("connectcs");
                MySqlDataAdapter dataA = new MySqlDataAdapter("SELECT * FROM `bs_don_hang` ;", conn);
                dsDonHang = new DataTable();
                dataA.Fill(dsDonHang);
                chan = new List<object>();
                foreach (DataRow b in dsDonHang.Rows)
                {


                    chan.Add(Convert.ToString(b[3]));

                }
            }
            catch (Exception e) { };

        }



    }
}

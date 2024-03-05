using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace quanlysachc.Models
{

    public class CTDHController
    {
        public DataTable dsCTDH;
        public List<object> chan;
        MySqlConnection conn;
        public CTDHController()
        {
            String sql = "server=localhost; CTDH=root; database=bookstore; password=";
            conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
                Console.Write("connectcs");
                MySqlDataAdapter dataA = new MySqlDataAdapter("SELECT * FROM `bs_chi_tiet_don_hang` ;", conn);
                dsCTDH = new DataTable();
                dataA.Fill(dsCTDH);
                chan = new List<object>();
                foreach (DataRow b in dsCTDH.Rows)
                {


                    chan.Add(Convert.ToString(b[3]));

                }
            }
            catch (Exception e) { };

        }



    }
}

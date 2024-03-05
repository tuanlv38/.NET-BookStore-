using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace quanlysachc.Models
{

    public class LoaiSachModel
    {
        public List<LoaiSach> dsLoaiSach;
        MySqlConnection conn;
        public LoaiSachModel()
        {
            dsLoaiSach = new List<LoaiSach>();
            String sql = "server=localhost; user=root; database=bookstore; password=";
            conn = new MySqlConnection(sql);
            try
            {
                conn.Open();


            }
            catch (Exception e)
            {
                Console.Write("chanqua");
            };

        }


        public void selectAllLoaiSach()
        {


            MySqlCommand command = new MySqlCommand("SELECT * FROM bs_loai_sach", conn);

            MySqlDataReader reader = command.ExecuteReader();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = 1;
            while (reader.Read())
            {

                LoaiSach tg = new LoaiSach();
                tg.Id = reader.GetInt32(0);
                try
                {
                    tg.TenLoaiSach = reader.GetString(1);
                }
                catch (Exception e)
                {
                };
                dsLoaiSach.Add(tg);
            }

            reader.Close();

        }
    }
    }


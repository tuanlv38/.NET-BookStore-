using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using quanlysachc.Models;
using System.Data;

namespace quanlysachc.Models
{

    public class TacGiaModel
    {

        public List<TacGia> dsTacGia;
        MySqlConnection conn;
        public TacGiaModel()
        {
            dsTacGia = new List<TacGia>();
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


        public void selectAllTacGia()
        {


            MySqlCommand command = new MySqlCommand("SELECT * FROM bs_tac_gia", conn);

            MySqlDataReader reader = command.ExecuteReader();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = 1;
            while (reader.Read())
            {
                TacGia tg = new TacGia();
                tg.Id = reader.GetInt32(0);
                tg.TenTacGia = reader.GetString(1);
                try
                {
                    tg.NgaySinh = reader.GetString(2);

                }
                catch (Exception e)
                {
                };
                try
                {
                    tg.GioiThieu = reader.GetString(3);

                }
                catch (Exception e)
                {
                };
                dsTacGia.Add(tg);


            }

            reader.Close();

        }
        public TacGia selectTacGiaByID(int iid)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM  bs_tac_gia where id_tac_gia = @iid", conn);

            command.Parameters.AddWithValue("@iid", iid);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                TacGia tg = new TacGia();
                tg.Id = reader.GetInt32(0);
                tg.TenTacGia = reader.GetString(1);
                try
                {   
                    tg.NgaySinh = reader.GetString(2);
                   
                }
                catch (Exception e)
                {
                };
                try
                {
                    tg.GioiThieu = reader.GetString(3);

                }
                catch (Exception e)
                {
                };
                return tg;

            }



            return new TacGia();

        }

    }


}


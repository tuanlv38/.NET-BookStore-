using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using quanlysachc.Models;
using System.Data;

namespace quanlysachc.Models
{

    public class NXBModel
    {

        public List<NXB> dsNXB;
        MySqlConnection conn;
        public NXBModel()
        {
            dsNXB = new List<NXB>();
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


        public void selectAllNXB()
        {


            MySqlCommand command = new MySqlCommand("SELECT * FROM bs_nha_xuat_ban", conn);

            MySqlDataReader reader = command.ExecuteReader();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = 1;
            while (reader.Read())
            {

                NXB tg = new NXB();
                tg.Id = reader.GetInt32(0);
                try
                {
                    tg.TenNXB = reader.GetString(1);
                }
                catch (Exception e)
                {
                }; try
                {
                    tg.DiaChi = reader.GetString(2);
                }
                catch (Exception e)
                {
                }; try
                {
                    tg.DienThoai = reader.GetString(3);
                }
                catch (Exception e)
                {
                }; try
                {
                    tg.Email = reader.GetString(4);
                }
                catch (Exception e)
                {
                };
                dsNXB.Add(tg);
            }

            reader.Close();

        }
        public NXB selectNXBByID(int iid)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM  bs_nha_xuat_ban where id_nha_xuat_ban = @iid", conn);

            command.Parameters.AddWithValue("@iid", iid);

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                NXB tg = new NXB();
                tg.Id = reader.GetInt32(0);
                try
                {
                    tg.TenNXB = reader.GetString(1);
                }
                catch (Exception e)
                {
                }; try
                {
                    tg.DiaChi = reader.GetString(2);
                }
                catch (Exception e)
                {
                }; try
                {
                    tg.DienThoai = reader.GetString(3);
                }
                catch (Exception e)
                {
                }; try
                {
                    tg.Email = reader.GetString(4);
                }
                catch (Exception e)
                {
                };
                return tg;
           
            }



            return new NXB();

        }

    }


}


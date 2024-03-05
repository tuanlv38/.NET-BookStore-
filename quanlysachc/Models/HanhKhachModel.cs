using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using quanlyHanhKhachc.Models;
using quanlysachc.Models;
using System.Data;

namespace quanlyHanhKhachc.Models
{

    public class HanhKhachModel
    {

        public List<HanhKhach> dsHanhKhach;
        MySqlConnection conn;
        public HanhKhachModel()
        {
            dsHanhKhach = new List<HanhKhach>();
            String sql = "server=localhost; user=root; database=qlcb; password=";
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


        public void selectAllHanhKhach()
        {


            MySqlCommand command = new MySqlCommand("SELECT * FROM HanhKhach", conn);

            MySqlDataReader reader = command.ExecuteReader();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = 1;
            while (reader.Read())
            {

                HanhKhach tg = new HanhKhach();
                tg.MaKH = reader.GetString(0);
                tg.HoTen = reader.GetString(1);
                tg.DiaChi = reader.GetString(2);
                tg.DienThoai = reader.GetString(3);

                dsHanhKhach.Add(tg);
            }

            reader.Close();

        }
        public void addHanhKhach(HanhKhach s)
        {


            String sqlz = "INSERT INTO HanhKhach " +
                                "VALUES (@id_HanhKhach, @ten_HanhKhach, @id_tac_gia, @id_loai_HanhKhach)";
            MySqlCommand command = new MySqlCommand(sqlz, conn);
            command.Parameters.AddWithValue("@id_HanhKhach", s.MaKH);
            command.Parameters.AddWithValue("@ten_HanhKhach", s.HoTen);
            command.Parameters.AddWithValue("@id_tac_gia", s.DiaChi);
            command.Parameters.AddWithValue("@id_loai_HanhKhach", s.DienThoai);


            // Thực thi câu lệnh SQL
            int rowsAffected = command.ExecuteNonQuery();

            // Kiểm tra xem có hàng nào bị ảnh hưởng không
            if (rowsAffected > 0)
            {
                Console.WriteLine("Thêm sách thành công!");
            }
            else
            {
                Console.WriteLine("Không có sách nào được thêm.");
            }
        }
    }

    }





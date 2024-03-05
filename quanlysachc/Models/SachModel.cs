using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using quanlysachc.Models;
using System.Data;
using System.Security.Cryptography;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace quanlysachc.Models
{

    public class SachModel
    {
        public int sortBy;
        public List<Sach> dsSach;
        MySqlConnection conn;
        public SachModel()
        {
            sortBy = -1;
            dsSach = new List<Sach>();
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

        public string orderby()
        {
            if (this.sortBy == 1) return " ORDER BY id_sach ASC";
            if (this.sortBy == 2) return " ORDER BY id_sach DESC";
            if (this.sortBy == 3) return " ORDER BY gia_bia ASC";
            if (this.sortBy == 4) return " ORDER BY gia_bia DESC";
            return " ORDER BY id_sach ASC";
        }
        public void selectAllBook()
        {

            dsSach.Clear();
            String sqlz = "SELECT * FROM `bs_sach`" + orderby();
            MySqlCommand command = new MySqlCommand(sqlz, conn);
            
            MySqlDataReader reader = command.ExecuteReader();
           
            while (reader.Read())
            {
                Sach tg = new Sach();
                tg.Id = reader.GetInt32(0);
                try
                {

                    tg.TenSach = reader.GetString(1);


                }
                catch (Exception e)
                {
                    
                };
                try
                {



                    tg.Id_tacGia = reader.GetInt32(2);
                 
                    


                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_loaiSach = reader.GetInt32(3);
                 
                }
                catch (Exception e)
                {

                };
                try
                {
                             
                 
                    tg.Id_NXB = reader.GetInt32(4);
                          }
                catch (Exception e)
                {

                };
                try
                {

                    tg.Hinh = reader.GetString(8);



                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.GiaBia = reader.GetInt32(6);

                }
                catch (Exception e)
                {

                };
                dsSach.Add(tg);


            }

            reader.Close();

        }
        public Sach selectBookByID(int iid)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM bs_sach where id_sach = @iid", conn);
          
            command.Parameters.AddWithValue("@iid", iid);
            
            MySqlDataReader reader = command.ExecuteReader();
            
          if (reader.Read())
            {
                Sach tg = new Sach();
                tg.Id = reader.GetInt32(0);
                try
                {

                    tg.TenSach = reader.GetString(1);


                }
                catch (Exception e)
                {

                };
                try
                {



                    tg.Id_tacGia = reader.GetInt32(2);




                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_loaiSach = reader.GetInt32(3);

                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_NXB = reader.GetInt32(4);
                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.Hinh = reader.GetString(8);



                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.GiaBia = reader.GetInt32(6);

                }
                catch (Exception e)
                {

                };
                reader.Close();
                return tg;
                
            }



            return new Sach();
         
        }
        public void GetFeatureBook()
        {
            
            dsSach.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM bs_sach LEFT JOIN bs_tac_gia ON bs_sach.id_tac_gia=bs_tac_gia.id_tac_gia where bs_sach.noi_bat=1 order by bs_sach.id_sach DESC", conn);
            
            MySqlDataReader reader = command.ExecuteReader();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = 1;
            while (reader.Read())
            {
                Sach tg = new Sach();
                tg.Id = reader.GetInt32(0);
                try
                {

                    tg.TenSach = reader.GetString(1);


                }
                catch (Exception e)
                {

                };
                try
                {



                    tg.Id_tacGia = reader.GetInt32(2);




                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_loaiSach = reader.GetInt32(3);

                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_NXB = reader.GetInt32(4);
                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.Hinh = reader.GetString(8);



                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.GiaBia = reader.GetInt32(6);

                }
                catch (Exception e)
                {

                };
                dsSach.Add(tg);


            }

            reader.Close();

        }
        public void searchBook(String keyword)
        {

            this.dsSach.Clear();
            string query = "SELECT * FROM bs_sach " +
                    "LEFT JOIN bs_tac_gia ON bs_sach.id_tac_gia = bs_tac_gia.id_tac_gia " +
                    "LEFT JOIN bs_loai_sach ON bs_sach.id_loai_sach = bs_loai_sach.id_loai_sach " +
                    "WHERE bs_sach.ten_sach LIKE @idd OR bs_tac_gia.ten_tac_gia LIKE @idd OR bs_loai_sach.ten_loai_sach LIKE @idd" + orderby();
            MySqlCommand command = new MySqlCommand(query, conn);

            command.Parameters.AddWithValue("@idd", "%" + keyword + "%");

            MySqlDataReader reader = command.ExecuteReader();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = 1;
            while (reader.Read())
            {
                Sach tg = new Sach();
                tg.Id = reader.GetInt32(0);
                try
                {

                    tg.TenSach = reader.GetString(1);


                }
                catch (Exception e)
                {

                };
                try
                {



                    tg.Id_tacGia = reader.GetInt32(2);




                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_loaiSach = reader.GetInt32(3);

                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_NXB = reader.GetInt32(4);
                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.Hinh = reader.GetString(8);



                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.GiaBia = reader.GetInt32(6);

                }
                catch (Exception e)
                {

                };
                dsSach.Add(tg);


            }

            reader.Close();

        }


        public void selectSachByTacGia(int id)
        {

            dsSach.Clear();
            String sqlz = "SELECT * FROM bs_sach WHERE bs_sach.id_tac_gia=@id_s" + orderby();
            MySqlCommand command = new MySqlCommand(sqlz, conn);
            command.Parameters.AddWithValue("@id_s",  id);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Sach tg = new Sach();
                tg.Id = reader.GetInt32(0);
                try
                {

                    tg.TenSach = reader.GetString(1);


                }
                catch (Exception e)
                {

                };
                try
                {



                    tg.Id_tacGia = reader.GetInt32(2);




                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_loaiSach = reader.GetInt32(3);

                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_NXB = reader.GetInt32(4);
                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.Hinh = reader.GetString(8);



                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.GiaBia = reader.GetInt32(6);

                }
                catch (Exception e)
                {

                };
                dsSach.Add(tg);


            }

            reader.Close();

        }
        public void selectSachByNXB(int id)
        {

            dsSach.Clear();
            String sqlz = "SELECT * FROM bs_sach WHERE bs_sach.id_nha_xuat_ban=@id_nxb" + orderby();
            MySqlCommand command = new MySqlCommand(sqlz, conn);
            command.Parameters.AddWithValue("@id_nxb", id);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Sach tg = new Sach();
                tg.Id = reader.GetInt32(0);
                try
                {

                    tg.TenSach = reader.GetString(1);


                }
                catch (Exception e)
                {

                };
                try
                {



                    tg.Id_tacGia = reader.GetInt32(2);




                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_loaiSach = reader.GetInt32(3);

                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_NXB = reader.GetInt32(4);
                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.Hinh = reader.GetString(8);



                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.GiaBia = reader.GetInt32(6);

                }
                catch (Exception e)
                {

                };
                dsSach.Add(tg);


            }

            reader.Close();

        }
        public void addSach(Sach s)
        {

          
            String sqlz = "INSERT INTO bs_sach(id_sach, ten_sach, id_tac_gia, id_loai_sach, id_nha_xuat_ban, don_gia, gia_bia, hinh) " +
                                "VALUES (@id_sach, @ten_sach, @id_tac_gia, @id_loai_sach, @id_nha_xuat_ban, @don_gia, @gia_bia, @hinh)";
            MySqlCommand command = new MySqlCommand(sqlz, conn);
            command.Parameters.AddWithValue("@id_sach", s.Id);
            command.Parameters.AddWithValue("@ten_sach", s.TenSach);
            command.Parameters.AddWithValue("@id_tac_gia", s.Id_tacGia);
            command.Parameters.AddWithValue("@id_loai_sach", s.Id_loaiSach);
            command.Parameters.AddWithValue("@id_nha_xuat_ban", s.Id_NXB);
            command.Parameters.AddWithValue("@don_gia", s.DonGia);
            command.Parameters.AddWithValue("@gia_bia", s.GiaBia);
            command.Parameters.AddWithValue("@hinh", s.Hinh);

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

        public void searchGioHang(String user)
        {

            this.dsSach.Clear();
            string query = "SELECT DISTINCT * FROM `bs_sach` Inner JOIN bs_gio_hang on bs_sach.id_sach= bs_gio_hang.id_sach WHERE bs_gio_hang.tai_khoan = @iid";
            MySqlCommand command = new MySqlCommand(query, conn);

            command.Parameters.AddWithValue("@iid", user);

            MySqlDataReader reader = command.ExecuteReader();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = 1;
            while (reader.Read())
            {
                Sach tg = new Sach();
                tg.Id = reader.GetInt32(0);
                try
                {

                    tg.TenSach = reader.GetString(1);


                }
                catch (Exception e)
                {

                };
                try
                {



                    tg.Id_tacGia = reader.GetInt32(2);




                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_loaiSach = reader.GetInt32(3);

                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_NXB = reader.GetInt32(4);
                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.Hinh = reader.GetString(8);



                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.GiaBia = reader.GetInt32(6);

                }
                catch (Exception e)
                {

                };
                dsSach.Add(tg);


            }

            reader.Close();

        }
        public void selectSachByLoaiSach(int id)
        {

            dsSach.Clear();
            String sqlz = "SELECT * FROM bs_sach WHERE bs_sach.id_loai_sach=@id_s" + orderby();
            MySqlCommand command = new MySqlCommand(sqlz, conn);
            command.Parameters.AddWithValue("@id_s", id);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Sach tg = new Sach();
                tg.Id = reader.GetInt32(0);
                try
                {

                    tg.TenSach = reader.GetString(1);


                }
                catch (Exception e)
                {

                };
                try
                {



                    tg.Id_tacGia = reader.GetInt32(2);




                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_loaiSach = reader.GetInt32(3);

                }
                catch (Exception e)
                {

                };
                try
                {


                    tg.Id_NXB = reader.GetInt32(4);
                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.Hinh = reader.GetString(8);



                }
                catch (Exception e)
                {

                };
                try
                {

                    tg.GiaBia = reader.GetInt32(6);

                }
                catch (Exception e)
                {

                };
                dsSach.Add(tg);


            }

            reader.Close();

        }
    }


}


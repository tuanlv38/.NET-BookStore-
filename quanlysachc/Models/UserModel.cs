using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;

namespace quanlysachc.Models
{
  
    public class UserModel
    {
     
        MySqlConnection conn;

            public UserModel()
            {
            
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
            public int findAcount(User u)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM bs_nguoi_dung where tai_khoan = @tk and cap_do = @cd;", conn);

                command.Parameters.AddWithValue("@tk", u.TaiKhoan);
            command.Parameters.AddWithValue("@cd", u.CapDo);
            int val = 0;
            MySqlDataReader reader = command.ExecuteReader();
            User tg = new User();
            if (reader.Read())
                {
                
                   
                    try
                    {
                        tg.TaiKhoan = reader.GetString(1);
                    Console.Write(tg.TaiKhoan);
                }
                    catch (Exception e)
                    {
                    }; 
                try
                    {
                        tg.MatKhau = reader.GetString(4);
                    Console.Write(tg.MatKhau);
                }
                    catch (Exception e)
                    {
                    }
                val= 1;

                }
            if (String.IsNullOrEmpty(tg.MatKhau)) return 0;
             if (tg.MatKhau == u.MatKhau) val=2 ;

                return val;

            }


         public int addAcount(User u)
        {
            
     
            String sqlz = "INSERT INTO `bs_nguoi_dung`( `tai_khoan`,`mat_khau`, `cap_do`) VALUES(@tk, @mk, 0);";
            MySqlCommand command = new MySqlCommand(sqlz, conn);
            command.Parameters.AddWithValue("@tk", u.TaiKhoan);
            command.Parameters.AddWithValue("@mk", u.MatKhau);
         

            // Thực thi câu lệnh SQL
            int rowsAffected = command.ExecuteNonQuery();

            // Kiểm tra xem có hàng nào bị ảnh hưởng không
            if (rowsAffected > 0)
            {
                Console.WriteLine("Thêm sách thành công!");
                return 1;
            }
            else
            {
                Console.WriteLine("Không có sách nào được thêm.");
            }
            return 0;
        }

        }



    }


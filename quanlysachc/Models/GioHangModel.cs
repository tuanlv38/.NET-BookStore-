using MySql.Data.MySqlClient;

namespace quanlysachc.Models
{
    public class GioHangModel
    {
        MySqlConnection conn;

        public GioHangModel()
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
        public int addItem(GioHang  user)
        {


            String sqlz = "INSERT INTO `bs_gio_hang`( `id_sach`,`tai_khoan`, `soluong`) VALUES(@tk, @mk, 1);";
            MySqlCommand command = new MySqlCommand(sqlz, conn);
            command.Parameters.AddWithValue("@tk", user.Id_Sach);
            command.Parameters.AddWithValue("@mk",user.TaiKhoan );


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

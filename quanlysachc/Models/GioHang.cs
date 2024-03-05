using MessagePack;

namespace quanlysachc.Models
{
    public class GioHang
    {
        int id_Sach;
        String tenSach;
        String taiKhoan;
        int soluong;
        int tongtien;
        public GioHang() { }
        public GioHang(int id_Sach, string tenSach, string taiKhoan, int soluong, int tongtien)
        {
            this.id_Sach = id_Sach;
           
            this.taiKhoan = taiKhoan;
            this.soluong = soluong;
            
        }

        public int Id_Sach { get => id_Sach; set => id_Sach = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    
    }
}

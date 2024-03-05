namespace quanlysachc.Models
{
    public class TacGia
    {
        int id;
        String tenTacGia;
        String ngaySinh;
        String gioiThieu;

        public int Id { get => id; set => id = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiThieu { get => gioiThieu; set => gioiThieu = value; }
    }
}

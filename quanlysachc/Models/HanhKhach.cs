namespace quanlysachc.Models
{
    public class HanhKhach
    {
        String maKH, hoTen, diaChi, dienThoai;

        public HanhKhach(string maKH, string hoTen, string diaChi, string dienThoai)
        {
            this.maKH = maKH;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
        }
        public HanhKhach() { }
        public string MaKH { get => maKH; set => maKH = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
    }
}

namespace quanlysachc.Models
{
    public class NXB
    {
        int id;
        String tenNXB;
        String diaChi;
        String dienThoai;
        String email;
        public NXB() {
            this.id = 0;
            this.tenNXB = "";
            this.diaChi = "";
            this.dienThoai = "";
            this.email = "";
        }

        public int Id { get => id; set => id = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string Email { get => email; set => email = value; }
    }
}

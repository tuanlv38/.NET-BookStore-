namespace quanlysachc.Models
{
    public class Sach
    {
        int id;
        String tenSach;

        int id_tacGia;
        int id_loaiSach;
        int id_NXB;
        int donGia;
        int giaBia;
        int YeuThich;
        String NXB;
        String tacGia;
        String hinh;
        IFormFile imageFile;
		public Sach()
        {
            this.id = 0;
            this.tenSach = "";
            this.giaBia = 0;
            this.hinh = "";
            this.id_tacGia = 0;
            this.id_NXB = 0;
            this.YeuThich = 0;
            this.donGia = 0;

        }
        public Sach(int id ,String tenSach, int giaBan,String hinh){
            this.id = id;
            this.tenSach = tenSach;
            this.giaBia = giaBan;
            this.hinh = hinh;
            this.id_tacGia = 0;
            this.id_NXB = 0;
            this.YeuThich = 0;
            this.donGia = 0;
            }
        public Sach(int id, String tenSach, int id_loaiSach,int id_tacGia,int id_NXB ,int donGia,int giaBan , String hinh)
		{
			this.id = id;
			this.tenSach = tenSach;
			this.giaBia = giaBan;
			this.hinh = hinh;
			this.id_tacGia = id_tacGia;
			this.id_NXB = id_NXB;
			this.YeuThich = 0;
			this.donGia = donGia;
            this.id_loaiSach = id_loaiSach ;

		}

		public int Id { get => id; set => id = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public int Id_tacGia { get => id_tacGia; set => id_tacGia = value; }
        public int Id_loaiSach { get => id_loaiSach; set => id_loaiSach = value; }
        public int Id_NXB { get => id_NXB; set => id_NXB = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public int GiaBia { get => giaBia; set => giaBia = value; }
        public int YeuThich1 { get => YeuThich; set => YeuThich = value; }
        public string NXB1 { get => NXB; set => NXB = value; }
        public string TacGia { get => tacGia; set => tacGia = value; }
        public string Hinh { get => hinh; set => hinh = value; }
		public IFormFile ImageFile { get => imageFile; set => imageFile = value; }

	

	}
}

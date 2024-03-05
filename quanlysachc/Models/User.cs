using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace quanlysachc.Models
{
    public class User 
    {
        String taiKhoan;
        String matKhau;
        int capDo;
        public User() { }
        public User(string taiKhoan, string matKhau, int capDo)
        {
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.capDo = capDo;
        }
        [Required(ErrorMessage = "Vui lòng nhập tài khoản.")]
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int CapDo { get => capDo; set => capDo = value; }
    }
}

using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using quanlysachc.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
namespace quanlysachc.Controllers
{
    public class AdminController : Controller
    {
    
        public IActionResult chanqua()
        {

            return View();
        }
        public IActionResult addbook()
        {
            string value = HttpContext.Session.GetString("UserNameAd"); 
            if(string.IsNullOrEmpty(value)) return RedirectToAction("Index");
            Console.Write("succes4s");
            TacGiaModel tg = new TacGiaModel();
			tg.selectAllTacGia();
			ViewBag.dsTacGia = tg.dsTacGia;
			NXBModel nxb = new NXBModel();
			nxb.selectAllNXB();
			ViewBag.dsNXB = nxb.dsNXB;
			return View();
        }
 
		[HttpPost]
		public IActionResult addbook([FromForm] Sach Model/*,[FromForm] Sach model)*/)

		{
            LoaiSachModel ls = new LoaiSachModel();
            ls.selectAllLoaiSach();
            ViewBag.dsLoaiSach = ls.dsLoaiSach;
            Console.Write("succesás4s");
            TacGiaModel tg = new TacGiaModel();
			tg.selectAllTacGia();
			ViewBag.dsTacGia = tg.dsTacGia;
			NXBModel nxb = new NXBModel();
			nxb.selectAllNXB();
			ViewBag.dsNXB = nxb.dsNXB;
			if (ModelState.IsValid)
			{
				if (Model.ImageFile != null && Model.ImageFile.Length > 0)
				{
					try
					{
						// Lưu tệp tin vào thư mục trên máy chủ (đường dẫn thích hợp cho ứng dụng của bạn)
						string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Contents","Images");
						string fileName = Path.GetFileName(Model.ImageFile.FileName);
						string filePath = Path.Combine(uploadPath, fileName);
						Model.Hinh = fileName;
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							Model.ImageFile.CopyTo(stream);
						}

						// Thực hiện các xử lý khác, nếu cần
						new SachModel().addSach(Model);
						Console.Write("wrong4");
						// Nếu có lỗi, quay lại trang Upload với model để hiển thị lỗi
						return View();
					}
					catch (Exception ex)
					{
						// Xử lý lỗi (hiển thị hoặc ghi log, tùy thuộc vào yêu cầu của bạn)
						ViewBag.ErrorMessage = "Upload failed. Error: " + ex.Message;
                        Console.Write("wrong3");
                    }
				}
				else
				{
					ViewBag.ErrorMessage = "Please choose a file to upload.";
                    Console.Write("wrong2");
                }
                Console.Write("wrong1");
            }
            Console.Write("succes4schan");
            // Nếu có lỗi, quay lại trang Upload với model để hiển thị lỗi
            return View();
		}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
		{
			
            return View();
        }

    [HttpPost]
		public IActionResult Index( [FromForm] User Model/*,[FromForm] Sach model)*/)
		{
            Model.CapDo = 5;
            if (2 == new UserModel().findAcount(Model))
				{
					HttpContext.Session.SetString("UserNameAd", Model.TaiKhoan);
					return RedirectToAction("addbook");
				}
            // Kiểm tra ModelState.IsValid
         
            ModelState.AddModelError(string.Empty, "Tài khoản hoặc mật khẩu không chính xác");


            return View(Model);
        }
        }
}

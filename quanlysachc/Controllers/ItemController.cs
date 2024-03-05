using Microsoft.AspNetCore.Mvc;



using System.Diagnostics;
using quanlysachc.Models;

namespace quanlysachc.Controllers
    {
        public class ItemController:Controller
        {
            private readonly ILogger<HomeController> _logger;

     
        public IActionResult Item(int id)
        {
            SachModel sml = new SachModel();
            Sach s = sml.selectBookByID(id);
            s.NXB1 = new NXBModel().selectNXBByID(s.Id_NXB).TenNXB;
            s.TacGia = new TacGiaModel().selectTacGiaByID(s.Id_tacGia).TenTacGia;
            ViewData["sach"] = s;
            return View();
        }
        [HttpPost]
        public IActionResult Item([FromForm] GioHang Model)
        {
            new GioHangModel().addItem(Model);
            return RedirectToAction("Item", new { id = Model.Id_Sach });

        }

    }
}


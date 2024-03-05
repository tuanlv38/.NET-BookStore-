using Microsoft.AspNetCore.Mvc;
using quanlysachc.Models;

namespace quanlysachc.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            string value = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(value)) return RedirectToAction("DNDK","Login");

            SachModel a = new SachModel();
            a.searchGioHang(value);
            ViewBag.dsSach = a.dsSach;
            return View();
        }
    }
}

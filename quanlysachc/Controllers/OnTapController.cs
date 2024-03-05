using Microsoft.AspNetCore.Mvc;
using quanlyHanhKhachc.Models;
using quanlysachc.Models;

namespace quanlysachc.Controllers
{
    public class OnTapController : Controller
    {
        public IActionResult Cau1()
        {
            return View();
        }
        public IActionResult ThemHanhKhach(HanhKhach hanhKhach)
        {
            if (ModelState.IsValid)
            { 
                HanhKhachModel a = new HanhKhachModel();
                a.addHanhKhach(hanhKhach);
                return RedirectToAction("Cau1", "Success");
            }
            return View("Cau1");
        }
    }
}

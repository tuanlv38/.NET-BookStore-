using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using quanlysachc.Models;

namespace quanlysachc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult DNDK(int id)
        {
            if (id == 1)
            {
                ViewData["DN"] = "active";
                ViewData["DK"] = "";
            }
            else
            {
                ViewData["DN"] = "";
                ViewData["DK"] = "active";
            }

            return View();
        }

        [HttpPost]
        public IActionResult DNDK(int formType, [FromForm] User Model/*,[FromForm] Sach model)*/)
        {
            Model.CapDo = 0;
            if (formType == 1)
            {
              
                if (2 == new UserModel().findAcount(Model))
                { 
                    HttpContext.Session.SetString("UserName", Model.TaiKhoan);
                    return RedirectToAction("Index", "Home");
                }
               
            }
            else if (formType == 2)
            {
                if (1 == new UserModel().addAcount(Model)) return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}

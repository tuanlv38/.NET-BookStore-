using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using quanlysachc.Models;

namespace quanlysachc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SachModel sachM = new SachModel();
            sachM.GetFeatureBook();
            ViewBag.dsyeuthich = sachM.dsSach;
            SachModel sachM1 = new SachModel();
            sachM1.selectAllBook();
            ViewBag.dsSach = sachM1.dsSach;
        
            return View();
        }
        public IActionResult Index1()
        {
            SachModel sachM = new SachModel();
            sachM.GetFeatureBook();
            ViewBag.dsyeuthich = sachM.dsSach;
            SachModel sachM1 = new SachModel();
            sachM1.selectAllBook();
            ViewBag.dsSach = sachM1.dsSach;

            return View();
        }


        //    [Route("Home/Privacy/{id:int}")]
        public IActionResult Privacy(int id)
        {
            ViewData["xv"] = id;
            return View();
        }


        public IActionResult Sach() { SachModel chan2 = new SachModel(); ViewBag.ax = chan2.dsSach; return View(); }
    }
}
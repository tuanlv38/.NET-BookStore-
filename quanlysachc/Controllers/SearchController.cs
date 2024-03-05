using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using quanlysachc.Models;

namespace quanlysachc.Controllers
{
    public class SearchController : Controller
    {
        [Route("Search/{orderby?}/{keyword?}/{idsearch?}/{searchby?}/{page?}")]
        public IActionResult Search(int orderby = 0, String keyword = "", int idsearch = -1, int searchby = -1, int page = 1)
        { 
            SachModel sachM = new SachModel();
            sachM.sortBy = orderby;
            if (keyword == null) keyword = " ";
            if (keyword == " " || keyword =="")
            {
                if (idsearch == 4)
                {
                    sachM.selectSachByLoaiSach(searchby);
                }
                else
                if (idsearch == 1)
                {
                    sachM.selectSachByTacGia(searchby);
                }   else
                  if (idsearch == 2)
                {
                    sachM.selectSachByNXB(searchby);
                }else
                {
                    sachM.selectAllBook();
                }
             

            } else
            {
                sachM.searchBook(keyword);
            }
            // tác giả
            LoaiSachModel ls = new LoaiSachModel();
            ls.selectAllLoaiSach();
            ViewBag.dsLoaiSach= ls.dsLoaiSach;
            TacGiaModel tg = new TacGiaModel();
            tg.selectAllTacGia();
            ViewBag.dsTacGia = tg.dsTacGia;
            NXBModel nxb = new NXBModel();
            nxb.selectAllNXB();
            ViewBag.dsNXB = nxb.dsNXB;
            ViewData["opt"] = orderby;
            ViewData["kw"] = keyword;
            ViewData["ids"] = idsearch;
            ViewData["sb"] = searchby;
            ViewData["page"] = page;
            ViewBag.dsSach = sachM.dsSach;
            return View();
        }
    }
}

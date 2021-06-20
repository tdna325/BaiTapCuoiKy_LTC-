using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class MainHomeController : Controller
    {
        public ActionResult Index(string searchString, int page = 1, int pagesize = 15)
        {
            var model = new CategoryDAO().ListAll();
            ViewBag.CategoryList = model.ToList();
            var result = new ProductDAO().ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(result);
        }

    }
}
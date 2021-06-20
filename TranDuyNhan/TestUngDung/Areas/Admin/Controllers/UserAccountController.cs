using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: Admin/UserAccount
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var session = (UserAccount)Session[Common.Constants.USER_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
            var product = new UserDAO();
            var model = product.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            ViewBag.Active = "2";
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var dao = new UserDAO();
            dao.Delete(int.Parse(id));
            return RedirectToAction("Index", "Product");
        }
    }
}
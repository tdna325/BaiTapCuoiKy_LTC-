using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product

        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var session = (UserAccount)Session[Common.Constants.USER_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
            var product = new ProductDAO();
            var model = product.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            ViewBag.Active = "1";
            return View(model);
        }
        [HttpGet]
        public ActionResult Detail(string id)
        {
            var model = new ProductDAO().Find(id);
            ViewBag.Active = "1";
            ViewBag.Next = "-1";
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.Active = "1";
            ViewBag.Next = "-2";
            var model = new CategoryDAO().ListAll();
            ViewBag.CategoryList = new SelectList(model.ToList(),"ID","Name",null);
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product pr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new ProductDAO();
                    dao.Create(pr);
                    return RedirectToAction("Index", "Product");
                }
                var model = new CategoryDAO().ListAll();
                ViewBag.CategoryList = new SelectList(model.ToList(), "ID", "Name", null);
                return View();
            }
            catch (Exception e)
            {
                var model = new CategoryDAO().ListAll();
                ViewBag.CategoryList = new SelectList(model.ToList(), "ID", "Name", null);
                return View();

            }
        }
        public string Upload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/Assets/admin/images/" + file.FileName));
            return "/Assets/admin/images/" + file.FileName;
        }

    }
}
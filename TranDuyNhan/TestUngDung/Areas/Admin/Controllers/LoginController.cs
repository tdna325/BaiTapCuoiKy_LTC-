using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Common.Common.EncryptMD5(user.Password);
                var kq = new UserDAO().Find(user);
                if (kq)
                {
                    ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Common.Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home");
                }
            }  
            ModelState.AddModelError("", "Đăng nhập không thành công");
            return View();
        }
    }
}
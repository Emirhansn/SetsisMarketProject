using SetsisMarketplace.Class;
using SetsisMarketplace.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace SetsisMarketplace.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Market/Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(LoginModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {
                DataService db = new DataService();
               
                if (db.ReturnBoolData("SELECT*FROM Users Where Username='"+model.Username+"' AND Password='"+model.Password+"'"))
                { 
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    return RedirectToAction("Index", "Market");
                }

                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya şifre hatalı!");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Market");
        }
    }
}
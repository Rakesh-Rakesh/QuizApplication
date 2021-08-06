using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuizApplication.Models;
using QuizApplication.ViewModels;

namespace QuizApplication.Controllers
{
    public class AccountController : Controller
    {
        private QuizDBEntities QuizDBEntities;
        public AccountController()
        {
            QuizDBEntities = new QuizDBEntities();
        }
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Admin objAdmin = QuizDBEntities.Admins.SingleOrDefault(model => model.UserName == viewModel.UserName && model.UserPassword == viewModel.Password);
                if (objAdmin == null)
                {
                    ModelState.AddModelError(string.Empty, "Email is not exists ");
                }
                else if (objAdmin.UserPassword != viewModel.Password)
                {
                    ModelState.AddModelError(string.Empty, "Email & Password Invalid");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(viewModel.UserName, false);
                    var authTicekt = new FormsAuthenticationTicket(1, objAdmin.UserName, DateTime.Now, DateTime.Now.AddMinutes(20),
                        false, "Admin");
                    string encryptTicket = FormsAuthentication.Encrypt(authTicekt);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }
        public ActionResult LogOut() 
            {
            FormsAuthentication.SignOut();
                return RedirectToAction("Index","Home");

            } 
    }
}
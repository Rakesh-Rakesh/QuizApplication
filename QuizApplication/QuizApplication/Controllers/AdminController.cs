using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApplication.Models;
using QuizApplication.ViewModels;
namespace QuizApplication.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private QuizDBEntities QuizDBEntities;
        public AdminController()
        {
            QuizDBEntities = new QuizDBEntities();
        }
        // GET: Admin
        public ActionResult Index()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.ListofCategory = (from category in QuizDBEntities.Categories
                                                select new SelectListItem
                                                {
                                                    Value = category.CategoryId.ToString(),
                                                    Text = category.CategoryName
                                                }).ToList();

            return View(categoryViewModel);
        }
    }
}
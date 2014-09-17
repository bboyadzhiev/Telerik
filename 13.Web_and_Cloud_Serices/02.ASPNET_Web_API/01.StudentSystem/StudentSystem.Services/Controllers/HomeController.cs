using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSystem.Data;

namespace StudentSystem.Services.Controllers
{
    public class HomeController : Controller
    {
        private IStudentSystemData data;

        public HomeController()
        {
            this.data = new StudentSystemData();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Student System";

            var students = this.data.Students.All();

            return View(students);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2_WebForm.Models;

namespace Task2_WebForm.Controllers
{
    public class StudentController : Controller
    {
        // GET: Srudent
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Form()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Form(Student s)
        {
            var date = s.DoB.ToString("yyyy-MM-dd");
            return View(s);
        }
    }
}
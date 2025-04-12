using Registration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        RegistrationEntities db = new RegistrationEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var student = db.Students.Find(id);
            if(student == null)
            {
                TempData["Msg"] = "Student not found";
                return View();
            }
            Session["Student_ID"] = id;
            return RedirectToAction("ViewProfile", "Student");
        }

    }
}
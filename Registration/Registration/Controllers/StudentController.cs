using Registration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class StudentController : Controller
    {
        RegistrationEntities db = new RegistrationEntities();
        bool checkCredentials()
        {
            if (Session["Student_ID"] == null)
            {
                @TempData["Msg"] = "Please login to view your profile.";
                return false;
            }
            return true;
        }
        // GET: Student
        [HttpGet]
        public ActionResult ViewProfile()
        {
            if (!checkCredentials())
            {
                return RedirectToAction("Index", "Home");
            }
            var student = db.Students.Find(Session["Student_ID"]);
            return View(student);
        }
    }
}
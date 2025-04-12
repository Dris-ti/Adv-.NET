using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.EF;

namespace Test.Controllers
{
    public class StudentController : Controller
    {
        TestEntities db = new TestEntities();
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var dept = db.Departments.ToList();
            return View(dept);
        }

        [HttpPost]
        public ActionResult Add(Student s)
        {
            db.Students.Add(s);
            var row = db.SaveChanges();
            if(row > 0)
            {
                TempData["Msg"] = "Student Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Student Not Added";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var student = db.Students.Find(Id);
            ViewBag.dept = db.Departments.ToList();
            return View(student);
        }



    }
}
using Lab1_Studenet_Dept_Management.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1_Studenet_Dept_Management.Controllers
{
    public class StudentController : Controller
    {
        Lab1Entities3 db = new Lab1Entities3 ();
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            var students = db.Students.Include("Department").ToList();  
            return View(students);
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            var depts = db.Departments.ToList();
            return View(depts);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student s)
        {
            Student std = new Student();
            std.Name = s.Name;
            std.Cgpa = s.Cgpa;
            std.D_Id = s.Id;

            db.Students.Add(std);
            if (db.SaveChanges() > 0)
            {
                TempData["Msg"] = "Student updated Successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Failed to update student.";
                return View(s);
            }
        }
    }
}
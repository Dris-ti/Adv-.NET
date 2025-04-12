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
            var students = db.Students.ToList();  
            return View(students);
        }

        [HttpGet]
        public ActionResult Scholarships()
        {
            var students = (from s in db.Students
                            where s.Cgpa >= 3.75
                            select s).ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Probation()
        {
            var students = (from s in db.Students
                            where s.Cgpa < 2.00
                            select s).ToList();
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
            db.Students.Add(s);
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

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = db.Students.Find(id);
            var depts = db.Departments.ToList();

            ViewBag.Dept = depts;
            return View(student);

        }

        [HttpPost]
        public ActionResult EditStudent(Student s)
        {
            var prevS = db.Students.Find(s.Id);

            if (prevS != null)
            {
                prevS.Name = s.Name;
                prevS.Cgpa = s.Cgpa;
                prevS.D_Id = s.D_Id;
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
            else
            {
                TempData["Msg"] = "Student not found.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                if (db.SaveChanges() > 0)
                {
                    TempData["Msg"] = "Student deleted Successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Msg"] = "Failed to delete student.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["Msg"] = "Student not found.";
                return RedirectToAction("Index");
            }
        }
    }
}
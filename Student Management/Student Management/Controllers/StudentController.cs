using Student_Management.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management.Controllers
{
    public class StudentController : Controller
    {
        Adv_Dot_NetEntities5 db = new Adv_Dot_NetEntities5();
        // GET: Student
        [HttpGet]
        public ActionResult AllStudents()
        {
            var students = db.Students.Include("Department").ToList();
            return View(students);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }
        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            db.Students.Add(s);
            var row = db.SaveChanges();
            if(row > 0)
            {
                TempData["Message"] = "Student Added Successfully";
                return RedirectToAction("AllStudents");
            }
            else
            {
                TempData["Message"] = "Student Not Added";
                return View(s);
            }            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var db_s = db.Students.Find(s.Id);
            db_s.Name = s.Name;
            db_s.DoB = s.DoB;
            db_s.Department_ID = s.Department_ID;
            db_s.Cgpa = s.Cgpa;
            var row = db.SaveChanges();
            if (row > 0)
            {
                TempData["Message"] = "Student Updated Successfully";
                return RedirectToAction("AllStudents");
            }
            else
            {
                TempData["Message"] = "Student Not Updated";
                return View(s);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                TempData["Message"] = $"Student '{student.Name}' deleted successfully.";
            }

            return RedirectToAction("AllStudents");
        }
    }
}
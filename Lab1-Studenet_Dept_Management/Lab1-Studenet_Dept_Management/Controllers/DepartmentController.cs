using Lab1_Studenet_Dept_Management.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1_Studenet_Dept_Management.Controllers
{
    public class DepartmentController : Controller
    {
        Lab1Entities3 db = new Lab1Entities3();
        // GET: Department
        [HttpGet]
        public ActionResult Index()
        {
            var depts = db.Departments.ToList();
            return View(depts);
        }

        [HttpGet]
        public ActionResult CreateDept()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDept(Department d)
        {
            db.Departments.Add(d);
            var row = db.SaveChanges();
            if(row > 0)
            {
                TempData["Msg"] = "Department Created Successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Department Creation Failed.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditDept(int id)
        {
            var dept = db.Departments.Find(id);
            return View(dept);          
        }

        [HttpPost]
        public ActionResult EditDept(Department d)
        {
            var prevD = db.Departments.Find(d.Id);
            if (prevD != null)
            {
                prevD.Title = d.Title;
                var row = db.SaveChanges();
                if (row > 0)
                {
                    TempData["Msg"] = "Department Information's change Successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Msg"] = "Department Information change Failed..";
                    return View();
                }
            }
            else
            {
                TempData["Msg"] = "Department Information change Failed..";
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteDept(int id)
        {
            var d = db.Departments.Find(id);
            if (d != null)
            {
                db.Departments.Remove(d);
                var row = db.SaveChanges();
                if(row > 0)
                {
                    TempData["Msg"] = "Department Deleted Successfully.";
                }
                else
                {
                    TempData["Msg"] = "Department Deletion Failed.";
                }   
            }
            return RedirectToAction("Index");

        }
    }
}
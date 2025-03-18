using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Education()
        {
            Education e1 = new Education()
            {
                degree = "BSc",
                institution = "AIUB",
                year = 2020
            };
            Education e2 = new Education()
            {
                degree = "HSC",
                institution = "QSPSC",
                year = 2020
            };
            Education e3 = new Education()
            {
                degree = "SSC",
                institution = "QWE",
                year = 2018

            };

            Education[] eds = new Education[] { e1, e2, e3}; 

            

            return View(eds);
        }

        public ActionResult Projects()
        {
            Projects p1 = new Projects()
            {
                course = "OOP1",
                title = "Let's Eat",
                grade = 4.00f
            };

            Projects p2 = new Projects()
            {
                course = "OOP2",
                title = "Skyline",
                grade = 4.00f
            };

            Projects p3 = new Projects()
            {
                course = "Adv Web Tech",
                title = "Tour Planner",
                grade = 4.00f
            };

            Projects[] prjs = new Projects[] { p1, p2, p3 };

            return View(prjs);
        }

        public ActionResult Ref()
        {
            return View();
        }


    }
}
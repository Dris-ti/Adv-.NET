using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Students()
        {
            return View();
        }

        public ActionResult Get_All_Students()
        {
            ViewBag.Message = "All students Information is shown below.";

            List<Students_Info> info = new List<Students_Info>
            {
                new Students_Info { Id = 1, Name = "Dristi", Year = 2022},
                new Students_Info { Id = 2, Name = "Disha", Year = 2023},
                new Students_Info { Id = 3, Name = "Efadh", Year = 2024},

            };

            return View(info);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForm.Models;

namespace WebForm.Controllers
{
    public class WebFormController : Controller
    {
        // GET: WebForm
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(new User());
        }

        
        [HttpPost]
        public ActionResult Form(FormCollection fc, User u, string name, string email, string gender, string country, string[] hobbies) {
            //using FormCollection
            ViewBag.name = fc["name"];
            ViewBag.email = fc["email"];
            ViewBag.gender = fc["gender"];
            ViewBag.country = fc["country"];
            ViewBag.hobbies = fc["hobbies"];


            //using HttpRequest
            ViewBag.name = Request["name"];
            ViewBag.email = Request["email"];
            ViewBag.gender = Request["gender"];
            ViewBag.country = Request["country"];
            ViewBag.hobbies = Request["hobbies"];

            //using Variable name mapping
            ViewBag.name = name;
            ViewBag.email = email;
            ViewBag.gender = gender;
            ViewBag.country = country;
            ViewBag.hobbies = hobbies;

        
            //using Model binding
            return View(u);
        }
    }
}
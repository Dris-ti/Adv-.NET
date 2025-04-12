using Registration.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.Controllers
{
    public class RegistrationController : Controller
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

        string getSemester()
        {
            var date = DateTime.Now;
            string semester = "";
            if (date.Month >= 1 && date.Month <= 5)
            {
                semester = "Spring" + date.ToString("yy");
            }
            else if (date.Month >= 6 && date.Month <= 8)
            {
                semester = "Summer" + date.ToString("yy");
            }
            else
            {
                semester = "Fall" + date.ToString("yy");
            }
            return semester;
        }

        bool isAlreadyRegistered(int courseId, int studentId, int regId)
        {
            var reg = (from cs in db.CourseStudents
                       where cs.Course_Id == courseId && cs.Student_Id == studentId && cs.Reg_Id == regId
                       select cs).SingleOrDefault();
            if(reg == null)
            {
                return false;
            }
            return true;
        }
        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            if (!checkCredentials())
            {
                return RedirectToAction("Index", "Home");
            }

            var sId = Int32.Parse(Session["Student_ID"].ToString());
            var data = (from c in db.CourseStudents
                        where c.Student_Id == sId
                        select c).ToList();
            ViewBag.CourseStudents = data;

            var courses = db.Courses.ToList();
            return View(courses);
        }

        [HttpPost]
        public ActionResult Index(int[] Courses)
        {
            var sId = Int32.Parse(Session["Student_ID"].ToString());
            var semester = getSemester();

            var reg = (from r in db.Registrations
                       where r.Student_Id == sId && r.Semester == semester
                       select r).SingleOrDefault();

            // Check if the student is already registered for the current semester
            if (reg == null)
            {
                // Namespace and class name for Registration is same. This solves the problem.
                reg = new Registration.EF.Registration()
                {
                    EnrollDate = DateTime.Now,
                    Semester = semester,
                    Status = "Enrolled",
                    Student_Id = sId
                };
                db.Registrations.Add(reg);
                db.SaveChanges();
            }

            if (Courses != null)
            {
                foreach (var c in Courses)
                {
                    // Check if the student is already registered for the selected courses
                    if (!isAlreadyRegistered(c, sId, reg.Id))
                    {
                        var course = db.Courses.Find(c);
                        if (course.CourseStudents.Count < course.MaxCapacity)
                        {
                            var cs = new CourseStudent()
                            {
                                Reg_Id = reg.Id,
                                Course_Id = c,
                                Student_Id = sId,
                                Date = DateTime.Now,
                                Status = "Enrolled"
                            };
                            db.CourseStudents.Add(cs);
                        }
                        else
                        {
                            TempData["Msg"] += course.Name + " section is full.";
                        }
                    }
                }
            }
            // Remove existing course
            var prevCourses = (from cs in db.CourseStudents
                                   where cs.Student_Id == sId && cs.Reg_Id == reg.Id
                                   select cs).ToList();
            if(Courses == null || Courses.Length == 0)
            {
                foreach (var pc in prevCourses)
                {
                    db.CourseStudents.Remove(pc);
                }
            }
            else if (prevCourses.Count > Courses.Length)
            {
                foreach (var pc in prevCourses)
                {
                    if (!Courses.Contains(pc.Course_Id))
                    {
                        db.CourseStudents.Remove(pc);
                    }
                }
            }

            db.SaveChanges();

            return RedirectToAction("ViewProfile", "Student");
        }
    }
}
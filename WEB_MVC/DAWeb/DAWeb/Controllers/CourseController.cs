using DAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAWeb.Controllers
{
    public class CourseController : Controller
    {
        DAWebEntities _db = new DAWebEntities();
        // GET: Course
        public ActionResult Course()
        {
            return View();
        }

        public ActionResult getCourse()
        {
            var v = from t in _db.Courses
                    where t.Hide == false
                    orderby t.Order ascending
                    select t;
            return View(v.ToList());
        }
    }
}
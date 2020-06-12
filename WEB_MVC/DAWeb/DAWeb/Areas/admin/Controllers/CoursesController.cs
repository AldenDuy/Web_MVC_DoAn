using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAWeb.Help;
using DAWeb.Models;

namespace DAWeb.Areas.admin.Controllers
{
    public class CoursesController : Controller
    {
        private DAWebEntities db = new DAWebEntities();

        // GET: admin/Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: admin/Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: admin/Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Link,Meta,Hide,Datebegin,Images,Name,CourseID,Descriptions,Level,Order")] Course course, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/images"), filename);
                    img.SaveAs(path);
                    course.Images = filename;
                }
                else
                {
                    course.Images = "logo.png";
                }
                course.Datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                course.Meta = Functions.ConvertToUnSign(course.Name);
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: admin/Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: admin/Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Link,Meta,Hide,Datebegin,Images,Name,CourseID,Descriptions,Level,Order")] Course course, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            Course temp = getById(course.CourseID);
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/images"), filename);
                    img.SaveAs(path);
                    temp.Images = filename;
                }
                temp.Name = course.Name;
                temp.Descriptions = course.Descriptions;
                temp.Hide = course.Hide;
                temp.Order = course.Order;
                temp.Meta = Functions.ConvertToUnSign(course.Meta);
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }
        public Course getById(long coursesid)
        {
            return db.Courses.Where(x => x.CourseID == coursesid).FirstOrDefault();
        }
        // GET: admin/Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

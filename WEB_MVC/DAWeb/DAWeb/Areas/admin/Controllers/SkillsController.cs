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
    public class SkillsController : Controller
    {
        private DAWebEntities db = new DAWebEntities();

        // GET: admin/Skills
        public ActionResult Index()
        {
            return View(db.Skills.ToList());
        }

        // GET: admin/Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: admin/Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Link,Meta,Hide,Datebegin,Media,Name,SkillID,Descriptions,Level,Order")] Skill skill, HttpPostedFileBase audio)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (audio != null)
                {
                    filename = audio.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/audio"), filename);
                    audio.SaveAs(path);
                    skill.Media = filename;
                }
                else
                {
                    skill.Media = "1.+Thank+you,+Mom.mp3";
                }
                skill.Datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                skill.Meta = Functions.ConvertToUnSign(skill.Name);
                db.Skills.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skill);
        }

        // GET: admin/Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: admin/Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Link,Meta,Hide,Datebegin,Media,Name,SkillID,Descriptions,Level,Order")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skill);
        }

        // GET: admin/Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: admin/Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
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

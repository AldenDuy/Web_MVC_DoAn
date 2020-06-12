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
    public class VocabulariesController : Controller
    {
        private DAWebEntities db = new DAWebEntities();

        // GET: admin/Vocabularies
        public ActionResult Index()
        {
            return View(db.Vocabularies.ToList());
        }

        // GET: admin/Vocabularies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = db.Vocabularies.Find(id);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            return View(vocabulary);
        }

        // GET: admin/Vocabularies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Vocabularies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Link,Meta,Hide,Datebegin,Images,Name,TopicID,Descriptions,Order")] Vocabulary vocabulary, HttpPostedFileBase img)
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
                    vocabulary.Images = filename;
                }
                else
                {
                    vocabulary.Images = "logo.png";
                }
                vocabulary.Datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                vocabulary.Meta = Functions.ConvertToUnSign(vocabulary.Name);
                db.Vocabularies.Add(vocabulary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vocabulary);
        }

        // GET: admin/Vocabularies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = db.Vocabularies.Find(id);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            return View(vocabulary);
        }

        // POST: admin/Vocabularies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Link,Meta,Hide,Datebegin,Images,Name,TopicID,Descriptions,Order")] Vocabulary vocabulary, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            Vocabulary temp = getById(vocabulary.TopicID);
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/images"), filename);
                    img.SaveAs(path);
                    temp.Images = filename;
                }
                temp.Name = vocabulary.Name;
                temp.Descriptions = vocabulary.Descriptions;
                temp.Hide = vocabulary.Hide;
                temp.Order = vocabulary.Order;
                temp.Meta = Functions.ConvertToUnSign(vocabulary.Meta);
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vocabulary);
        }

        public Vocabulary getById(long idVoc)
        {
            return db.Vocabularies.Where(x => x.TopicID == idVoc).FirstOrDefault();
        }

        // GET: admin/Vocabularies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = db.Vocabularies.Find(id);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            return View(vocabulary);
        }

        // POST: admin/Vocabularies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vocabulary vocabulary = db.Vocabularies.Find(id);
            db.Vocabularies.Remove(vocabulary);
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

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
    public class GrammarsController : Controller
    {
        private DAWebEntities db = new DAWebEntities();

        // GET: admin/Grammars
        public ActionResult Index()
        {
            return View(db.Grammars.ToList());
        }

        // GET: admin/Grammars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grammar grammar = db.Grammars.Find(id);
            if (grammar == null)
            {
                return HttpNotFound();
            }
            return View(grammar);
        }

        // GET: admin/Grammars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Grammars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Link,Meta,Hide,Datebegin,Images,Name,GrammarID,Descriptions,Level,Order")] Grammar grammar, HttpPostedFileBase img)
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
                    grammar.Images = filename;
                }
                else
                {
                    grammar.Images = "logo.png";
                }
                grammar.Datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                grammar.Meta = Functions.ConvertToUnSign(grammar.Name);
                db.Grammars.Add(grammar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grammar);
        }

        // GET: admin/Grammars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grammar grammar = db.Grammars.Find(id);
            if (grammar == null)
            {
                return HttpNotFound();
            }
            return View(grammar);
        }

        // POST: admin/Grammars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Link,Meta,Hide,Datebegin,Images,Name,GrammarID,Descriptions,Level,Order")] Grammar grammar, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            Grammar temp = getById(grammar.GrammarID);
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/images"), filename);
                    img.SaveAs(path);
                    temp.Images = filename;
                }
                temp.Name = grammar.Name;
                temp.Descriptions = grammar.Descriptions;
                temp.Hide = grammar.Hide;
                temp.Order = grammar.Order;
                temp.Meta = Functions.ConvertToUnSign(grammar.Meta);
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grammar);
        }
        public Grammar getById(long grammarid)
        {
            return db.Grammars.Where(x => x.GrammarID == grammarid).FirstOrDefault();
        }

        // GET: admin/Grammars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grammar grammar = db.Grammars.Find(id);
            if (grammar == null)
            {
                return HttpNotFound();
            }
            return View(grammar);
        }

        // POST: admin/Grammars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grammar grammar = db.Grammars.Find(id);
            db.Grammars.Remove(grammar);
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

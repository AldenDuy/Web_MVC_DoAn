using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAWeb.Models;
using DAWeb.Help;

namespace DAWeb.Areas.admin.Controllers
{
    public class newsController : Controller
    {
        private DAWebEntities db = new DAWebEntities();

        // GET: admin/news
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        // GET: admin/news/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.News.Find(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // GET: admin/news/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/news/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "IdNew,Title,Decription,Link,Meta,Hide,Datebegin,Images,Order,TitleSp")] New news, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if(ModelState.IsValid)
            {
                if (img != null)
                {
                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("~/Areas/admin/ContentAdmin/upload/img"), filename);
                    img.SaveAs(path);
                    news.Images = filename;
                }
                else
                {
                    news.Images = "logo.png";
                }
                news.Datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                news.Meta = Functions.ConvertToUnSign(news.Title);
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(news);
        }

        // GET: admin/news/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.News.Find(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // POST: admin/news/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "IdNew,Title,Decription,Link,Meta,Hide,Datebegin,Images,Order,TitleSp")] New news, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            New temp = getById(news.IdNew);
            if (ModelState.IsValid)
            {
                if(img != null)
                {
                    filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                    path = Path.Combine(Server.MapPath("~/Areas/admin/ContentAdmin/upload/img"), filename);
                    img.SaveAs(path);
                    temp.Images = filename;
                }
                temp.Title = news.Title;
                temp.Decription = news.Decription;
                temp.Hide = news.Hide;
                temp.Order = news.Order;
                temp.Meta = Functions.ConvertToUnSign(news.Meta);
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        public New getById(long idNew)
        {
            return db.News.Where(x => x.IdNew == idNew).FirstOrDefault();
        }

        // GET: admin/news/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New @new = db.News.Find(id);
            if (@new == null)
            {
                return HttpNotFound();
            }
            return View(@new);
        }

        // POST: admin/news/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            New @new = db.News.Find(id);
            db.News.Remove(@new);
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

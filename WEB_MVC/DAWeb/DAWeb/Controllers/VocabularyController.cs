using DAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAWeb.Controllers
{
    public class VocabularyController : Controller
    {
        DAWebEntities _db = new DAWebEntities();
        // GET: Vocabulary
        public ActionResult Vocabulary()
        {
            return View();
        }
        public ActionResult getVocabulary()
        {
            var v = from t in _db.Vocabularies
                    where t.Hide == false
                    orderby t.Order ascending
                    select t;
            return View(v.ToList());
        }
    }
}
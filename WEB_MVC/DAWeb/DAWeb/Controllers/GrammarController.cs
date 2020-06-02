using DAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAWeb.Controllers
{
    public class GrammarController : Controller
    {
        DAWebEntities _db = new DAWebEntities();
        // GET: Grammar
        public ActionResult Grammar()
        {
            return View();
        }

        public ActionResult getGrammar()
        {
            var v = from t in _db.Grammars
                    where t.Hide == false
                    orderby t.Order ascending
                    select t;
            return View(v.ToList());
        }
    }
}
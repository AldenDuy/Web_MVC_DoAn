using DAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAWeb.Controllers
{
    public class NewController : Controller
    {
        DAWebEntities _db = new DAWebEntities();
        // GET: New
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getNew()
        {
            var v = from t in _db.News
                    where t.Hide == false
                    orderby t.Order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}
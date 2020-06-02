using DAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAWeb.Controllers
{
    public class MenuController : Controller
    {
        DAWebEntities _db = new DAWebEntities();
        // GET: Menu
        public ActionResult Index()
        {

            return View();
        }
        
        public ActionResult getMenu()
        {
            var v = from t in _db.Menus
                where t.Hide == false
                orderby t.Order ascending
                select t;
            return PartialView(v.ToList());
        }
    }
}
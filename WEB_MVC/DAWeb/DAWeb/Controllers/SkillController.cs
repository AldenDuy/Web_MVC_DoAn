using DAWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAWeb.Controllers
{
    public class SkillController : Controller
    {
        DAWebEntities _db = new DAWebEntities();
        // GET: Skill
        public ActionResult Skill()
        {
            return View();
        }

        public ActionResult getSkill()
        {
            var v = from t in _db.Skills
                    where t.Hide == false
                    orderby t.Order ascending
                    select t;
            return View(v.ToList());
        }
    }
}
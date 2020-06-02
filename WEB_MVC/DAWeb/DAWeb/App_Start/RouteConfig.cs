using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DAWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Menu", "{type}/{meta}",
            new { controller = "Menu", action = "getMenu", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "trang-chu"}
            },
            new[] { "DAWeb.Controllers" });

            routes.MapRoute("Course", "{type}/{meta}",
            new { controller = "Course", action = "getCourse", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "khoa-hoc"}
            },
            new[] { "DAWeb.Controllers" });

            routes.MapRoute("Skill", "{type}/{meta}",
            new { controller = "Skill", action = "getSkill", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "ky-nang"}
            },
            new[] { "DAWeb.Controllers" });

            routes.MapRoute("Grammar", "{type}/{meta}",
            new { controller = "Grammar", action = "getGrammar", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "ngu-phap"}
            },
            new[] { "DAWeb.Controllers" });

            routes.MapRoute("Vocabulary", "{type}/{meta}",
            new { controller = "Vocabulary", action = "getVocabulary", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "tu-vung"}
            },
            new[] { "DAWeb.Controllers" }); 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

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
                { "type", ""}
            },

            

            namespaces: new[] { "DAWeb.Controllers" });
            routes.MapRoute("Login", "{type}/{meta}",
            new { controller = "Login", action = "IndexLogin", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "dang-nhap"}
            },

             namespaces: new[] { "DAWeb.Controllers" });
            routes.MapRoute("Register", "{type}/{meta}",
            new { controller = "Login", action = "Register", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "dang-ky"}
            },

            namespaces: new[] { "DAWeb.Controllers" });
            routes.MapRoute("Course", "{type}/{meta}",
            new { controller = "Course", action = "getCourse", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "khoa-hoc"}
            },
            namespaces: new[] { "DAWeb.Controllers" });

            routes.MapRoute("Skill", "{type}/{meta}",
            new { controller = "Skill", action = "getSkill", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "ky-nang"}
            },
            namespaces: new[] { "DAWeb.Controllers" });

            routes.MapRoute("Grammar", "{type}/{meta}",
            new { controller = "Grammar", action = "getGrammar", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "ngu-phap"}
            },
            namespaces: new[] { "DAWeb.Controllers" });

            routes.MapRoute("Vocabulary", "{type}/{meta}",
            new { controller = "Vocabulary", action = "getVocabulary", meta = UrlParameter.Optional },
            new RouteValueDictionary
            {
                { "type", "tu-vung"}
            },
            namespaces: new[] { "DAWeb.Controllers" }); 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

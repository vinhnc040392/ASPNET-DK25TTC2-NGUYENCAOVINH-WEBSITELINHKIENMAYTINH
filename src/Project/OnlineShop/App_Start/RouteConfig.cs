using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatitle}-{cateId}",
                defaults: new { controller = "ProductHome", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
               name: "Product Detail",
               url: "chi-tiet/{metatitle}-{id}",
               defaults: new { controller = "ProductHome", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new { controller = "AboutHome", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "ContactHome", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "CartHome", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "CartHome", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new { controller = "CartHome", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
              name: "Payment Success",
              url: "hoan-thanh",
              defaults: new { controller = "CartHome", action = "Success", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
          );

            routes.MapRoute(
              name: "Payment Error",
              url: "loi-hoan-thanh",
              defaults: new { controller = "CartHome", action = "Error", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
          );

            routes.MapRoute(
             name: "FeedBack Success",
             url: "thanh-cong",
             defaults: new { controller = "ContactHome", action = "Success", id = UrlParameter.Optional },
             namespaces: new[] { "OnlineShop.Controllers" }
         );

            routes.MapRoute(
           name: "Register",
           url: "dang-ky",
           defaults: new { controller = "UserHome", action = "Register", id = UrlParameter.Optional },
           namespaces: new[] { "OnlineShop.Controllers" }
       );

            routes.MapRoute(
          name: "Login",
          url: "dang-nhap",
          defaults: new { controller = "UserHome", action = "Login", id = UrlParameter.Optional },
          namespaces: new[] { "OnlineShop.Controllers" }
      );

            routes.MapRoute(
        name: "Search",
        url: "tim-kiem",
        defaults: new { controller = "ProductHome", action = "Search", id = UrlParameter.Optional },
        namespaces: new[] { "OnlineShop.Controllers" }
    );

            routes.MapRoute(
        name: "Content",
        url: "tin-tuc",
        defaults: new { controller = "ContentHome", action = "Index", id = UrlParameter.Optional },
        namespaces: new[] { "OnlineShop.Controllers" }
    );

            routes.MapRoute(
               name: "Content Detail",
               url: "tin-tuc/{metatitle}-{id}",
               defaults: new { controller = "ContentHome", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );
        }
    }
}

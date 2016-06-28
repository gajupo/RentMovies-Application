using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //ENABLE SORT OF CATCHING
        //add the method to the cache, or you can apply this attribute to the controller to cache all actions
        //only use cache when the page does not need to be refresh frequently

        //[OutputCache(Duration = 50,Location = OutputCacheLocation.Server,VaryByParam = "*")]

        //DISABLE CACHING

        //[OutputCache(Duration = 0, VaryByParam = "*",NoStore = true)]
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
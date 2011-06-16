using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFlixFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Top titles at NetFlix";

            return View(GetTopTitles());
        }

        public IQueryable<NetFlixService.Title> GetTopTitles()
        {
            var netFlix = new NetFlixService.NetflixCatalog(new Uri(@"http://odata.netflix.com/v2/Catalog"));

            return (from title in netFlix.Titles
                    orderby title.AverageRating descending
                    select title).Take(5);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

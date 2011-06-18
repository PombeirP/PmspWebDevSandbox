using System;
using System.Linq;
using System.Web.Mvc;
using NetFlixFrontEnd.NetFlixService;

namespace NetFlixFrontEnd.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Top titles at NetFlix";

			return View(GetTopTitles());
		}

		public IQueryable<Title> GetTopTitles()
		{
			var netFlix = new NetflixCatalog(new Uri(@"http://odata.netflix.com/v2/Catalog"));

			return (from title in netFlix.Titles
					orderby title.AverageRating descending
					select title).Take(20);
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
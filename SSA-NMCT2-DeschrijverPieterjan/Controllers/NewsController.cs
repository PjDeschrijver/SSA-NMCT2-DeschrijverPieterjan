using SSA_NMCT2_DeschrijverPieterjan.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSA_NMCT2_DeschrijverPieterjan.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            //RSSController.GetFeed();
            return View(NewsRepository.getNews());
        }

    }
}

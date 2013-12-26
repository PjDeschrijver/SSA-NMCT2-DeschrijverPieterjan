using SSA_NMCT2_DeschrijverPieterjan.Models;
using SSA_NMCT2_DeschrijverPieterjan.Models.DAL;
using SSA_NMCT2_DeschrijverPieterjan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSA_NMCT2_DeschrijverPieterjan.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Band> bands = BandRepository.GetBands();
            List<News> news = NewsRepository.getNews();
            List<News> newsIndex = new List<News>();
            List<Band> bandsIndex = new List<Band>();
            for (int i = 0; i <= 2; i++)
            {
                newsIndex.Add(news[i]);
                bandsIndex.Add(bands[i]);
            }

            HomeVM model = new HomeVM
            {
                Bands = bandsIndex,
                News = newsIndex
            };

            return View(model);
        }

        [AllowAnonymous]
        public PartialViewResult News()
        {
            List<News> news = NewsRepository.getNews();
            List<News> newsIndex = new List<News>();

            for (int i = 0; i >= 0; i--)
            {
                newsIndex.Add(news[i]);
            }

            return PartialView(newsIndex);
        }


        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Sneaky Little Festival";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contacteer ons";

            return View();
        }
    }
}

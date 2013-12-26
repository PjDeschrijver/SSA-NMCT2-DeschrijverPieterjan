using SSA_NMCT2_DeschrijverPieterjan.Models.DAL;
using SSA_NMCT2_DeschrijverPieterjan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSA_NMCT2_DeschrijverPieterjan.Controllers
{
    public class BandController : Controller
    {
        //
        // GET: /Band/

        public ActionResult Index(string SelectedDate)
        {
            ViewBag.Message = "De Line Up.";

            var ViewModel = new LineupVM();

            ViewModel.Dates = LineupRepository.GetAllDays();

            if (SelectedDate != null)
            {

                DateTime DTSelectedDate = Convert.ToDateTime(SelectedDate);
                string DTSelectedDate1 = DTSelectedDate.ToString("yyyy-MM-dd");

                ViewModel.LineUps = LineupRepository.GetLineupByDate(DTSelectedDate1);
                ViewModel.SelectedDate = SelectedDate;
            }
            else {
                ViewModel.LineUps = LineupRepository.GetLineup();
            }

            return View(ViewModel);
        }

        [AllowAnonymous]
        public ActionResult Details(string id)
        {
            BandLineUpVM model = new BandLineUpVM
            {
                Band = BandRepository.FindById(id),
                LineUp = LineupRepository.getLineUpByBand(Convert.ToInt32(id))
            };
            return View(model);
        }

        public PartialViewResult LineUp(int id)
        {
            return PartialView(LineupRepository.getLineUpByBand(id));
        }

    }
}

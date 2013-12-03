using SSA_NMCT2_DeschrijverPieterjan.Models;
using SSA_NMCT2_DeschrijverPieterjan.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSA_NMCT2_DeschrijverPieterjan.Controllers
{
    public class TicketController : Controller
    {
        //
        // GET: /Ticket/
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View(TicketRepository.GetTickets());
        }

        [Authorize(Roles = "Admin, Visitor")]
        public ActionResult BestelTicket() {
            return View();
        }

        [HttpPost]
        public ActionResult BestelTicket(Ticket t) {
            TicketRepository.SetTicket(t);
            return RedirectToAction("BestelTicket");
        }
    }
}

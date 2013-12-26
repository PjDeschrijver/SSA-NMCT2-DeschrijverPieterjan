using SSA_NMCT2_DeschrijverPieterjan.Models;
using SSA_NMCT2_DeschrijverPieterjan.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

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
            string id = WebSecurity.CurrentUserId.ToString();
            User u = UserRepository.GetUserById(id);
            t.TicketHolderEmail = u.Email;
            TicketRepository.SetTicket(t);



            return RedirectToAction("OverzichtTicket", new { Email = u.Email});
        }


         [Authorize(Roles = "Admin, Visitor")]
        public ActionResult OverzichtTicket(string Email)
        {
            
            return View(TicketRepository.getTicketTypeByEmail(Email));
        }

        public ActionResult BevestigingBestelling() {
            return View();
        }
    }
}

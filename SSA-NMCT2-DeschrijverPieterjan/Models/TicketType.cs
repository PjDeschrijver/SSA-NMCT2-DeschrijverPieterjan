using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models
{
    public class TicketType
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AvailableTickets { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
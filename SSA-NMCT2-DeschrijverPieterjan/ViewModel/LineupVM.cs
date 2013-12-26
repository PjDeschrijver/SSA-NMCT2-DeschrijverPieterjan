using SSA_NMCT2_DeschrijverPieterjan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.ViewModel
{
    public class LineupVM
    {
        public List<Lineup> Dates { get; set; }
        public string Date { get; set; }
        public Lineup SelectedLineUp { get; set; }
        public string SelectedDate { get; set; }
        public string Band { get; set; }
        public string Stage { get; set; }
        public List<Lineup> LineUps { get; set; }
    }
}
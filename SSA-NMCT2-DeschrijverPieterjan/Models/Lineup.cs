using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models
{
    public class Lineup
    {
        
            public int ID { get; set; }
            //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public string Date { get; set; }
            public String From { get; set; }
            public String Until { get; set; }
            public Stage Stage { get; set; }
            public Band Band { get; set; }
        
    }
}
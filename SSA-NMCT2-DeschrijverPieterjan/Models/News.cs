using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA_NMCT2_DeschrijverPieterjan.Models
{
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string Author { get; set; }
    }
}
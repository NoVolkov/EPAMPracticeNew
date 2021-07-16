using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SstuEpam.Shops.PL.AspPL.Models
{
    public class CommentModel
    {
        public long IdStore { get; set; }
        public string FIOuser { get; set; }
        public string Text { get; set; }
        public string Rating { get; set; }
    }
}
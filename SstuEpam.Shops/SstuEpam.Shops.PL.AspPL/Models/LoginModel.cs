using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SstuEpam.Shops.PL.AspPL.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password{ get;set;}
        public bool Remember { get; set; }
    }
}
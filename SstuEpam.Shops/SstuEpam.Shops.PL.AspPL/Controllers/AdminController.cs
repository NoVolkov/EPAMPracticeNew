using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SstuEpam.Shops.PL.AspPL.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult UsersPage()
        {
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SstuEpam.Shops.PL.AspPL.Controllers
{
    //Контроллер для взаимодействия с зарегестрированными пользователями
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}
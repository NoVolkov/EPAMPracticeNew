using SstuEpam.Shops.BLL.Interfaces;
using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SstuEpam.Shops.PL.AspPL.Controllers
{
    public class LogRegController : Controller
    {
        IUsersBLL bllUser;
        public LogRegController()
        {
            bllUser = DependencyResolver.Dependencies.Instance.GetUsersBLL;
        }
        //Стр логина
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(User u)
        {
            //Проверка на наличие существующего пользователя
            return RedirectToAction("Home/Index");

        }

        //Стр регистрации
        [HttpGet]
        public ActionResult RegistrationPage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RegistrationPage(User u)
        {
            //Проверки
            bllUser.AddUser(u);
            return RedirectToAction("Home/Index");
        }
    }
}
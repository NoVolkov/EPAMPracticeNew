using SstuEpam.Shops.BLL.Interfaces;
using SstuEpam.Shops.Entities;
using SstuEpam.Shops.PL.AspPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        // -- добавить через куки функ. Остаться в системе
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public ActionResult LoginPage(LoginModel userEnter)
        {
            if (Session["id"]!=null&&!Session["id"].Equals(-1)) 
            {
                ViewData["ErrorMes"] += "Выйдите из под нанешней учётной записи.\n";
                return View(new LoginModel());
            }
            // -- сделать на стороне BLL проверку на сущ данной записи
            User dbUser = bllUser.GetUserByEmail(userEnter.Email);
            if (dbUser == null)
            {
                ViewData["ErrorMes"] += "Данной учётной записи не существует.";
            }
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(userEnter.Password));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data) { sb.Append(b.ToString("x2")); }
            if (!sb.ToString().Equals(dbUser.Password))
            {
                ViewData["ErrorMes"] += "Неправильный пароль.";
                return View(new LoginModel());
            }

            if (userEnter.Remember)
            {
                //запомнить данные в куки
            }
            else
            {
                //запомнить в текущей сессии
                Session["id"] = dbUser.Id;
                Session["surname"] = dbUser.Surname;
                Session["name"] =dbUser.Name;
                Session["patronymic"] =dbUser.Patronymic;
                Session["email"] =dbUser.Email;
                Session["role"] =dbUser.Role;
            }
            return RedirectToAction("../Home/Index");

        }

        //Стр регистрации
        [HttpGet]
        public ActionResult RegistrationPage()
        {

            return View(new RegistrationModel());
        }
        [HttpPost]
        public ActionResult RegistrationPage(RegistrationModel newUser)
        {
            //Проверки
            //возвращать ошибку: такой email уже зарегестрирован
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(newUser.Password));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data) { sb.Append(b.ToString("x2")); }
            User u = new User(
                -1,
                newUser.Surname,
                newUser.Name,
                newUser.Patronymic,
                newUser.Email,
                sb.ToString(),
                "USER"
                );
            bllUser.AddUser(u);
            return RedirectToAction("../Home/Index");
        }
        
    }
}
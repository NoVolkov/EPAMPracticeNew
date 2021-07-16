using SstuEpam.Shops.BLL.Interfaces;
using SstuEpam.Shops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SstuEpam.Shops.PL.AspPL.Controllers
{
    //Контроллер для взаимодействия с зарегестрированными пользователями
    public class AccountController : Controller
    {
        IUsersBLL bllUser;
        public AccountController()
        {
            bllUser = DependencyResolver.Dependencies.Instance.GetUsersBLL;
        }

        //Стр пользователя
        [HttpGet]
        public ActionResult UserPage()
        {
            long idUser;
            if (Session["id"] != null && !Session["id"].Equals(-1))
            {
               idUser = (int)Session["id"];
            }
            else
            {
                if (HttpContext.Request.Cookies["id"].Value != null && !HttpContext.Request.Cookies["id"].Value.Equals("-1"))
                {
                    idUser = Int64.Parse(HttpContext.Request.Cookies["id"].Value);
                }
                else
                {
                    return RedirectToAction("../LogReg/LoginPage");
                }
                
            }
            //Сделать модель пользователя и под неё переделать
            return View(bllUser.GetUserById(idUser));
        }

        //Стр редактирования
        // -- Запретить смену email
        [HttpGet]
        public ActionResult UserEditPage()
        {
            User u = new User(
                (long)Session["id"],
                (string)Session["surname"],
                (string)Session["name"],
                (string)Session["patronymic"],
                (string)Session["email"],
                "",
                (string)Session["role"]
                );
            return View(u);
        }
        //??HttpPut
        
        [HttpPost]
        public ActionResult UserEditPage(User u)
        {
            if (u.Name == null &&
                u.Surname == null &&
                u.Patronymic == null &&
                u.Email == null &&
                u.Password == null) return View();
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(u.Password));
            StringBuilder sb = new StringBuilder();
            foreach(byte b in data) { sb.Append(b.ToString("x2")); }
            string newPassword = sb.ToString();
            User newUser = new User(u.Id,u.Surname,u.Name,u.Patronymic,u.Email,newPassword,"USER");
            bllUser.EditUser(u.Email, newUser);
            return RedirectToAction("UserPage");
        }

        //Удаление пользователя
        [HttpDelete]
        public ActionResult DeleteUser()
        {
            //добавить подтверждение удаления
            bllUser.RemoveUser((string)Session["email"]);
            //добавить разлогирование
            return RedirectToAction("Home/Index");
        }
    }
}
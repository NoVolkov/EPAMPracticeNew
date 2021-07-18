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
               idUser = (long)Session["id"];
            }
            else
            {
                if (HttpContext.Request.Cookies["id"]!= null && !HttpContext.Request.Cookies["id"].Value.Equals("-1"))
                {
                    idUser = Int64.Parse(HttpContext.Request.Cookies["id"].Value);
                }
                else
                {
                    return RedirectToAction("../LogReg/LoginPage");
                }
                
            }
            User u = bllUser.GetUserById(idUser);

            
            return View(new UserModel(u));
        }

        //Стр редактирования
        // -- Запретить смену email
        [HttpGet]
        public ActionResult UserEditPage()
        {
            long idUser;
            if (Session["id"] != null && !Session["id"].Equals(-1))
            {
                idUser = (long)Session["id"];
            }
            else
            {
                if (HttpContext.Request.Cookies["id"] != null && !HttpContext.Request.Cookies["id"].Value.Equals("-1"))
                {
                    idUser = Int64.Parse(HttpContext.Request.Cookies["id"].Value);
                }
                else
                {
                    return RedirectToAction("../LogReg/LoginPage");
                }

            }
            User u = bllUser.GetUserById(idUser);
            return View(new UserModel(u));
        }
        //??HttpPut
        
        [HttpPost]
        public ActionResult UserEditPage(UserModel u)
        {
            string email;
            if (Session["email"] != null && !Session["email"].Equals(-1))
            {
                email = (string)Session["email"];
            }
            else
            {
                if (HttpContext.Request.Cookies["email"]!= null && !HttpContext.Request.Cookies["email"].Value.Equals("-1"))
                {
                    email = HttpContext.Request.Cookies["email"].Value;
                }
                else
                {
                    return RedirectToAction("../LogReg/LoginPage");
                }

            }
            if (u.Name == null &&
                u.Surname == null &&
                u.Patronymic == null &&
                u.Password == null) return RedirectToAction("UserEditPage");
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(u.Password));
            StringBuilder sb = new StringBuilder();
            foreach(byte b in data) { sb.Append(b.ToString("x2")); }
            string newPassword = sb.ToString();
            User newUser = new User(u.Surname,u.Name,u.Patronymic,newPassword);
            bllUser.EditUser(email, newUser);
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
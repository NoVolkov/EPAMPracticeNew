﻿using SstuEpam.Shops.BLL.Interfaces;
using SstuEpam.Shops.Entities;
using SstuEpam.Shops.PL.AspPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SstuEpam.Shops.PL.AspPL.Controllers
{
    //Контроллер для общедоступных страниц
    //Для страниц, требующих авторизацию, перенаправление на страницу логина/регистрации
    public class HomeController : Controller
    {
        IStoresBLL bllStores;
        ICommentsBLL bllComments;
        public HomeController()
        {
            bllStores = DependencyResolver.Dependencies.Instance.GetStoresBLL;
            bllComments = DependencyResolver.Dependencies.Instance.GetCommentsBLL;
        }
        //Глав стр со списком магазинов
        [HttpGet]
        public ActionResult Index()
        {
            return View(bllStores.GetStores());
        }
        //Стр магазина
        //-- Добавить список комментариев
        // Home/StorePage/id
        [HttpGet]
        public ActionResult StorePage(int id)
        {
            Store s = bllStores.GetStoreById(id);
            StoreModel sm = new StoreModel(s.Name,s.Address,s.Website,s.Rating);
            List<Comment> list = bllComments.GetCommentByStore(s);
            List<CommentModel> listm = new List<CommentModel>();
            foreach(Comment c in list)
            {
                CommentModel cm = new CommentModel();
                //Добавление в список коментов
            }
            sm.comments = listm;

            return View(sm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
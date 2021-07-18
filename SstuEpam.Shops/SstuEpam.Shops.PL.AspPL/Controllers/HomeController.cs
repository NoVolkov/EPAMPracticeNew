using SstuEpam.Shops.BLL.Interfaces;
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
        IUsersBLL bllUsers;
        public HomeController()
        {
            bllStores = DependencyResolver.Dependencies.Instance.GetStoresBLL;
            bllComments = DependencyResolver.Dependencies.Instance.GetCommentsBLL;
            bllUsers = DependencyResolver.Dependencies.Instance.GetUsersBLL;
        }
        //Глав стр со списком магазинов
        [HttpGet]
        public ActionResult Index()
        {
            
            if(HttpContext.Request.Cookies["id"]!=null)
            {
                if(!HttpContext.Request.Cookies["id"].Value.Equals("-1"))ViewData["username"] = "Ну привет, " + HttpContext.Request.Cookies["surname"].Value + " " + HttpContext.Request.Cookies.Get("name").Value;
            }
            else
            {
                if (Session["id"] != null)
                {
                    if(!Session["id"].Equals(-1))ViewData["username"] = "Ну привет, " + Session["surname"] + " " + Session["name"];
                }
                
            }
            
            return View(bllStores.GetStores());
        }
        //Стр магазина
        //++ Добавить список комментариев
        // Home/StorePage/id
        [HttpGet]
        public ActionResult StorePage(int id)
        {
            Store s = bllStores.GetStoreById(id);
            StoreModel sm = new StoreModel(s.Name,s.Address,s.Website,s.Rating);
            sm.Id = s.Id;
            List<Comment> list = bllComments.GetCommentByStore(s);
            List<CommentModel> listm = new List<CommentModel>();
            foreach(Comment c in list)
            {
                CommentModel cm = new CommentModel();
                User u = bllUsers.GetUserById(c.Id_user);
                cm.FIOuser=u.Surname+" "+u.Name+" "+u.Patronymic;
                cm.Text = c.Text;
                cm.Rating = Convert.ToString(c.Rating);
                listm.Add(cm);
                
            }
            sm.comments = listm;

            return View(sm);
        }
        //Сделать так, чтобы только авторизированные пользователи могли работать с формой и методом
        //?? Просто заблокировать поле и кнопку в представлении
        [HttpPost]
        public ActionResult SendComment(long idStore, string text, string rating)
        {
            long idUser = (long)Session["id"];
            Comment c = new Comment(idStore,idUser,text,Int32.Parse(rating));
            int oldRatingStore =Int32.Parse(bllStores.GetStoreById(idStore).Rating);
            int quantityComments=bllComments.GetQuantityCommentsByIdStore(idStore);
            int newRatingStore = (oldRatingStore * quantityComments + Int32.Parse(rating)) / (quantityComments + 1);
            bllStores.EditRatingStore(idStore, newRatingStore);
            bllComments.AddComment(c);
            return RedirectToAction("StorePage","Home",new { id=idStore});
        }
    }
}
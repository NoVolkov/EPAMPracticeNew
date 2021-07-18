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
    public class AdminController : Controller
    {
        IStoresBLL bllStore;
        public AdminController()
        {
            bllStore = DependencyResolver.Dependencies.Instance.GetStoresBLL;
        }
        // GET: Admin
        public ActionResult AdminPage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditStore(int id)
        {
            if (Session["role"] != null && !Session["role"].Equals("ADMIN") ||
                HttpContext.Request.Cookies["role"]!= null && !HttpContext.Request.Cookies["role"].Value.Equals("ADMIN"))
            {
                return RedirectToAction("../Home/Index");
            }
            
            Store s = bllStore.GetStoreById(id);
            return View(new StoreModel(s));
        }

        [HttpPost]
        public ActionResult EditStore(StoreModel s)
        {
            if (s.Name == null &&
               s.Website == null &&
               s.Address == null) return RedirectToAction("EditStore", new { id = s.Id });
            Store newStore = new Store(s.Id,s.Name,"",s.Address,s.Website);
            bllStore.EditStore(s.Id, newStore);
            return RedirectToAction("StorePage","Home",new { id=s.Id});
        }

        [HttpGet]
        public ActionResult AddStore()
        {
            return View(new StoreModel());
        }

        [HttpPost]
        public ActionResult AddStore(StoreModel newStore)
        {
            Store s = new Store(
                0,
                newStore.Name,
                "",
                newStore.Address,
                newStore.Website
                );
            bllStore.AddStore(s);
            return Redirect("../Home/Index");
        }

        public ActionResult UsersPage()
        {
            return View();
        }

    }
}
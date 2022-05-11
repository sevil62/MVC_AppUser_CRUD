using MVC_AppUser_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;

namespace MVC_AppUser_CRUD.Controllers
{
    public class AppUserController : Controller
    {
        public static List<AppUser>userList=new List<AppUser>()
        {
            new AppUser{Id=1,UserName="Sevil",FirstName="Sevil",LastName="Aydın",Email="sevil@gmail.com",Password="1234" },
            new AppUser{Id=2,UserName="Tuba",FirstName="Tuba",LastName="Bugday",Email="tuba@gmail.com",Password="1234" },

         } ;
        // GET: AppUser
        public ActionResult Index()
        {
            return View(userList);
        }
        public ActionResult AddAppUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAppUser(AppUser appUser)
        {
            appUser.Id = userList.Count + 1;
            userList.Add(appUser);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var userDetails = userList.Find(x => x.Id == id);
            return View(userDetails);
        }
        public ActionResult Delete(int id)
        {
            var userDetails = userList.Find(x => x.Id == id);
            userList.Remove(userDetails);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var updated = userList.Find(x => x.Id == id);
            return View(updated);
        }
        [HttpPost]
        public ActionResult Update(AppUser appUser)
        {
            AppUser updated = userList.Find(x=>x.Id==appUser.Id);
            if (updated==null)
            {
                return HttpNotFound();
            }
            updated.UserName = appUser.UserName;
            updated.Email=appUser.Email;
            return RedirectToAction("Index");
            
        }
    }
}
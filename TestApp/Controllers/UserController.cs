using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Entity;
using WebChat.Repo;

namespace TestApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = new UserRepo().LoginUser(user.UserName, user.Password);            
            if(usr.UserName!=user.UserName && usr.Password != user.Password)
            {
                return ViewBag.Message("Kullanıcı adı veye şifre yanlış");
            }
            else
            {
                Session["UserId"] = usr.UserId;
                Session["UserName"] = usr.UserName;
                Session["RoleID"] = usr.RoleID;
                return RedirectToAction("Anasayfa", "Home");
                
            }
            
        }
        public ActionResult LogOut()
        {
            Session["UserId"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                string error;
                var userRepo = new UserRepo();
                try
                {
                    userRepo.SaveUser(new User()
                    {
                        UserName = user.UserName,
                        Password = user.Password,
                        Email = user.Email,
                        RoleID=2
                    },out error);
                    Session["UserID"] = user.UserId;
                    Session["UserName"] = user.UserName;
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return RedirectToAction("Login", "User");
        }
    }
}
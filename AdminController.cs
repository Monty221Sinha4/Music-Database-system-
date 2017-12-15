using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWorld.com.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                using(DB dc = new DB())
                {
                    dc.Users.Add(u);
                    dc.SaveChanges();
                    ModelState.Clear();
                    u = null;
                 
                    ViewBag.Message = "Successfully Registration Done";
                }
              
            }

  return View(u);
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            if (ModelState.IsValid)
            {
                using(DB dc = new DB())
                {
                    var v = dc.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoggedUserID"] = v.Id.ToString();
                        Session["LoggedUsername"] = v.Username.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(u);
        }
        public ActionResult Acesss()
        {
            if (Session["LoggedUserID"] != null)
            {
                return View("Access");
            }
            else
            {
                return RedirectToAction("Access");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatesAndCapitalsQuiz_DataAccess.Models;

namespace StatesAndCapitalsQuiz.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateUser(User objUser)
        {
            using (DB_Entities db = new DB_Entities())
            {
                var create = db.Users.Add(objUser);

                try
                {
                    db.SaveChanges();
                    return RedirectToAction("../Login");
                }
                catch
                {
                    return RedirectToAction("/");
                }

            }
        }
    }
}
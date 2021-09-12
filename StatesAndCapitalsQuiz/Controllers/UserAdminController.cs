using StatesAndCapitalsQuiz_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StatesAndCapitalsQuiz.Controllers
{
    public class UserAdminController : Controller
    {
        private DB_Entities db = new DB_Entities();
        // GET: UserAdmin
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult ActivateUser(int id)
        {
            var obj = db.attemps.Where(x => x.UserId == id).FirstOrDefault();
            obj.FailedAttempts = 0;
            db.SaveChanges();

            return RedirectToAction("/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objUser = db.Users.Where(x => x.UserId == id).FirstOrDefault();
            db.Users.Remove(objUser);
            db.SaveChanges();

            return RedirectToAction("/Index");
        }
    }
}
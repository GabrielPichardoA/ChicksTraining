using StatesAndCapitalsQuiz_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StatesAndCapitalsQuiz.Controllers
{
    public class BlockedUserController : Controller
    {
        private DB_Entities db = new DB_Entities();
        // GET: BlockedUser
        public ActionResult Index()
        {
            return View();
        }

        //Method to Activate user if blocked
        public RedirectToRouteResult ActivateUser()
        {
            int value = Int32.Parse(Session["BlockedUser"].ToString());
            var obj = db.attemps.Where(x => x.UserId == value).FirstOrDefault();
            obj.FailedAttempts = 0;
            db.SaveChanges();

            return RedirectToAction("../Login");
        }
    }
}
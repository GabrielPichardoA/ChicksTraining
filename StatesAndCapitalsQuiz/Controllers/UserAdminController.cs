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
    }
}
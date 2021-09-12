using StatesAndCapitalsQuiz_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StatesAndCapitalsQuiz.Controllers
{
    public class QuizReportsController : Controller
    {
        private DB_Entities db = new DB_Entities();
        // GET: QuizReports
        public ActionResult Index()
        {
            return Session["Perfil"].ToString() == "True" ? View(db.TestResults.ToList()) : View("../Shared/Unauthorized");
        }
    }
}
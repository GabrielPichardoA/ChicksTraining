using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StatesAndCapitalsQuiz_DataAccess.Models;
using DashboardDto;

namespace StatesAndCapitalsQuiz.Controllers
{
    public class DashboardController : Controller
    {
        DB_Entities db = new DB_Entities();

        // GET: Dashboard
        public ActionResult Index()
        {
            if(Session["UserName"] != null)
            {
                if (Session["Perfil"] != null)
                {
                    return RedirectToAction("../Maintenance");
                }
                else if (Session["UserName"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("../Login");
                }
            }
            else
            {
                return RedirectToAction("../Login");
            }
            
        }

        [HttpGet]
        public JsonResult getStates()
        {
            List<State> states = new List<State>();

            if (ModelState.IsValid)
            {
                using (DB_Entities db = new DB_Entities())
                {
                    states = db.States.OrderBy(x => Guid.NewGuid()).Take(10)
                        .ToList();

                    states.Select(s => s.StateId);
                }
            }

            return this.Json(states.Select(s => s.State1), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendResponses(List<QuizRequest> request, int TotalQuestions)
        {
            int correct = 0;

            foreach (QuizRequest q in request)
            {
                var assert = db.States.SingleOrDefault(x => x.State1.Equals(q.state) && x.Capital.Equals(q.capital));
                if (assert != null)
                {
                    correct++;
                }
            }

            TestResult result = new TestResult
            {
                UserId = Int16.Parse(Session["UserId"].ToString()),
                TestDateTime = DateTime.Now,
                TotalQuestions = TotalQuestions,
                NumberCorrect = correct
            };

            db.TestResults.Add(result);

            try
            {
                db.SaveChanges();
                QuizResponse response = new QuizResponse
                {
                    data = correct,
                    result = "success"
                };

                return this.Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                QuizResponse response = new QuizResponse
                {
                    data = correct,
                    result = "false"
                };

                return this.Json(response, JsonRequestBehavior.AllowGet);

            }

        }
    }
}
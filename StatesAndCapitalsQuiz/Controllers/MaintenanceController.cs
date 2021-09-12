using StatesAndCapitalsQuiz_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StatesAndCapitalsQuiz.Controllers
{
    public class MaintenanceController : Controller
    {
        private DB_Entities db = new DB_Entities();
        // GET: Maintenance
        public ActionResult Index()
        {
            return Session["Perfil"].ToString() == "True" ? View(db.States.ToList()) : View("../Shared/Unauthorized");
        }

        /// <summary>
        /// Method to update data of the state.
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns>Current value of State object.</returns>
        public ActionResult Update(int? stateId)
        {
            if(stateId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.States.Find(stateId);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        /// <summary>
        /// Update in DataBase the data of the current object.
        /// </summary>
        /// <param name="state"></param>
        /// <returns>The view with the state.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "StateId,State1,Capital")] State state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(state);
        }

        /// <summary>
        /// Method to delete data of the state.
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns>Current value of State object.</returns>
        public ActionResult Delete(int? stateId)
        {
            if (stateId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.States.Find(stateId);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        /// <summary>
        /// Delete in Database the data of the current object.
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns>The principal view to update the list.</returns>
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int stateId)
        {
            State state = db.States.Find(stateId);
            db.States.Remove(state);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Method to create a new State
        /// </summary>
        /// <param name="state"></param>
        /// <returns>Return value of State object.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,State1,Capital")] State state)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(state);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(state);
        }
    }
}
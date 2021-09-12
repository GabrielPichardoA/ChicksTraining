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
            return Session["Perfil"].ToString() == "True" ? View(db.Users.ToList()) : View("../Shared/Unauthorized");
        }

        /// <summary>
        /// Method to Activate User if blocked.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View to display current list of users.</returns>
        [HttpGet]
        public ActionResult ActivateUser(int id)
        {
            var obj = db.attemps.Where(x => x.UserId == id).FirstOrDefault();
            obj.FailedAttempts = 0;
            db.SaveChanges();

            return RedirectToAction("/Index");
        }

        /// <summary>
        /// Method to add admin perfil to an normal user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Current view.</returns>
        public ActionResult SetAdminUser(int id)
        {
            User user = new User()
            {
                UserId = id
            };
            var objProfile = db.User_Profile.Where(x => x.UserId == user.UserId).SingleOrDefault();

            if(objProfile != null)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                User_Profile profile = new User_Profile()
                {
                    admin = true,
                    UserId = id
                };
                db.User_Profile.Add(profile);
                db.SaveChanges();
            }

            return RedirectToAction("/Index");
        }

        /// <summary>
        /// Method to delete an User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Current view to update records.</returns>
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
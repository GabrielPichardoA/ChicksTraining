﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatesAndCapitalsQuiz_DataAccess.Models;

namespace StatesAndCapitalsQuiz.Controllers
{
    public class LoginController : Controller
    {
        private DB_Entities db = new DB_Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            string response = "";

            if (ModelState.IsValid)
            {
                response = validateLogin(objUser);

            }

            return RedirectToAction(response);
        }

        public string validateLogin(User objUser)
        {
            var obj = db.Users.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
            var objuser = db.Users.Where(a => a.UserName.Equals(objUser.UserName)).FirstOrDefault();
            var attemps = 0;

            if (objuser != null && obj == null)
            {
                //logica failed attemps ++
                attemps = failedAttemps(objuser);

                if (attemps == 3)
                {
                    Session["BlockedUser"] = objuser.UserId;
                    return "../BlockedUser";
                }
                
            }

            if (obj != null && attemps < 3)
            {
                clearAttemps(obj);

                Session["UserName"] = obj.UserName.ToString();
                Session["Password"] = obj.Password.ToString();
                Session["UserId"] = obj.UserId.ToString();

                var profile = db.User_Profile.Where(a => a.UserId == obj.UserId).FirstOrDefault();
                if (profile != null)
                {
                    Session["Perfil"] = profile.admin.ToString();
                    if (profile.admin == true)
                    {
                        return "../Maintenance";
                    }
                }
                else
                {
                    return "../Dashboard/Index";
                }
            }else if(attemps < 3)
            {
                return "../Login";
            }

            return "../BlockedUser";
        }

        public void clearAttemps(User user)
        {
            var obj = db.attemps.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if(obj != null)
            {
                obj.FailedAttempts = 0;
                db.SaveChanges();
            }
        }

        public int failedAttemps(User user)
        {
            int q = 0;
            //get user data
            var obj = db.Users.Where(a => a.UserName.Equals(user.UserName)).FirstOrDefault();
            if(obj != null)
            {
                //get attempts if exists
                var attemps = db.attemps.Where(a => a.UserId ==obj.UserId).SingleOrDefault();
                if(attemps != null)
                {
                    //if attempts exists return quantity
                    if(attemps.FailedAttempts < 3)
                    {
                        attemps.FailedAttempts++;
                        db.SaveChanges();
                        
                        q = Int32.Parse(attemps.FailedAttempts.ToString());
                        if(q < 3)
                        {
                            return 1;
                        }
                        else
                        {
                            Session["BlockedUser"] = user.UserId;
                            return Int32.Parse(attemps.FailedAttempts.ToString());
                        }
                    }
                    else
                    {
                        Session["BlockedUser"] = user.UserId;
                        return Int32.Parse(attemps.FailedAttempts.ToString());
                    }
                }
                else
                {
                    //if not attemps insert new attems to userid
                    attemp att = new attemp()
                    {
                        UserId = obj.UserId,
                        FailedAttempts = 1
                    };
                    var create = db.attemps.Add(att);
                    db.SaveChanges();
                    return Int32.Parse(att.FailedAttempts.ToString());

                }
            }
            
            //if user dont exists return 0
            return q;
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("/../Home/Index");
        }
    }
}
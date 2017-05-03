using BlowOut.DAL;
using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        public MissionaryContext db = new MissionaryContext();

        public ActionResult Index()
        {
            ViewBag.Quote1 = "\"After all that has been said, the greatest and most important duty is to preach the Gospel.\" ";
            ViewBag.Quote2 = "- Joseph Smith Jr.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Database()
        {
            return View(db.Users.ToList());
        }
        
        [HttpGet]
            public ActionResult Register()
            {
                return View();
            }

        [HttpPost]
        //user can register
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users user)
        {
            if(ModelState.IsValid)
            {
                
                db.Users.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.first_name + " has successfully been added";
                FormsAuthentication.SetAuthCookie(user.user_email, false); 
            }

            return View();
        }


  //customers login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();
            String QueryString = String.Format("SELECT * FROM Users WHERE user_email ='{0}' AND password = '{1}'", email, password);

            List<Users> users = db.Users.SqlQuery(QueryString).ToList();

            if (users.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("MissionSelectFAQ", "Home");

            }
            else
            {
                return View();
            }
        }
        //allows users to logoff
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoggedIn()
        {
            if(Session["user_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [Authorize]
        public ActionResult MissionSelectFAQ()
        {

            return View();
        }

      [HttpGet]
      [Authorize]
        public ActionResult FAQ(int missionid)
        {
            
            String QueryStringM = String.Format("SELECT * FROM Missions WHERE mission_id = '{0}'", missionid);
            //if statement that determines which mission was clicked
            ViewBag.missionid = missionid;

            string QueryString = String.Format("SELECT * FROM MissionQuestions WHERE mission_id = '{0}'", missionid);
            List<MissionQuestions> answers = db.MissionQuestions.SqlQuery(QueryString).ToList();
          
            if (missionid == 1) 
            {
                Missions ms = db.Missions.SqlQuery(QueryStringM).SingleOrDefault();
                //viewbags created and load information depending on information 
                ViewBag.MissionName = ms.mission_name;
                ViewBag.MissionFlag = "/Content/Images/arkansas.png";
                ViewBag.Maddress = ms.address;
                ViewBag.MPName = ms.president_name;
                ViewBag.Language = ms.language;
                ViewBag.Climate = ms.climate;
                ViewBag.DRel = ms.dominate_religion;

            }
            else if (missionid == 17)
            {
                Missions ms = db.Missions.SqlQuery(QueryStringM).SingleOrDefault();
                ViewBag.MissionName = ms.mission_name;
                ViewBag.MissionFlag = "/Content/Images/dr.png";
                ViewBag.Maddress = ms.address;
                ViewBag.MPName = ms.president_name;
                ViewBag.Language = ms.language;
                ViewBag.Climate = ms.climate;
                ViewBag.DRel = ms.dominate_religion;

            }
            else if (missionid == 18)
            {
                Missions ms = db.Missions.SqlQuery(QueryStringM).SingleOrDefault();
                ViewBag.MissionName = ms.mission_name;
                ViewBag.MissionFlag = "/Content/Images/cal.png";
                ViewBag.Maddress = ms.address;
                ViewBag.MPName = ms.president_name;
                ViewBag.Language = ms.language;
                ViewBag.Climate = ms.climate;
                ViewBag.DRel = ms.dominate_religion;
            }
            return View(answers);
        }

        //FAQ post 
      [HttpPost]
      public ActionResult FAQ()
      {
          //String Question = form["Question"].ToString();
          
          //String QueryStringQ = String.Format("SELECT * FROM MissionQUestions WHERE question ='{0}'", Question);

          List<object> myMission = new List<object>();
          myMission.Add(db.MissionQuestions.ToList());
          myMission.Add(db.MissionQuestions.ToList());

          //List<MissionQuestions> missionquestions = db.MissionQuestions.SqlQuery(QueryStringQ).ToList();

     
          {
              return View();
          }
      }
      //[HttpPost]
      //public ActionResult FAQ(FormCollection form, bool rememberMe2 = true)
      //{
          
      //String Answer = form["Answer"].ToString();
   
      // String QueryStringA = String.Format("SELECT * FROM MissionQUestions WHERE answer ='{0}'", Answer);

      // List<MissionQuestions> missionquestions = db.MissionQuestions.SqlQuery(QueryStringA).ToList();

      // if (missionquestions.Count != null)
      // {
      //     FormsAuthentication.SetAuthCookie(Answer, rememberMe2);

      //     return RedirectToAction("FAQ", "Home");

      // }
      // else
      // {
      //     return View();
      // }
      //}


      // GET: MissionQuestions/Details/5
      public ActionResult Details(int? id)
      {
          if (id == null)
          {
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
          if (missionQuestions == null)
          {
              return HttpNotFound();
          }
          return View(missionQuestions);
      }

      // GET: MissionQuestions/Create
      public ActionResult Create(int? id)
      {
          ViewBag.missionid = id;
          return View();
      }

      // POST: MissionQuestions/Create
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //here is the ask question view
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create([Bind(Include = "mission_question_id,mission_id,user_id,question,answer")] MissionQuestions missionQuestions, int id)
      {
          string email = User.Identity.Name;
          string QueryString = String.Format("SELECT * FROM Users WHERE user_email ='{0}'", email);
          Users user = db.Users.SqlQuery(QueryString).SingleOrDefault();

          missionQuestions.user_id = user.user_id;
          missionQuestions.mission_id = id;

          if (ModelState.IsValid)
          {
              db.MissionQuestions.Add(missionQuestions);
              db.SaveChanges();
              return RedirectToAction("FAQ", new {missionid = missionQuestions.mission_id});
          }

          return View(missionQuestions);
      }

      // GET: MissionQuestions/Edit/5
        //this allows users to ask questions
      public ActionResult Edit(int? id)
      {
          if (id == null)
          {
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
          if (missionQuestions == null)
          {
              return HttpNotFound();
          }
          return View(missionQuestions);
      }

      // POST: MissionQuestions/Edit/5
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit([Bind(Include = "mission_question_id,mission_id,user_id,question,answer")] MissionQuestions missionQuestions)
      {
          if (ModelState.IsValid)
          {
              db.Entry(missionQuestions).State = EntityState.Modified;
              db.SaveChanges();
              return RedirectToAction("FAQ", new { missionid = missionQuestions.mission_id });
          }
          return View(missionQuestions);
      }

      // GET: MissionQuestions/Delete/5
      public ActionResult Delete(int? id)
      {
          if (id == null)
          {
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
          if (missionQuestions == null)
          {
              return HttpNotFound();
          }
          return View(missionQuestions);
      }

      // POST: MissionQuestions/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id)
      {
          MissionQuestions missionQuestions = db.MissionQuestions.Find(id);
          db.MissionQuestions.Remove(missionQuestions);
          db.SaveChanges();
          return RedirectToAction("FAQ");
      }

      protected override void Dispose(bool disposing)
      {
          if (disposing)
          {
              db.Dispose();
          }
          base.Dispose(disposing);
      }

















    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(string MissionName)
        {
            ViewBag.Drop = MissionName;
            
                if(MissionName == "Ark")
                {
                    ViewBag.Drop ="Ark";
                }
                else if(MissionName == "DR")
                {
                    ViewBag.Drop = "DR";
                }
                else if(MissionName == "Cal")
                {
                    ViewBag.Drop = "Cal";
                }


                return View();
        }
        public ActionResult Email(string Name, string Email)
        {
            ViewBag.Name = Name;
            ViewBag.EmailAddress = Email;

            return View();

        }
 

        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Index()
        {
            return View();
            
        }
        //This method gets two parameters
        //receives the mission name and mission
        public ActionResult RentalRates(string MisName, string Mission)
        {
            ViewBag.MisName = MisName;
            ViewBag.Mission = Mission;
            //if statement that determines which mission was clicked
            if ((MisName == "Ark") && (Mission =="Mission"))
            {
                //viewbags created and load information depending on information 
                ViewBag.MissionName = "Arkansas Little Rock Mission";
                ViewBag.MissionFlag = "/Content/Images/arkansas.png";
                ViewBag.Maddress = "905 Kierre Dr, North Little Rock, AR 72116";
                ViewBag.MPName = "President Taniela Biu Wakolo";
                ViewBag.Language = "English";
                ViewBag.Climate = "Subtropical";
                ViewBag.DRel = "Baptist";
               
            }
            else if ((MisName == "DR") && (Mission =="Mission"))
            {
                ViewBag.MissionName = "Dominican Republic Santiago Mission";
                ViewBag.MissionFlag = "/Content/Images/dr.png";
                ViewBag.Maddress = "Av. Estrella Sadhala Plaza Alejo 2-B, Santiago, Dominican Republic";
                ViewBag.MPName = "President John L. Douglas";
                ViewBag.Language = "Spanish";
                ViewBag.Climate = "Beautiful Tropical weather all year round";
                ViewBag.DRel = "Catholic";
            
            }
            else if ((MisName == "Cal") && (Mission =="Mission"))
            {
                ViewBag.MissionName = "California Long Beach Mission";
                ViewBag.MissionFlag = "/Content/Images/cal.png";
                ViewBag.Maddress = "6500 E Atherton, St Long Beach, CA 90815";
                ViewBag.MPName = "President Brian P. Patterson";
                ViewBag.Language = "English";
                ViewBag.Climate = "Mediterranean";
                ViewBag.DRel = "Catholic";
            }
            
            return View();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deliverable_2_WireFrames.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LeaderIndex()
        {
            return View();

        }

        public ActionResult DoctorIndex()
        {
            return View();

        }
    }
}
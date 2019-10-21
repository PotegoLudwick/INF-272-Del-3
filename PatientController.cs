using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patient.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TestView()
        {
            return View();
        }
        public ActionResult UpdatePatient()
        {
            return View();
        }
        public ActionResult CheckOrder()
        {
            return View();
        }
    }
}
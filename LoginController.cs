using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using Deliverable_2_WireFrames.ViewModels;
using Deliverable_2_WireFrames.Models;

namespace Deliverable_2_WireFrames.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Create()
        {
            ViewBag.UserType = new SelectList(db.UserTypes, "UserTypeID", "Description");
            ViewBag.Village = new SelectList(db.Villages, "Village_ID", "Village_Name");
            ViewBag.Gender = new SelectList(db.Genders, "Gender_ID", "Gender_Type");
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hashedpassword = ComputeSha256Hash(user.UserPassword);
                    Models.User NewUser = new User();
              
                    NewUser.Name = user.Name;
                    NewUser.Surname = user.Surname;
                    NewUser.PhoneNumber = user.PhoneNumber;
                    NewUser.Gender = user.Gender;                 
                    NewUser.Village = user.Village;
                    NewUser.UserEmail = user.UserEmail;
                    NewUser.UserPassword = hashedpassword;
                    NewUser.UserType = user.UserType;
                    //leader.Name = leader.Name;
                    db.Users.Add(NewUser);
                    //db.CommunityLeaders.Add(leader);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Login");

                }
            }

            catch (Exception exception)
            {
                throw exception;
            }
            ViewBag.Village = new SelectList(db.Villages, "Village_ID", "Village_Name", user.Village1);
            ViewBag.UserType = new SelectList(db.UserTypes, "UserTypeID", "Description", user.UserType1);
            ViewBag.Gender = new SelectList(db.Genders, "Gender_ID", "Gender_Type",user.Gender1);
            return View(user);
        }

    

        OnlinePharmacyEntities db = new OnlinePharmacyEntities();
        [HttpPost]

        public ActionResult Login(string Username, string Password, User user)
        {

            var hashedpassword = ComputeSha256Hash(Password);

            user = db.Users.Where(zz => zz.UserEmail == Username
                                              && zz.UserPassword == hashedpassword)
                                              .FirstOrDefault();
            if (user != null && user.UserType == 1)
            {
                UserVM userVME = new UserVM();
                userVME.user = user;
                userVME.RefreshGUID(db);
                TempData["userVM"] = userVME;
                return RedirectToAction("Index", "Homepage");

            }

            else if (user != null && user.UserType == 2)
            {
                UserVM userVME = new UserVM();
                userVME.user = user;
                userVME.RefreshGUID(db);
                TempData["userVM"] = userVME;
                return RedirectToAction("Index", "Leader");

            }
            else if (user != null && user.UserType == 5)
            {
                UserVM userVME = new UserVM();
                userVME.user = user;
                userVME.RefreshGUID(db);
                TempData["userVM"] = userVME;
                return RedirectToAction("Index", "Patient");

            }

            else if (user == null )
            {
                ViewBag.Error = "User does not exist";
            }

            return RedirectToAction("Error", "Login");
        }

        public ActionResult Error()
        {
            ViewBag.Error = "Username does not exist";
            return View("Index");
        }

        string ComputeSha256Hash(string Password)
        {
            using (SHA256 sha256Hash = SHA256.Create()) //Create a SHA256
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Password)); // return byte array

                //convert byte array into string
                StringBuilder builder = new StringBuilder();
                for (int x = 0; x < bytes.Length; x++)
                {
                    builder.Append(bytes[x].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}







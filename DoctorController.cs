using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using Deliverable_2_WireFrames.Models;
using Deliverable_2_WireFrames.ViewModels;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Script.Serialization;




namespace Deliverable_2_WireFrames.Controllers

{
    public class DoctorController : Controller
    {
        OnlinePharmacyEntities db = new OnlinePharmacyEntities();

        //string GenerateHashedPassword(string Password)
        //{
        //    try
        //    {
        //        using (SHA256 ShaHash = SHA256.Create())
        //        {
        //            byte[] byteArrayOfPassword = ShaHash.ComputeHash(Encoding.UTF8.GetBytes(Password));
        //            StringBuilder PasswordHashed = new StringBuilder();

        //            for (int Counter = 0; Counter < byteArrayOfPassword.Length; Counter++)
        //            {
        //                PasswordHashed.Append(byteArrayOfPassword[Counter].ToString("x2"));
        //            }

        //            return PasswordHashed.ToString();
        //        }
        //    }
        //    catch (Exception GeneralExceptioin)
        //    {
        //        ViewBag.Error = GeneralExceptioin.Message;
        //        return ViewBag.Error;
        //    }
        //}
        //// GET: Doctor
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult doctorLogin(string Username, string Password, string SignIn, string User, string UserType)
        //{
        //    {
        //        db.Configuration.ProxyCreationEnabled = false;
        //        try
        //        {
        //            if (SignIn == "Sign In")
        //            {
        //                User CheckUser = db.Users.Where(X => X.UserEmail == Username).FirstOrDefault();

        //                if (CheckUser == null)
        //                {
        //                    return View("CreateUser");
        //                }
        //                else
        //                {
        //                    string HashedPassword = GenerateHashedPassword(Password);
        //                    User CheckUserPassword = db.Users.Where(Y => Y.UserEmail == Username & Y.UserPassword == HashedPassword).FirstOrDefault();

        //                    if (CheckUserPassword == null)// if password is incorrect, object is null
        //                    {
        //                        return View("CreateUser");
        //                    }

        //                    else
        //                    {
        //                        UserType CheckUserType = new UserType();
        //                        CheckUserType = db.UserTypes.Where(Z => Z.ID == CheckUser.UserType).FirstOrDefault();

        //                        if (CheckUserType.Description == "Doctor")
        //                        {
        //                            return RedirectToAction("CreateUser", "Doctor");
        //                        }
        //                        else
        //                        {

        //                            return View("CreateUser", CheckUser);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception GeneralExceptioin)
        //        {
        //            ViewBag.Error = GeneralExceptioin.Message;
        //            return View();
        //        }

        //        return View();
        //    }

        //}
        //public ActionResult CreateUser(string Name, string Surname, string UserType, string Username, string Password, string ConfirmedPassword, string btnSubmit)
        //{
        //    {
        //        if (btnSubmit == "Submit")
        //        {
        //            if (Password != ConfirmedPassword)
        //            {
        //                ViewBag.PasswordMatchError = "Passwords do not match, please re-enter!";
        //            }
        //            else
        //            {
        //                User newUser = new User();
        //                Doctor newDoctor = new Doctor();

        //                newDoctor.Doctor_Email = Name;
        //                newDoctor.Doctor_Name = Surname;

        //                UserType CheckForUserType = db.UserTypes.Where(X => X.Description == UserType).FirstOrDefault();
        //                if (CheckForUserType != null)
        //                {
        //                    newUser.UserType = CheckForUserType.ID;
        //                }
        //                newUser.UserEmail = Username;
        //                newUser.UserPassword = GenerateHashedPassword(Password);
        //                newDoctor.Doctor_ID = newUser.UserID;

        //                db.Doctors.Add(newDoctor);
        //                db.Users.Add(newUser);
        //                db.SaveChanges();
        //                return View("Login");
        //            }
        //        }
        //        return View();
        //    }
        //}
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult GetData()

        //{
        //    using (OnlinePharmacyEntities db = new OnlinePharmacyEntities())
        //    {
        //        // List<Prescription> productList = db.Prescriptions.ToList<Prescription>();
        //        // return Json(new { data = productList }, JsonRequestBehavior.AllowGet);
        //    }

        //    return View();

        //}
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase jsonFile)
        {
            {
                using (OnlinePharmacyEntities db = new OnlinePharmacyEntities())
                {
                    if (!jsonFile.FileName.EndsWith(".json"))
                    {
                        ViewBag.Error = "Invalid file type(Only JSON file allowed)";
                        ViewBag.Missing = "File not chosen,please choose a file";
                    }
                    else
                    {
                        jsonFile.SaveAs(Server.MapPath("~/Prescription/" + Path.GetFileName(jsonFile.FileName)));
                        StreamReader streamReader = new StreamReader(Server.MapPath("~/Prescription/" + Path.GetFileName(jsonFile.FileName)));
                        string data = streamReader.ReadToEnd();
                        List<Prescription> Prescription = JsonConvert.DeserializeObject<List<Prescription>>(data);

                        Prescription.ForEach(p =>
                        {
                            Prescription prescription = new Prescription()
                            {

                              Quantity = p.Quantity,
                              Prescription_ID = p.Prescription_ID,
                              Patient = p.Patient,
                              Community_leader = p.Community_leader,
                              Doctor_Name = p.Doctor_Name ,
                              Doctor_Surname = p.Doctor_Surname,
                              Prescription_Date = p.Prescription_Date


                            };
                            db.Prescriptions.Add(prescription);
                            db.SaveChanges();
                        });
                        ViewBag.Success = "File uploaded Successfully..";
                    }
                }
                return View("Index");
            }
        }
        public ActionResult SendEmailDoctor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmail(EmailVM model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("Modibapotego@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("JP@B99.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "modibapotego@gmail.com",  // replace with valid value
                        Password = "Modiba118"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);

        }
    }
}
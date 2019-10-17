﻿using System;
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
    ViewBag.UserType = new SelectList(db.UserTypes, "ID", "Description");
    return View();
}

[HttpPost]
public ActionResult Create(User user)
{

    if (ModelState.IsValid)
    {
        var hashedpassword = ComputeSha256Hash(user.UserPassword);
        Models.User NewUser = new User();
        NewUser.UserEmail = user.UserEmail;
        NewUser.UserPassword = hashedpassword;
        NewUser.UserType = user.UserType;
        db.Users.Add(NewUser);
        db.SaveChanges();
        return RedirectToAction("Index", "Homepage");
    }

    ViewBag.UserType = new SelectList(db.UserTypes, "ID", "Description", user.UserType);
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
    if (user != null)
    {
        UserVM userVME = new UserVM();
        userVME.user = user;
        userVME.RefreshGUID(db);
        TempData["userVM"] = userVME;
        return RedirectToAction("Index", "Homepage");

    }

    return RedirectToAction("Index", "Home", "Error");
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
  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using INF272Github.ViewModel;


namespace INF272Github.Controllers
{
    public class PatientController : Controller
    {
        SqlConnection myConnection = new SqlConnection();
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult DoCreate(string name, string surname, DateTime dob, string number, string race, string gender, int village)
        {
            try
            {
                SqlCommand myInsertCommand = new SqlCommand("Insert into Patient Values('" + name + "','"+ surname + "','" + dob + "', '" + number + "', '" + race + "', '" + gender + "', '" + village + "')", myConnection);

                myConnection.Open();
                int rowsAffected = myInsertCommand.ExecuteNonQuery();
                ViewBag.Message = "Success: " + rowsAffected + " rows added.";
            }
            catch (Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return View("Index");
        }

        public ActionResult DoDelete(string name, string surname, int id)
        {
            try
            {
                SqlCommand myDeleteCommand = new SqlCommand("Delete from Patient where ID=" + id, myConnection);

                myConnection.Open();
                int rowsAffected = myDeleteCommand.ExecuteNonQuery();
                ViewBag.Message = "Success : " + rowsAffected + " rows deleted.";
            }
            catch (Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return View("Index");
        }

        public ActionResult DoSearch(int id,string name, string surname)
        {
            try
            {
                SqlCommand mySearchCommand = new SqlCommand("Select * from Prescription where ID=" + id, myConnection);

                myConnection.Open();
                int rowsAffected = mySearchCommand.ExecuteNonQuery();
                ViewBag.Message = "Success: " + rowsAffected + " rows deleted.";
            }

            catch (Exception err)   
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return View("Index");


        }

      

        public ActionResult DoUpdate(int id, string name, string surname, DateTime dob, string number, string race, string gender, int village)
        {
            try
            {
                SqlCommand myUpdateCommand = new SqlCommand("Update Patient Set Name='" + name + "', Surname='"+ surname +"', ID='"+id +"', DateOfBirth='"+dob +"', PhoneNumber='"+number +"', Race='"+ race +"', Gender='"+gender +"', Village='"+ village +"' where ID=" + id, myConnection); //Update {tble} set 

                myConnection.Open();
                int rowsAffected = myUpdateCommand.ExecuteNonQuery();
                ViewBag.Message = "Success: " + rowsAffected + " rows updated.";
            }
            catch (Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return View("Index");
        }

           private OnlinePharmacyEntities db = new OnlinePharmacyEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Gender1).Include(u => u.UserType1).Include(u => u.Village1);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new SelectList(db.Genders, "Gender_ID", "Gender_Type");
            ViewBag.UserType = new SelectList(db.UserTypes, "UserTypeID", "Description");
            ViewBag.Village = new SelectList(db.Villages, "Village_ID", "Village_Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,GUID,GUIDExpiry,Name,Surname,PhoneNumber,UserEmail,UserPassword,UserType,Village,Gender")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gender = new SelectList(db.Genders, "Gender_ID", "Gender_Type", user.Gender);
            ViewBag.UserType = new SelectList(db.UserTypes, "UserTypeID", "Description", user.UserType);
            ViewBag.Village = new SelectList(db.Villages, "Village_ID", "Village_Name", user.Village);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gender = new SelectList(db.Genders, "Gender_ID", "Gender_Type", user.Gender);
            ViewBag.UserType = new SelectList(db.UserTypes, "UserTypeID", "Description", user.UserType);
            ViewBag.Village = new SelectList(db.Villages, "Village_ID", "Village_Name", user.Village);
            return View(user);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,GUID,GUIDExpiry,Name,Surname,PhoneNumber,UserEmail,UserPassword,UserType,Village,Gender")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(db.Genders, "Gender_ID", "Gender_Type", user.Gender);
            ViewBag.UserType = new SelectList(db.UserTypes, "UserTypeID", "Description", user.UserType);
            ViewBag.Village = new SelectList(db.Villages, "Village_ID", "Village_Name", user.Village);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

          public ActionResult Update()
        {

            ViewBag.Gender = new SelectList(db.Genders, "Gender_ID", "Gender_Type");
            ViewBag.UserType = new SelectList(db.UserTypes, "UserTypeID", "Description");
            ViewBag.Village = new SelectList(db.Villages, "Village_ID", "Village_Name");
            return View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(db.Genders, "Gender_ID", "Gender_Type", user.Gender);
            ViewBag.UserType = new SelectList(db.UserTypes, "UserTypeID", "Description", user.UserType);
            ViewBag.Village = new SelectList(db.Villages, "Village_ID", "Village_Name", user.Village);
            return View(user);
        }

        public ActionResult CheckOrder()
        {
            return View();
        }


    }
}





  

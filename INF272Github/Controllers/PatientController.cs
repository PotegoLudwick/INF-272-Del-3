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
            return View("Search");

        }


            


    }
}
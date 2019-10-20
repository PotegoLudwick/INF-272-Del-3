using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF272Github.ViewModel
{
    public class Prescription
    {
        //Data Members 
        private int mPrescription_ID;
        private string mDescription;
        private DateTime mPrescription_Date;
        private string mPatient_Name;
        private string mPatient_Surname;
        private string mPatient_CellPhone;
        private string mPatient_Email;
        private string mAddress;
        private string mVillage;

        public int Prescription_ID { get => mPrescription_ID; set => mPrescription_ID = value; }
        public string Description { get => mDescription; set => mDescription = value; }
        public DateTime Prescription_Date { get => mPrescription_Date; set => mPrescription_Date = value; }
        public string Patient_Name { get => mPatient_Name; set => mPatient_Name = value; }
        public string Patient_Surname { get => mPatient_Surname; set => mPatient_Surname = value; }
        public string Patient_CellPhone { get => mPatient_CellPhone; set => mPatient_CellPhone = value; }
        public string Patient_Email { get => mPatient_Email; set => mPatient_Email = value; }
        public string Address { get => mAddress; set => mAddress = value; }
        public string Village { get => mVillage; set => mVillage = value; }

        public Prescription()
        {
            mPrescription_ID = 0;
            mDescription = "";
            mPrescription_Date = DateTime.Now;
            mPatient_Name = "";
            mPatient_Surname = "";
            mPatient_CellPhone = "";
            mPatient_Email = "";
            mAddress = "";
            mVillage = "";

        }

        public Prescription(int id, string d, DateTime date, string n, string s, string c, string e, string a, string v )
        {
            mPrescription_ID = id;
            mDescription = d;
            mPrescription_Date = date;
            mPatient_Name = n;
            mPatient_Surname = s;
            mPatient_CellPhone = c;
            mPatient_Email = e;
            mAddress = a;
            mVillage = v;

        }
    }
}
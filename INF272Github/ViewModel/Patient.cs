using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INF272Github.ViewModel
{
    public class Patient
    {
        //Data Members
        private int mPatientID;
       
        private string mName;
        private string mSurname;
        private DateTime mDateOfBirth;
        private string mPhoneNumber;
        private string mRace;
        private string mGender;
        private int mVillageID;

        //Accessor
        public int PatientID { get => mPatientID; set => mPatientID = value; }
        public string Name { get => mName; set => mName = value; }
        public string Surname { get => mSurname; set => mSurname = value; }
       
        public string PhoneNumber { get => mPhoneNumber; set => mPhoneNumber = value; }
        public string Race { get => mRace; set => mRace = value; }
        public string Gender { get => mGender; set => mGender = value; }
        public int VillageID { get => mVillageID; set => mVillageID = value; }
        public DateTime DateOfBirth { get => mDateOfBirth; set => mDateOfBirth = value; }


        //Constructors
        public Patient()
        {
            mName = "";
            mSurname = "";
            mDateOfBirth = DateTime.Now;
            mPhoneNumber = "";
            mRace = "";
            mGender = "";
            mVillageID = 0;

            
        }

        public Patient(string n, string s, DateTime dob, string number, string r, string g, int v)
        {
            mName = n;
            mSurname = s;
            mDateOfBirth = dob;
            mPhoneNumber = number;
            mRace = r;
            mGender = g;
            mVillageID = 0;


        }
    }
}
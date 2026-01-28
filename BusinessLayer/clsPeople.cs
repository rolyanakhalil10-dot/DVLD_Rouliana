using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsPeople
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int NewID = 0;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }
        public string NationalNo { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short Gendor { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }

        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsCountries CountryInfo;

        public clsPeople()

        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPeople(int PersonID, string FirstName, string SecondName, string ThirdName,
    string LastName, string NationalNo, DateTime DateOfBirth, short Gendor,
     string Address, string Phone, string Email,
    int NationalityCountryID, string ImagePath)

        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = clsCountries.Find(NationalityCountryID);
            Mode = enMode.Update;
        }


        public static clsPeople Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "",
                Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gendor = 0;

            bool isFound = PeopleData.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, 
                ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth,ref Gendor, ref Address, ref Phone,
                ref Email, ref NationalityCountryID, ref ImagePath);

            if(isFound)
            {
                return new clsPeople(PersonID, FirstName, SecondName, ThirdName, LastName, 
                    NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID,
                    ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPeople Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1;
            int NationalityCountryID = -1;
            short Gendor = 0;

            bool isFound = PeopleData.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gendor, ref Address, ref Phone,
                ref Email, ref NationalityCountryID, ref ImagePath);

            if (isFound)
            {
                return new clsPeople(PersonID, FirstName, SecondName, ThirdName, LastName,
                    NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID,
                    ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            return PeopleData.DeletePerson(PersonID);
        }

        private bool _AddNewPerson()
        {
            this.PersonID = PeopleData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo,
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);
            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return PeopleData.UpdatePerson(
                this.PersonID, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo, this.DateOfBirth, this.Gendor,
                this.Address, this.Phone, this.Email,
                  this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;

        }

        public static bool isPersonExist(int ID)
        {
            return PeopleData.IsPersonExist(ID);
        }

        public static bool isPersonExist(string NationlNo)
        {
            return PeopleData.IsPersonExist(NationlNo);
        }

        public static DataTable GetAllPeople()
        {
            return PeopleData.GetAllPeople();
        }

    }
}

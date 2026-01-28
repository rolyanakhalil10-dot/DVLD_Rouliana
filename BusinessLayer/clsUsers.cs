using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.clsPeople;

namespace BusinessLayer
{
    public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }
        public clsPeople PersonInfo;
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public clsUsers()

        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, int PersonID, string Username, string Password,
            bool IsActive)

        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPeople.Find(PersonID);
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            string HashedPassword = clsHashingPasswords.ComputeHash(this.Password);
            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.UserName,
                HashedPassword, this.IsActive);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            string HashedPassword = clsHashingPasswords.ComputeHash(this.Password);

            return clsUsersData.UpdateUser(this.UserID, this.PersonID, this.UserName,
                HashedPassword, this.IsActive);
        }

        public static clsUsers FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUsersData.GetUserInfoByUserID
                                (UserID, ref PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public static clsUsers FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUsersData.GetUserInfoByPersonID
                                (PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public static clsUsers FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            string HashedPassword = clsHashingPasswords.ComputeHash(Password);
            bool IsActive = false;

            bool IsFound = clsUsersData.GetUserInfoByUsernameAndPassword
                                (UserName, HashedPassword, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static bool isUserExist(int UserID)
        {
            return clsUsersData.IsUserExist(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUsersData.IsUserExist(UserName);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistForPersonID(PersonID);
        }

    }
}

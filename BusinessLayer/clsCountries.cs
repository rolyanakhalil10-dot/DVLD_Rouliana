using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsCountries
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountries(int countryID, string countryName)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
        }

        public static clsCountries Find(int CountryID)
        {
            string CountryName = "";

            bool isFound = clsCountriesData.GetCountryByID(CountryID, ref CountryName);
            if(isFound)
            {
                return new clsCountries(CountryID, CountryName);
            }
            else
            {
                return null;
            }

        }
        public static clsCountries Find(string CountryName)
        {
            int CountryID = -1;

            bool isFound = clsCountriesData.GetCountryInfoByName(CountryName, ref CountryID);
            if (isFound)
            {
                return new clsCountries(CountryID, CountryName);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }


    }
}

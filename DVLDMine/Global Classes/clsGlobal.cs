using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DVLDMine
{
    internal static  class clsGlobal
    {
        public static clsUsers CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            // Specify the Registry key and path
            string subKey = @"SOFTWARE\DVLD_MyWin_Application";
            string valueNameUserName = "DVLD_LoginUserName";
            string ValueNamePassword = "DVLV_LoginPassword";


            try
            {
                using(RegistryKey Key = Registry.CurrentUser.CreateSubKey(subKey))
                {
                    if (Key ==null)
                    {
                        return false;
                    }
                    Key.SetValue(valueNameUserName, Username, RegistryValueKind.String);
                    Key.SetValue(ValueNamePassword, Password, RegistryValueKind.String);
                   
                }

            }
            catch (Exception ex)
            {
                clsLoggerEvent.LogEvent("Error Writting to the windows registery", System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
            return true;
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string subKey = @"SOFTWARE\DVLD_MyWin_Application";

            try
            {
                using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(subKey))
                {
                    if (Key == null)
                    {
                        return false;
                    }

                    Username = Key.GetValue("DVLD_LoginUserName") as string;
                    Password = Key.GetValue("DVLV_LoginPassword") as string;

                }

            }
            catch (Exception ex)
            {
                clsLoggerEvent.LogEvent("Error reading from the windows registery", System.Diagnostics.EventLogEntryType.Error);

                return false;
            }
            return true;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace PharmInventory.HelperClasses
{
   public class VisibilitySetting
   {
       public const string REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration";
       public const string HANDLE_UNITS_KEY = @"HandleUnits";

       public static int HandleUnits
       {
           get
           {
               try
               {
                   var value = GetRegistryValue(REGISTRY_PATH, HANDLE_UNITS_KEY);
                   var handleUnits = Convert.ToInt32(value);
                   return handleUnits;
               }
               catch (Exception)
               {
                   SetRegistryValue(HANDLE_UNITS_KEY, 1);
                   return 1;
               }
           }
       }

       public static string GetRegistry(string path, string key)
       {
           var visibility = (string)Registry.GetValue(path, key, null);
           return visibility;
       }

       public static string GetRegistryValue(string keyName, string valueName)
       {
           var key = Registry.CurrentUser.OpenSubKey(keyName);
           if (key != null) return key.GetValue(valueName).ToString();
           return null;
       }

       public static void SetRegistryValue(string valueName, int value)
       {
           try
           {
               Registry.CurrentUser.DeleteValue(REGISTRY_PATH, false);
               RegistryKey rk = Registry.CurrentUser.CreateSubKey(REGISTRY_PATH);
               if (rk != null) rk.SetValue(valueName, value);
           }
           catch (Exception ex)
           {
               string message = ex.InnerException.Message;
               XtraMessageBox.Show(message);
           }
       }
   }
}

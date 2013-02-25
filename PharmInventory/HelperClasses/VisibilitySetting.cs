using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace PharmInventory.HelperClasses
{
   public class VisibilitySetting
   {
       public const string REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration";
       public const string HANDLE_UNITS_KEY = @"HandleUnits";

       public static bool HandleUnits
       {
           get
           {
               try
               {
                   var value = GetRegistryValue(REGISTRY_PATH, HANDLE_UNITS_KEY);
                   var handleUnits = Convert.ToBoolean(value);
                   return handleUnits;
               }
               catch (Exception)
               {
                   SetRegistryValue(HANDLE_UNITS_KEY, "false");
                   return false;
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
           return key.GetValue(valueName).ToString();
           
       }

       public static void SetRegistryValue(string valueName, string value)
       {
           var openSubKey = Registry.CurrentUser.OpenSubKey(REGISTRY_PATH);
           if (openSubKey != null)
               openSubKey.SetValue(valueName, value);
       }
   }
}

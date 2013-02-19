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
           RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
           var KEY = localMachine.OpenSubKey(keyName);
           var value = KEY.GetValue(valueName);
           if (value != null)
               return value.ToString();
           return "";
       }


       public static void SetRegistryValue(string valueName, string value)
       {
           RegistryKey localMachine = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
           var rsKey = localMachine.OpenSubKey(REGISTRY_PATH, true);
           rsKey.SetValue(valueName, value);
       }


    }
}

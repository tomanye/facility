using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using PharmInventory.RRFLookUpService;
using PharmInventory.RRFTransactionService;

namespace PharmInventory.HelperClasses
{
   public class RRFHelper
    {
       private const string UserName = "HCMISTest";
       private const string Password = "123!@#abc";
       public static int GetRrfCategoryId(string programName)
       {
           var client1 =new ServiceRRFLookupClient();
           var periods = client1.GetCurrentReportingPeriod(65, UserName, Password);
           var period = periods[0].Id;
           var forms = client1.GetForms(65, UserName, Password);
           var formid = forms[0].Id;
           var formcategories=  client1.GetFacilityRRForm(65, formid, period, 1, UserName, Password).First().FormCategories.ToList();
          
               switch (programName)
               {
                   case "Malaria Prevention & Control":
                       return formcategories[0].Id;
                   case "TB / Leprosy Prevention & Control":
                       return formcategories[1].Id;
                   case "HIV/AIDS ans STIs and OIs":
                       return formcategories[2].Id;
                   case "Curative care and emergency care":
                       return formcategories[3].Id;
                   case "Family Planning":
                       return formcategories[4].Id;
                   case "Disease Prevention and Control":
                       return formcategories[5].Id;
                   case "Adolescent Reproductive Health":
                       return formcategories[6].Id;
               }
           return 0;
       }

       
      
    }
    
}

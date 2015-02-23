using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PharmInventory.HelperClasses
{
    public static class Common
    {
        public static bool IsInventoryPeriod()
        {
            int currentMonth = EthiopianDate.EthiopianDate.Now.Month;
            if (currentMonth == 10)
            {
                MessageBox.Show("You are on inventory period so you cann't perform any transaction.", "HCMIS FE", MessageBoxButton.OK);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

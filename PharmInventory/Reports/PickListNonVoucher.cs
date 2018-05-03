using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BLL;

namespace PharmInventory.Reports
{
    public partial class PickListNonVoucher : DevExpress.XtraReports.UI.XtraReport
    {
        
        public PickListNonVoucher()
        {
            InitializeComponent();
            var gn = new GeneralInfo();
            gn.LoadAll();
            xrFacilityName.Text = gn.HospitalName;
         }

     
    }
}

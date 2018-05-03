using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BLL;

namespace PharmInventory.Reports
{
    public partial class PickList : DevExpress.XtraReports.UI.XtraReport
    {
        
        public PickList()
        {
            InitializeComponent();
            var gn = new GeneralInfo();
            gn.LoadAll();
            xrFacilityName.Text = gn.HospitalName;
         }

     
    }
}

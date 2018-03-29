using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BLL;

namespace PharmInventory.Reports
{
    public partial class LossAdjustmentModel22 : DevExpress.XtraReports.UI.XtraReport
    {
        
        public LossAdjustmentModel22()
        {
            InitializeComponent();
            var gn = new GeneralInfo();
            gn.LoadAll();
            xrFacilityName.Text = gn.HospitalName;
        }
 
    }
}

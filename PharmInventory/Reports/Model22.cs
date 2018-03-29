using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BLL;

namespace PharmInventory.Reports
{
    public partial class Model22 : DevExpress.XtraReports.UI.XtraReport
    {
        
        public Model22()
        {
            InitializeComponent();
            var gn = new GeneralInfo();
            gn.LoadAll();
            xrFacilityName.Text = gn.HospitalName;
         }

     
    }
}

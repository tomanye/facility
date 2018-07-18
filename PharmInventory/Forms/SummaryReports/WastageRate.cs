using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraCharts;

namespace PharmInventory.Forms.SummaryReports
{
    public partial class WastageRate : XtraForm
    {
        public WastageRate()
        {
            InitializeComponent();
        }

        private void WastageRate_Load(object sender, EventArgs e)
        {
            chrtWastageRate.Series.Clear();
            ReceiveDoc rec = new ReceiveDoc();
           DataTable dt = rec.GetWastageRate(0,0); 
            Series ser = new Series("Wastage Cost In Birr", ViewType.Line) { DataSource = dt, ArgumentScaleType = ScaleType.Qualitative, ArgumentDataMember = "YearT", ValueScaleType = ScaleType.Numerical };
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            // ser.PointOptions.ValueNumericOptions.Precision = 1;            
            chrtWastageRate.Series.Add(ser);

        }
    }
}

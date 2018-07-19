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
using DevExpress.Utils;

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
            
            Series ser = new Series("Wastage Rate In Birr", ViewType.Bar) { DataSource = dt, ArgumentScaleType = ScaleType.Qualitative, ArgumentDataMember = "YearR", ValueScaleType = ScaleType.Numerical };
            ser.ValueDataMembers.AddRange(new string[] { "WastageRate" });
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            ((BarSeriesLabel)ser.Label).Position = BarSeriesLabelPosition.Top;
            ((BarSeriesView)ser.View).ColorEach = true; 
            ser.PointOptions.ValueNumericOptions.Precision = 0;
            ser.LegendPointOptions.PointView = PointView.ArgumentAndValues;
            ser.LegendTextPattern = "{A}:{V:n0} %";
            ser.LabelsVisibility = DefaultBoolean.True; 
            ser.Label.TextPattern = "{V:n0} %";

            chrtWastageRate.Series.Add(ser);

        }
    }
}

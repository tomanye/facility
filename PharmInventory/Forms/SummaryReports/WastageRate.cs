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
using DevExpress.XtraPrinting;

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
            DataView dv = Items.AllFiscalYears().DefaultView;
            dv.Sort = "year desc";
            DataTable sortedDT = dv.ToTable();
            cboYear.Properties.DataSource = sortedDT;  
            cboYearto.Properties.DataSource = sortedDT;
            cboYearto.ItemIndex = 0;
            var type = new BLL.Type();
            DataTable alltypes = type.GetAllCategory();
            DataRow row = alltypes.NewRow();
            row["ID"] = "0";
            row["Name"] = "All Categories";
            alltypes.Rows.InsertAt(row, 0);

            lkCategory.Properties.DataSource = alltypes;
            lkCategory.Properties.DisplayMember = "Name";
            lkCategory.Properties.ValueMember = "ID";
            lkCategory.ItemIndex = 0;

            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStor = stor.DefaultView.ToTable();
            DataRow rowStore = dtStor.NewRow();
            rowStore["ID"] = "0";
            rowStore["StoreName"] = "All Stores";
            dtStor.Rows.InsertAt(rowStore, 0);

            cboStores.Properties.DataSource = dtStor;
            cboStores.ItemIndex = 0;
            generateChart();



        }
        private void generateChart()
        {
            chrtWastageRate.Series.Clear();
            ReceiveDoc rec = new ReceiveDoc();
            DataTable dt = rec.GetWastageRate(Convert.ToInt32(cboYear.EditValue), Convert.ToInt32(cboYearto.EditValue), Convert.ToInt32(cboStores.EditValue), Convert.ToInt32(lkCategory.EditValue));

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

        private void cboYear_EditValueChanged(object sender, EventArgs e)
        {
            generateChart();
        }

        private void lkCategory_EditValueChanged(object sender, EventArgs e)
        {
            generateChart();
        }

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            generateChart();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            printableComponentLink1.CreateDocument(false);
            printableComponentLink1.PrintingSystem.Document.AutoFitToPagesWidth = 1;
            printableComponentLink1.ShowPreview();
        }
        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            var info = new GeneralInfo();
            info.LoadAll();

            int year = Convert.ToInt32(cboYear.EditValue);
            int month = 10;
       
            //string[] header = { info.HospitalName, "General Expiry For Current Year", "From Start Date: " + strStartDate, "To End Date: " + strEndDate, "Printed Date: " + strCurrentDate };

            string[] header = { info.HospitalName, "Wastage Rate: " + "Store: " + cboStores.Text, "From : " + cboYear.Text + " E.C" + " To: " + cboYearto.Text + " E.C"  };
            printableComponentLink1.Landscape = true;
            printableComponentLink1.PageHeaderFooter = header;

            TextBrick brick = e.Graph.DrawString(header[0], Color.DarkBlue, new RectangleF(0, 0, 600, 100), BorderSide.None);
            TextBrick brick1 = e.Graph.DrawString(header[1], Color.DarkBlue, new RectangleF(0, 40, 1200, 100), BorderSide.None);
            TextBrick brick2 = e.Graph.DrawString(header[2], Color.DarkBlue, new RectangleF(0, 80, 600, 100), BorderSide.None); 
        }
    }
}

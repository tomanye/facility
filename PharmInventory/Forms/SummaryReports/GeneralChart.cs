using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraCharts;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using DevExpress.XtraEditors;
using PharmInventory.HelperClasses;

namespace PharmInventory
{
   
    public partial class GeneralChart : XtraForm
    {
       
        public GeneralChart()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            
            Stores stor = new Stores();
            stor.GetActiveStores();
            DataTable dtStor = stor.DefaultView.ToTable();
            //object[] obj = {0,1,"All" };
            //if(stor.RowCount > 1)
            //    dtStor.Rows.Add(obj);
            cboStores.Properties.DataSource = dtStor;
            if (stor.RowCount > 1)
                cboStores.ItemIndex = 0;

            dtDate.Value = DateTime.Now;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            curMont = dtCurrent.Month;
            curYear = dtCurrent.Year;

            
            cboYear.Properties.DataSource = Items.AllYears();
         
            cboYear.EditValue = dtCurrent.Year;
            if (cboYear.Properties.Columns.Count > 0)
                cboYear.Properties.Columns[0].Alignment = DevExpress.Utils.HorzAlignment.Near;
            
        }

        DateTime dtCurrent = new DateTime();
        int curMont = 0;
        int curYear = 0;

        private void GenerateStockStatusPieChart()
        {
            ReceiveDoc rec = new ReceiveDoc();
            
            //progressBar1.Visible = true;
            chartPie.UseWaitCursor = true;
            chartPie.Series.Clear();
            int storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 0;
            
            //int neverRec = rec.CountNeverReceivedItems(storeId);

            curYear = Convert.ToInt32(cboYear.EditValue);
            curMont = (curYear == dtCurrent.Year) ? dtCurrent.Month : 12;
            //progressBar1.PerformStep();
            Balance bal = new Balance();
            Int64 stockin = bal.CountStockIn(storeId, curMont, curYear);
           // progressBar1.PerformStep();
            Int64 stockout =  bal.CountStockOut(storeId, curMont, curYear);
           // progressBar1.PerformStep();
            Int64 overstock = bal.CountOverStock(storeId, curMont, curYear);
           // progressBar1.PerformStep();
            Int64 nearEOP = bal.CountNearEOP(storeId, curMont, curYear);
           // progressBar1.PerformStep();
            Int64 BelowEOP = bal.CountBelowEOP(storeId,curMont,curYear);
           // progressBar1.PerformStep();
            //Int64 belowMin = bal.CountBelowMin(storeId,curMont,curYear);
           // progressBar1.PerformStep();
            object[] obj = { stockin, stockout, overstock, nearEOP,BelowEOP };

            DataTable dtList = new DataTable();
            dtList.Columns.Add("Type");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);

            

            object[] oo = {"In Stock",obj[0]};
            dtList.Rows.Add(oo);

            object[] oo2 = { "Stock Out", obj[1] };
            dtList.Rows.Add(oo2);

            object[] oo3 = { "Over Stock", obj[2] };
            dtList.Rows.Add(oo3);

            object[] oo4 = { "Near EOP", obj[3] };
            dtList.Rows.Add(oo4);

            object[] oo5 = { "Below EOP", obj[4] };
            dtList.Rows.Add(oo5);

            //object[] oo6 = { "Below Min", obj[5] };
            //dtList.Rows.Add(oo6);

            Series ser = new Series("pie", ViewType.Pie3D);
            ser.DataSource = dtList;
            
            ser.ArgumentScaleType = ScaleType.Qualitative;
            ser.ArgumentDataMember = "Type";
            ser.ValueScaleType = ScaleType.Numerical;
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            ser.PointOptions.PointView = PointView.ArgumentAndValues;
            ser.LegendText = "Key";
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            ser.PointOptions.ValueNumericOptions.Precision = 0;

           // progressBar1.PerformStep();
            //ser.SeriesPointsSorting = SortingMode.Ascending;
            //ser.SeriesPointsSortingKey = SeriesPointKey.Value_1;

            //SeriesPointFilter filter = new SeriesPointFilter(SeriesPointKey.Value_1,DataFilterCondition.GreaterThanOrEqual, 10);
            //((PieSeriesView)ser.View).ExplodedPointsFilters.Add(filter);
            //((PieSeriesView)ser.View).ExplodeMode = PieExplodeMode.UseFilters;
            //((PieSeriesView)ser.View).Rotation = 90;

            ((PieSeriesLabel)ser.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PiePointOptions)ser.PointOptions).PointView = PointView.ArgumentAndValues;
            

            
            chartPie.Series.Add(ser);
            chartPie.Size = new System.Drawing.Size(1000, 500);
            //progressBar1.PerformStep();
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();

            lblHeader.Text = info.HospitalName + " Stock Status summary of year " + curYear + " of " + cboStores.Text;
           // progressBar1.Visible = false;
            chartPie.UseWaitCursor = false;
        }

        private void GenerateStockStatusPieChartVital()
        {
           // progressBar1.Visible = true;

            chartPie.Series.Clear();
            int storeId = (cboStores.EditValue != null) ? Convert.ToInt32(cboStores.EditValue) : 0;
            curYear = Convert.ToInt32(cboYear.EditValue);
            curMont = (curYear == dtCurrent.Year) ? dtCurrent.Month : 12;
            //progressBar1.PerformStep();
            Balance bal = new Balance();
            Int64 stockin = bal.CountStockIn(storeId, curMont, curYear);
            //progressBar1.PerformStep();
            Int64 stockout = bal.CountStockOut(storeId, curMont, curYear);
            //progressBar1.PerformStep();
            Int64 overstock = bal.CountOverStock(storeId, curMont, curYear);
           // progressBar1.PerformStep();
            Int64 nearEOP = bal.CountNearEOP(storeId, curMont, curYear);
            //progressBar1.PerformStep();
            object[] obj = { stockin, stockout, overstock, nearEOP };

            DataTable dtList = new DataTable();
            dtList.Columns.Add("Type");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);
            object[] oo = { "Stock In", obj[0] };
            dtList.Rows.Add(oo);

            object[] oo2 = { "Stock Out", obj[1] };
            dtList.Rows.Add(oo2);

            object[] oo3 = { "OverStock", obj[2] };
            dtList.Rows.Add(oo3);

            object[] oo4 = { "Near EOP", obj[3] };
            dtList.Rows.Add(oo4);

            Series ser = new Series("pie", ViewType.Pie3D);
            ser.DataSource = dtList;

            ser.ArgumentScaleType = ScaleType.Qualitative;
            ser.ArgumentDataMember = "Type";
            ser.ValueScaleType = ScaleType.Numerical;
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            ser.PointOptions.PointView = PointView.ArgumentAndValues;
            ser.LegendText = "Key";
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            ser.PointOptions.ValueNumericOptions.Precision = 0;

           // progressBar1.PerformStep();
            //ser.SeriesPointsSorting = SortingMode.Ascending;
            //ser.SeriesPointsSortingKey = SeriesPointKey.Value_1;

            //SeriesPointFilter filter = new SeriesPointFilter(SeriesPointKey.Value_1,DataFilterCondition.GreaterThanOrEqual, 10);
            //((PieSeriesView)ser.View).ExplodedPointsFilters.Add(filter);
            //((PieSeriesView)ser.View).ExplodeMode = PieExplodeMode.UseFilters;
            //((PieSeriesView)ser.View).Rotation = 90;

            ((PieSeriesLabel)ser.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PiePointOptions)ser.PointOptions).PointView = PointView.ArgumentAndValues;



            chartPie.Series.Add(ser);
            chartPie.Size = new System.Drawing.Size(1000, 500);
           // progressBar1.PerformStep();
            lblHeader.Text = "Stock Status summary of year " + curYear + " of " + cboStores.Text;
           // progressBar1.Visible = false;
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void cboStores_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null && cboYear.EditValue != null)
            GenerateStockStatusPieChart();
        }

        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
           if(cboStores.EditValue != null && cboYear.EditValue != null)
            GenerateStockStatusPieChart();
        }


        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue != null && cboYear.EditValue != null)
                GenerateStockStatusPieChart();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreviewDialog();
        }
    }
}
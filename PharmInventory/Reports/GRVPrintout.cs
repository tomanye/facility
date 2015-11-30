using PharmInventory.Barcode.DTO;
using PharmInventory.ViewModels;

namespace PharmInventory.Reports
{
    public partial class GRVPrintout : DevExpress.XtraReports.UI.XtraReport
    {
        public GRVPrintout()
        {
            InitializeComponent();
        }

        public GRVPrintout(GrvViewModel model)
        {
            InitializeComponent();
            bindingSource1.DataSource = model;
        }
    }
}

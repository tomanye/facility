using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using PharmInventory.Forms.Modals;

namespace PharmInventory.Forms.Profiles
{
    /// <summary>
    /// Interaction logic for ManageSupply Form
    /// </summary>
    public partial class ManageSupply : Form
    {

        public ManageSupply()
        {
            InitializeComponent();
        }

        int _catId = 0;
        int _selectedCat = 0;

        /// <summary>
        /// Loads the categories and items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageItems_Load(object sender, EventArgs e)
        {
            PopulateSupplyCatTree();
            Items itm = new Items();
            DataTable dtItem = itm.GetAllSupply();
            
            PopulateItemList(dtItem);
            lblState.Text = "All Supplies";
            
        }

        /// <summary>
        /// Populates the supply category tree
        /// </summary>
        private void PopulateSupplyCatTree()
        {
            SupplyCategory subCat = new SupplyCategory();
            DataTable dtSupCat = subCat.GetMainCategory();
            ProductTree.Nodes.Clear();
            foreach (DataRow dv in dtSupCat.Rows)
            {
                TreeNode nodes = new TreeNode
                                     {
                                         Name = dv["ID"].ToString(),
                                         Text = dv["Name"].ToString() + " (" + dv["Code"].ToString() + ")",
                                         ToolTipText = "Double click to list"
                                     };
                DataTable dtSubCat = subCat.GetSubCategory(Convert.ToInt32(dv["ID"]));
                foreach (DataRow subDv in dtSubCat.Rows)
                {
                    TreeNode subNodes = new TreeNode
                                            {
                                                Name = subDv["ID"].ToString(),
                                                Text = subDv["Name"].ToString() + " (" + subDv["Code"].ToString() + ")",
                                                ToolTipText = "Double click to list"
                                            };
                    nodes.Nodes.Add(subNodes);
                }
                ProductTree.Nodes.Add(nodes);
            }

        }

        /// <summary>
        /// Populates the item list
        /// </summary>
        /// <param name="dtItem"></param>
        public void PopulateItemList(DataTable dtItem)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Value = 1;
            progressBar1.Maximum = dtItem.Rows.Count;
            //dtItem.DefaultView.Sort = "ItemName";
            lstItem.Items.Clear();
            int col = 0;
            int count = 1;
            foreach (DataRow dr in dtItem.Rows)
            {
                string itemName = dr["ItemName"].ToString() + " - " + dr["DosageForm"].ToString() + " - " + dr["Strength"].ToString() ;
                string[] str = { count.ToString(), dr["StockCode"].ToString(), itemName, dr["Unit"].ToString(), dr["DosageForm"].ToString() };
                ListViewItem listItem = new ListViewItem(str) {Tag = dr["ID"]};
                if (col != 0)
                {
                    listItem.BackColor = Color.FromArgb(233, 247, 248);
                    col = 0;
                }
                else
                {
                    col++;
                }
                lstItem.Items.Add(listItem);
                count++;
                progressBar1.PerformStep();
            }
            progressBar1.Visible = false;
        }

        /// <summary>
        /// Handles the double click event on the Product Tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Items itm = new Items();
            DataTable dtItem;
            int categoryId = Convert.ToInt32(ProductTree.SelectedNode.Name);
           if(categoryId != 0)
            {
                dtItem = itm.GetSupplyByCategory(categoryId);
                lblState.Text = "All Supplies under " + ProductTree.SelectedNode.Text + " Category";
                toolStripButtonAddItems.Enabled = true;
                _catId = categoryId;
                toolStripButtonEditItem.Enabled = false;
                //selectedSubCat = categoryId;
            }
            else
            {
                dtItem = itm.GetAllSupply();
                lblState.Text = "All Supplies";
                toolStripButtonAddItems.Enabled = false;
                toolStripButtonEditItem.Enabled = false;
                _selectedCat = 0;
            }
            PopulateItemList(dtItem);
        }

        /// <summary>
        /// Opens the AddSupply Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnAddNew_Click(object sender, EventArgs e)
        {
            if (_catId != 0)
            {
                AddSupply addItm = new AddSupply(_catId,false);
                MainWindow.ShowForms(addItm);
            }
        }

        /// <summary>
        /// Enable or disable the edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButtonEditItem.Enabled = lstItem.SelectedItems.Count > 0;
        }

        /// <summary>
        /// Opens the Editing form if an item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnEdit_Click(object sender, EventArgs e)
        {
            if (lstItem.SelectedItems.Count > 0)
            {
                int itemId = Convert.ToInt32(lstItem.SelectedItems[0].Tag);
                AddSupply addItm = new AddSupply(itemId, true);
                MainWindow.ShowForms(addItm);

                DataTable dtItem;
                Items itm = new Items();

                if (txtItemName.Text != "")
                {
                    string keyword = txtItemName.Text;
                    dtItem = itm.GetSupplyByKeyword(keyword);
                }
                else
                {
                    dtItem = itm.GetAllSupply();
                }
                PopulateItemList(dtItem);
            }
            else
            {
                toolStripButtonEditItem.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the refreshing of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnRefresh_Click(object sender, EventArgs e)
        {
            Items itm = new Items();
            DataTable dtItem;
            int categoryId = Convert.ToInt32(ProductTree.SelectedNode.Name);
            if (categoryId != 0)
            {
                dtItem = itm.GetSupplyByCategory(categoryId);
                lblState.Text = "All Supplies under " + ProductTree.SelectedNode.Text + " Category";
                toolStripButtonAddItems.Enabled = true;
                //catID = categoryId;
                toolStripButtonEditItem.Enabled = false;
                //selectedSubCat = categoryId;
            }
            else
            {
                dtItem = itm.GetAllSupply();
                lblState.Text = "All Supplies";
                toolStripButtonAddItems.Enabled = false;
                toolStripButtonEditItem.Enabled = false;
                _selectedCat = 0;
            }
            PopulateItemList(dtItem);
        }

        /// <summary>
        /// Handles filtering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            DataTable dtItem;
            Items itm = new Items();

            if (txtItemName.Text != "")
            {
                string keyword = txtItemName.Text;
                dtItem = itm.GetSupplyByKeyword(keyword);
            }
            else
            {
                dtItem = itm.GetAllSupply();
            }
            PopulateItemList(dtItem);
        }

        /// <summary>
        /// Export to Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();

            string[] header = { info.HospitalName, "Supplies List" };
            MainWindow.ExportToExcel(lstItem, header);
        }

        /// <summary>
        /// Handles the double click event of the lstItem Object.
        /// Open the AddSupply form based on the chosen item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstItem.SelectedItems.Count <= 0) return;

            int itemId = Convert.ToInt32(lstItem.SelectedItems[0].Tag);
            AddSupply addItm = new AddSupply(itemId, true);
            MainWindow.ShowForms(addItm);

            DataTable dtItem;
            Items itm = new Items();

            if (txtItemName.Text != "")
            {
                string keyword = txtItemName.Text;
                dtItem = itm.GetSupplyByKeyword(keyword);
            }
            else if (_selectedCat != 0)
            {
                dtItem = itm.GetSupplyByCategory(_selectedCat);
                toolStripButtonAddItems.Enabled = true;
                toolStripButtonEditItem.Enabled = false;
            }
               
            else
            {
                dtItem = itm.GetAllSupply();
            }
            PopulateItemList(dtItem);
        }
        
        /// <summary>
        /// Handles Printing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            GeneralInfo info = new GeneralInfo();
            info.LoadAll();

            string header = info.HospitalName + " Supplies List";
            lstItem.Title = header;
            lstItem.FitToPage = true;
            lstItem.Print();
        }

        private int _sortColumn = -1;
        
        /// <summary>
        /// Handles sorting when the colum of the list box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstItem_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != _sortColumn)
            {
                _sortColumn = e.Column;
                lstItem.Sorting = SortOrder.Ascending;
            }
            else
            {
                lstItem.Sorting = ((lstItem.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending);
            }
            const int num = 0;
            this.lstItem.ListViewItemSorter = new ListViewItemComparer(e.Column, lstItem.Sorting, num);
            lstItem.Sort();
        }

      

    }
}
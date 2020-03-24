using MparWinForm07.Mvc.Controller;
using MparWinForm07.Mvc.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MparWinForm07.Mvc.View
{
    public partial class CustomerView : Form, ICustomerView
    {
        // Paging
        private int TableRecords;
        private int MaxPage;

        public int CustomerNumber
        {
            get { return Convert.ToInt32(txtCustomerNumber.Text); }
            set {this.txtCustomerNumber.Text = ""+value; }

        }
        public string Address
        {
            get { return txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }
        public string City
        {
            get { return txtCity.Text; }
            set { this.txtCity.Text = value; }
        }
        public string CountryCode
        {
            get { return txtCountryCode.Text; }
            set { this.txtCountryCode.Text = value; }
        }
        public DateTime Timestamp
        {
            get {
                try
                {
                    return DateTime.Parse(txtTimestamp.Text);
                }catch(FormatException)
                {
                    throw new FormatException();
                }
                }
            set { 
                    this.txtTimestamp.Text = String.Format("{0:yyyy-MM-dd}", value);  
                }
        }
        public bool CanModifyID
        {
            set { this.txtCustomerNumber.Enabled = value; }
        }
        public CustomerView()
        {
            InitializeComponent();
            PostInit();
        }
        private void PostInit()
        {
            XCurrentPage.Value = 0;
            XRecordsPerPage.Value = 10;
        }
        CustomerController _controller;


        private void AddButton_Click(object sender, EventArgs e)
        {
            _controller.AddNew();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _controller.Remove();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _controller.Save();
        }

 
        public void SetController(CustomerController controller)
        {
            this._controller = controller;
        }

        public void ClearGrid()
        {
            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("Customer", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Name", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Address", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("City", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Country", 200, HorizontalAlignment.Left);
            // Add rows to grid
            this.listView1.Items.Clear();
        }

        public void AddToGrid(Customer customer)
        {
            ListViewItem parent;
            parent = this.listView1.Items.Add("" + customer.CustomerNumber);
            parent.SubItems.Add("" + customer.Name);
            parent.SubItems.Add("" + customer.Address);
            parent.SubItems.Add("" + customer.City);
            parent.SubItems.Add("" + customer.CountryCode);
        }

        public void UpdateGrid(Customer customer)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(customer.CustomerNumber) == 0)
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.Text = ""+customer.CustomerNumber;
                rowToUpdate.SubItems[1].Text = customer.Name;
                rowToUpdate.SubItems[2].Text = customer.Address;
                rowToUpdate.SubItems[3].Text = customer.City;
                rowToUpdate.SubItems[4].Text = ""+customer.CountryCode;
            }
        }

        public void RemoveFromGrid(Customer customer)
        {
            ListViewItem rowToRemove = null;

            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(customer.CustomerNumber) == 0)
                {
                    rowToRemove = row;
                }
            }

            if (rowToRemove != null)
            {
                this.listView1.Items.Remove(rowToRemove);
                this.listView1.Focus();
            }
        }

        public int GetIdOfSelectedInGrid()
        {
            if (this.listView1.SelectedItems.Count > 0)
                return (Convert.ToInt32( this.listView1.SelectedItems[0].Text));
            else
                return 0;
        }

        public void SetSelectedInGrid(Customer customer)
        {
            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(customer.CustomerNumber) == 0)
                {
                    row.Selected = true;
                }
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
                this._controller.SelectedChanged(Convert.ToInt32(this.listView1.SelectedItems[0].Text));
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.Refresh, (int)XCurrentPage.Value);
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.First, 0);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.Previous, 0);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.Next, 0);
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.Last, 0);
        }

        private void refreshPagingInfo(Direction direction, int Page)
        {
            int CurrentPage = (int)XCurrentPage.Value;
            if (direction.Equals(Direction.Refresh)) CurrentPage = Page;

            int RecordsPerPage = (int)XRecordsPerPage.Value;

            TableRecords = _controller.getMaxAllPaging();
            MaxPage = TableRecords / RecordsPerPage;
            int rest = TableRecords % RecordsPerPage;

            switch (direction)
            {
                case Direction.First: // Show all
                    CurrentPage = 0;
                    break;
                case Direction.Previous: // Show all
                    if (CurrentPage > 0) CurrentPage--;
                    break;
                case Direction.Refresh: // Show all

                    break;
                case Direction.Next: // Show all
                    if (CurrentPage < MaxPage) CurrentPage++;
                    break;
                case Direction.Last: // Show all
                    CurrentPage = MaxPage;
                    break;
                default:
                    break;
            }
            XCurrentPage.Value = CurrentPage;
            _controller.getAllSinglePage((CurrentPage * RecordsPerPage), RecordsPerPage);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            _controller.create500();
        }
    }
 
 
}

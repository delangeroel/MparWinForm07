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
using static MparWinForm07.Mvc.Model.ActionCode;

namespace MparWinForm07.Mvc.View
{
    public partial class LoanView : Form, ILoanView
    {
        LoanController _controller;

        // Paging
        private int TableRecords;
        private int MaxPage;

        public LoanView()
        {
            InitializeComponent();
            PostInit();
        }

        private void PostInit()
        {     
            XCurrentPage.Value = 0;
            XRecordsPerPage.Value = 10;
            txComboStatus.DataSource = Enum.GetValues(typeof(Status));
        }
                

        public long id
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { this.txtUser.Text = ""+value; }
        }
        public decimal amount
        {
            get { return Convert.ToDecimal(txtAmount.Text); }
            set { this.txtAmount.Text = ""+value; }
        }
        public int customerNumber 
        {
            get { return Convert.ToInt32(txtCustomerNumber.Text); }
            set { this.txtCustomerNumber.Text = ""+value; }
        }
        public DateTime intrestDay
        {
            get { return Convert.ToDateTime(txtUser.Text); }
            set { this.txtUser.Text = ""+value; }
        }
 
        public string user
        {
            get { return txtUser.Text; }
            set { this.txtUser.Text = value; }
        }
        public DateTime changeDate
        {
            get { return Convert.ToDateTime(txtChangeDate.Text); }
            set { this.txtChangeDate.Text = ""+value; }
        }
        public Status status
        {
            get { return (Status)txComboStatus.SelectedItem; }
            set { txComboStatus.SelectedItem = value; }
        }
        public DateTime Timestamp
        {
            get { return Convert.ToDateTime(txtTimestamp.Text); }
            set { this.txtTimestamp.Text = ""+value; }
        }

        byte[] ILoanView.Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool CanModifyID
        {
            set { this.txtUser.Enabled = value; }
        }




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

        public void SetController(LoanController controller)
        {
            this._controller = controller;
        }

        public void ClearGrid()
        {
            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("Id", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("CustomerNumber", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Amount", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("IntrestDay", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("User", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("ChangeDate", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Status", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Timestamp", 200, HorizontalAlignment.Left);
            // Add rows to grid
            this.listView1.Items.Clear();
        }

        public void AddToGrid(Loan loan)
        {
            ListViewItem parent;
            parent = this.listView1.Items.Add("" + loan.Id);
            parent.SubItems.Add("" + loan.CustomerNumber);
            parent.SubItems.Add("" + loan.Amount);
            parent.SubItems.Add("" + loan.IntrestDay);
            parent.SubItems.Add("" + loan.User);
            parent.SubItems.Add("" + loan.ChangeDate);
            parent.SubItems.Add("" + loan.Status);
            parent.SubItems.Add("" + loan.Timestamp);
        }

        public void UpdateGrid(Model.ActionCode action)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(action.Actioncode) == 0)
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.Text = action.Actioncode;
                rowToUpdate.SubItems[1].Text = action.Description;
            }
        }

        public void RemoveFromGrid(Model.ActionCode action)
        {
            ListViewItem rowToRemove = null;

            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(action.Actioncode) == 0)
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

        public string GetIdOfSelectedInGrid()
        {
            if (this.listView1.SelectedItems.Count > 0)
                return this.listView1.SelectedItems[0].Text;
            else
                return "";
        }

        public void SetSelectedInGrid(Model.ActionCode action)
        {
            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(action.Actioncode) == 0)
                {
                    row.Selected = true;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
                this._controller.SelectedChanged( Convert.ToInt64(listView1.SelectedItems[0].Text));
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
        
        public void UpdateGrid(Loan loan)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(""+loan.Id) == 0)
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.Text = ""+loan.Id;
                rowToUpdate.SubItems[1].Text = ""+loan.CustomerNumber;
            }
        }

        public void RemoveFromGrid(Loan loan)
        {
            ListViewItem rowToRemove = null;

            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(""+loan.Id) == 0)
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

        public void SetSelectedInGrid(Loan loan)
        {
            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(""+loan.Id) == 0)
                {
                    row.Selected = true;
                }
            }
        }
    }
}
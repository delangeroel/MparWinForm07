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
    public partial class ActionView : Form, IActionView
    {
        public ActionView()
        {
            InitializeComponent();
        }

        ActionCodeController _controller;

        // Paging
        private int CurrentPage = 0;
        private int RecordsPerPage = 10;
        private int offset;
        private int TableRecords;
        private int MaxPage;

        public string Actioncode 
        {
            get { return txtActionCode.Text; }
            set { this.txtActionCode.Text = value; }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }
        public bool CanModifyID 
        {
            set { this.txtActionCode.Enabled = value; } 
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

        public void SetController(ActionCodeController controller)
        {
            this._controller = controller;
        }

        public void ClearGrid()
        {
            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("Action code", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Description", 200, HorizontalAlignment.Left);
            // Add rows to grid
            this.listView1.Items.Clear();
        }

        public void AddToGrid(ActionCode action)
        {
            ListViewItem parent;
            parent = this.listView1.Items.Add("" + action.Actioncode);
            parent.SubItems.Add("" + action.Description);
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
                this._controller.SelectedChanged(this.listView1.SelectedItems[0].Text);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {

        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo();
            CurrentPage = 0;
            offset = 0;
            _controller.getAllSinglePage(CurrentPage, RecordsPerPage);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {

            refreshPagingInfo();
            if (offset < RecordsPerPage) offset = 0;
            else offset = offset - RecordsPerPage;
            _controller.getAllSinglePage(offset, RecordsPerPage);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo();
            if (offset < TableRecords- RecordsPerPage) offset = offset + RecordsPerPage;
            else                       offset  = (TableRecords % RecordsPerPage)* RecordsPerPage;
            _controller.getAllSinglePage(offset, RecordsPerPage);

        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            // _controller.create500();
            refreshPagingInfo();
            offset = (MaxPage % RecordsPerPage) * RecordsPerPage;
            _controller.getAllSinglePage(offset, RecordsPerPage);
        }

        private void refreshPagingInfo()
        {
            TableRecords = _controller.getMaxAllPaging();

            switch ( RecordsPerPage )
            {
                case 0: // Show all
                    MaxPage =  10;
                    RecordsPerPage = TableRecords;
                    break;
                  default:
                    MaxPage  = TableRecords/ RecordsPerPage;
                    int rest = TableRecords % RecordsPerPage;
                    //if (rest>0) MaxPage = MaxPage + 1;
                    break;
            }
                               
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            _controller.create500();
        }
    }
}

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
    public partial class CountryView : Form, ICountryView
    {
        public string countrycode
        {
            get { return txtCountryCode.Text; }
            set { this.txtCountryCode.Text = value; }
        }
        public string countryName
        {
            get { return txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }
        byte[] OwnTimestamp;
//        public byte[] Timestamp
//        {
//            get { return OwnTimestamp; }
//            set { this.OwnTimestamp  = value; }
//                long longVar = BitConverter.ToInt64(byteValue, 0);
//                DateTime dateTimeVar = new DateTime(1980, 1, 1).AddMilliseconds(longVar);
//                return txtTimestamp.Text; 
//            }
//        }
        public bool CanModifyID
        {
            set { this.txtCountryCode.Enabled = value; }
        }

        public CountryView()
        {
            InitializeComponent();
            PostInit();
        }

        private void PostInit()
        {
            XCurrentPage.Value = 0;
            XRecordsPerPage.Value = 10;
        }
        CountryController _controller;

        // Paging
        private int TableRecords;
        private int MaxPage;
        int _countriesListSelectedItem;

        private void AddButton_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
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
        public void SetController(CountryController controller)
        {
            this._controller = controller;
        }

        public void ClearGrid()
        {
            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("Country code", 80, HorizontalAlignment.Left);
            this.listView1.Columns.Add("CountryName", 200, HorizontalAlignment.Left);
            //this.listView1.Columns.Add("Timestamp", 200, HorizontalAlignment.Left);
            // Add rows to grid
            this.listView1.Items.Clear();
            _countriesListSelectedItem = -1;
        }

        public void AddToGrid(Country country)
        {
            ListViewItem parent;
            parent = this.listView1.Items.Add("" + country.Countrycode);
            parent.SubItems.Add("" + country.CountryName);
            //parent.SubItems.Add("");
        }

        public void UpdateGrid(Country country)
        {
            if (_countriesListSelectedItem  < 0) return;

            ListViewItem rowToUpdate = listView1.Items[_countriesListSelectedItem];
                rowToUpdate.Text = country.Countrycode;
                rowToUpdate.SubItems[1].Text = country.CountryName;
                //rowToUpdate.SubItems[2].Text = ""+country.Timestamp;
        }

        public void RemoveFromGrid(int index)
        {
            if (_countriesListSelectedItem < 0) return;

            this.listView1.Items.RemoveAt(index);
        }


        public string GetIdOfSelectedInGrid()
        {
            if (this.listView1.SelectedItems.Count > 0)
                return this.listView1.SelectedItems[0].Text;
            else
                return "";
        }

        public void SetSelectedInGrid(Country country)
        {
            foreach (ListViewItem row in this.listView1.Items)
            {
                if (row.Text.CompareTo(country.Countrycode) == 0)
                {
                    row.Selected = true;
                    long getLong = BitConverter.ToInt64(country.Timestamp, 0);

                    DateTime getNow = DateTime.FromBinary(getLong);
                    //_selectedObject = 
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0) 
                this._controller.SelectedChanged(this.listView1.SelectedItems[0].Text);

        }














        public int GetSelectedIndex()
        {
            if (listView1.SelectedItems.Count ==0) return -1;
                return this.listView1.SelectedIndices[0];
        }
    }
}

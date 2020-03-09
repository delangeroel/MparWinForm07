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
        public string countrycode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string countryName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool CanModifyID { set => throw new NotImplementedException(); }

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
        ActionCodeController _controller;

        // Paging
        private int TableRecords;
        private int MaxPage;

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

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
            throw new NotImplementedException();
        }

        public void ClearGrid()
        {
            throw new NotImplementedException();
        }

        public void AddToGrid(Country country)
        {
            throw new NotImplementedException();
        }

        public void UpdateGrid(Country country)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromGrid(Country country)
        {
            throw new NotImplementedException();
        }

        public string GetIdOfSelectedInGrid()
        {
            throw new NotImplementedException();
        }

        public void SetSelectedInGrid(Country country)
        {
            throw new NotImplementedException();
        }
    }
}

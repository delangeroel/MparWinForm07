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
        public int CustomerNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string city { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Country countryCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool CanModifyID { set => throw new NotImplementedException(); }

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
        ActionCodeController _controller;

 

        private void RefreshButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void FirstButton_Click(object sender, EventArgs e)
        {

        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {

        }

        private void NextButton_Click(object sender, EventArgs e)
        {

        }

        private void LastButton_Click(object sender, EventArgs e)
        {

        }

        public void SetController(CustomerController controller)
        {
            throw new NotImplementedException();
        }

        public void ClearGrid()
        {
            throw new NotImplementedException();
        }

        public void AddToGrid(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateGrid(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromGrid(Customer customer)
        {
            throw new NotImplementedException();
        }

        public string GetIdOfSelectedInGrid()
        {
            throw new NotImplementedException();
        }

        public void SetSelectedInGrid(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

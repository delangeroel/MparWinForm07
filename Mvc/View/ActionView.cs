﻿using MparWinForm07.Mvc.Controller;
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
    public partial class ActionView : Form, IActionView
    {
        public ActionView()
        {
            InitializeComponent();
            PostInit();
        }

        private void PostInit()
        {
            txComboKleur.DataSource = Enum.GetValues(typeof(Kleuren));
            XCurrentPage.Value  = 0;
            XRecordsPerPage.Value = 10;
        }
        ActionCodeController _controller;

        // Paging
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
        private Kleuren _Kleur;
        public Kleuren Kleur
        {
            get { return (Kleuren)txComboKleur.SelectedItem; }
            set { txComboKleur.SelectedItem = value; }
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
            this.listView1.Columns.Add("Kleur", 200, HorizontalAlignment.Left);
            // Add rows to grid
            this.listView1.Items.Clear();
        }

        public void AddToGrid(ActionCode action)
        {
            ListViewItem parent;
            parent = this.listView1.Items.Add("" + action.Actioncode);
            parent.SubItems.Add("" + action.Description);
            parent.SubItems.Add(action.Kleur.ToString() );
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
            refreshPagingInfo(Direction.Last,0);
        }

        private void refreshPagingInfo(Direction direction, int Page)
        {   
            int CurrentPage = (int)XCurrentPage.Value;
            if (direction.Equals(Direction.Refresh)) CurrentPage = Page;

            int RecordsPerPage = (int)XRecordsPerPage.Value;

            TableRecords = _controller.getMaxAllPaging();
            MaxPage = TableRecords / RecordsPerPage;
            int rest = TableRecords % RecordsPerPage;

            switch ( direction  )
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
    public enum Direction
    {
        First, Previous, Refresh, Next, Last
    }
}

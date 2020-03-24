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
    public partial class Blog2View : Form, IBlog2View
    {
        // ----------------------------
        // Controllers
        // ----------------------------
        Blog2Controller _controller;
        // ----------------------------
        // Paging
        // ----------------------------
        private int TableRecords;
        private int MaxPage;
        private int _selectedRow;
        // ----------------------------
        // Contructor & Controller
        // ----------------------------
        public Blog2View()
        {
            InitializeComponent();
            PostInit();
        }
        private void PostInit()
        {
            XCurrentPage.Value = 0;
            XRecordsPerPage.Value = 10;
            selectedRow = -1;
        }
        // ----------------------------
        // Buttons
        // ----------------------------
        private void newButton_Click(object sender, EventArgs e)
        {
            this._controller.AddBlog();
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            this._controller.RemoveBlog();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            this._controller.Save();
        }
        private void firstButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.First, 0);
        }
        private void previousButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.Previous, 0);
        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.Next, 0);
        }
        private void lastButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.Last, 0);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
                this._controller.SelectedChanged(this.listView1.SelectedIndices[0]);
        }
        // ----------------------------
        // Interface
        // ----------------------------
        public void EnableInput(Boolean enable)
        {
            this.txtBlogId.Enabled = enable;
            this.txtUrl.Enabled = enable;
        }
        public void SetController(Blog2Controller controller)
        {
            _controller = controller;
        }
        public void ClearGrid()
        {
            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("Blog Id", 200, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Url", 200, HorizontalAlignment.Left);
            // Add rows to grid
            this.listView1.Items.Clear();
        }
        public void AddToGrid(Blog blog)
        {
            ListViewItem parent;
            parent = this.listView1.Items.Add("" + blog.BlogId);
            parent.SubItems.Add("" + blog.Url);             
        }
        public void UpdateGrid(Blog blog)
        {
            if (_selectedRow >= 0)
            {
                ListViewItem rowToUpdate = listView1.SelectedItems[ 0 ];
                rowToUpdate.Text = "" + blog.BlogId;
                rowToUpdate.SubItems[1].Text = "" + blog.Url;
                //rowToUpdate.SubItems[2].Text = blog.Url;
            }
            

        }
        public void RemoveFromGrid(Blog blog)
        {
            selectedRow = getIndexOfGrid();
            if (selectedRow >= 0)
            {
                listView1.SelectedItems[0].Remove();
                listView1.Focus();
            }

        }
        public int getIndexOfGrid()
        {
            if (listView1.FocusedItem == null) return -1;
            return listView1.FocusedItem.Index;
        }
        public void SetIndexOfGrid(int index)
        {
            if (index >= 0)
            {
                listView1.Items[index].Selected = true;
                listView1.Select();
                EnableInput(true);
            } 
            else
            {
                EnableInput(false);
            }
        }

 
 
        // ----------------------------
        // Field mappaing with Interface
        // ----------------------------
        public long Id
        {
            get { return Convert.ToInt32(txtBlogId.Text); }
            set { this.txtBlogId.Text = "" + value; }
        }
        public string Url
        {
            get { return txtUrl.Text; }
            set { this.txtUrl.Text = "" + value; }
        }
        public bool CanModifyID
        {
            set { this.txtBlogId.Enabled = value; }
        }

        public int selectedRow
        {
            get { return _selectedRow; }
            set { this._selectedRow = value; }
        }
        // ----------------------------
        // Page processing
        // ----------------------------
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


    }
}

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
    public partial class BlogView : Form, IBlogView
    {
        // ----------------------------
        // Controllers
        // ----------------------------
        BlogController _controller;

        // ----------------------------
        // Paging
        // ----------------------------
        private int TableRecords;
        private int MaxPage;
        private int selectedIndex;

        // ----------------------------
        // Contructor & Controller
        // ----------------------------
        public BlogView()
        {
            InitializeComponent();
            PostInit();
        }
        private void PostInit()
        {
            XCurrentPage.Value = 0;
            XRecordsPerPage.Value = 10;
            selectedIndex = -1;
        }

        public void SetController(BlogController controller)
        {
            _controller = controller;
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

        // ----------------------------
        // Buttons
        // ----------------------------
        private void firstButton_Click(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.First, 0);
        }
        
        private void newButton_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
            _controller.AddNew();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            _controller.Remove();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _controller.Save();
        }

        private void firstButton_Click_1(object sender, EventArgs e)
        {
            refreshPagingInfo(Direction.First, 0);
        }
        
        private void previousButton_Click_1(object sender, EventArgs e)
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

 
        // ----------------------------
        // Screen response
        // ----------------------------
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listView1.FocusedItem.Index;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = listView1.FocusedItem.Index;
            this.listView1.Items[1].Selected = true;
        }

        public int getIndexOfGrid()
        {
            selectedIndex = listView1.FocusedItem.Index;
            return selectedIndex;
        }

        public void SetIndexInGrid(int index)
        {
            listView1.Items[index].Selected = true;
            listView1.Select();
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

        public void UpdateGridItem(Blog blog)
        {
            int index = getIndexOfGrid();
            if (index < 0) return;
            ListViewItem rowToUpdate = null;
            // Bepaal huidige index
            rowToUpdate = listView1.Items[index];
            // Haal row op
            if (rowToUpdate != null)
            {
                rowToUpdate.Text = "" + blog.BlogId;
                rowToUpdate.SubItems[1].Text = blog.Url;
            }
        }

        public void RemoveFromGrid(Blog blog)
        {
            int index = getIndexOfGrid();
            if (index < 0) return;

            ListViewItem rowToRemove = listView1.SelectedItems[index];
            if (rowToRemove != null)
            {
                this.listView1.Items.Remove(rowToRemove);
                this.listView1.Focus();
            }
        }

        public void create500()
        {
            _controller.createRecords(50);
        }
    }
}

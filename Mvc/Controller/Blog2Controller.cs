using MparWinForm07.Mvc.Model;
using MparWinForm07.Mvc.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MparWinForm07.Mvc.Controller
{
    public class Blog2Controller
    {
        IBlog2View _view;
        IList _blogs;
        Blog _selectedBlog;
        BlogService blogService = new BlogService();
        int selectedRow = 0;

        // ----------------------------
        // Constructor
        // ----------------------------
        public Blog2Controller(IBlog2View view, IList blogs)
        {
            _view = view;
            _blogs = blogs;
            view.SetController(this);
        }
        // ----------------------------
        // Retrieve array
        // ----------------------------
        public IList Blogs
        {
            get { return ArrayList.ReadOnly(_blogs); }
        }
        // ----------------------------
        // Screen object exchange
        // ----------------------------
        private void updateView(Blog blog)
        {
            _view.Id = blog.BlogId;
            _view.Url = blog.Url;
        }
        private void updateObject(Blog blog)
        {
            blog.BlogId = _view.Id;
            blog.Url = _view.Url;
        }
        public void AddBlog()
        {
            _selectedBlog = new Blog();
            this.updateView(_selectedBlog);
            this._view.CanModifyID = true;
        }
        public void RemoveBlog()
        {
            int index = _view.getIndexOfGrid();
            _selectedBlog = (Blog)_blogs[index];
            _blogs.Remove(_selectedBlog);
            _view.RemoveFromGrid(_selectedBlog);
        }
        public void Save()
        {
            // Blog _ScreenCustomer = new Blog();
            updateObject(_selectedBlog);
            if (errorsFound(_selectedBlog))
            {
                return;
            }
            updateObject(_selectedBlog);
            if (!this._blogs.Contains(_selectedBlog))
            {
                // Add Blog
                this._blogs.Add(_selectedBlog);
                this._view.AddToGrid(_selectedBlog);
            }
            else
            {
                this._view.UpdateGrid(_selectedBlog);
            }
            
        }

        public Boolean errorsFound(Blog _selectedBlog)
        {
            ValidationContext context = new ValidationContext(_selectedBlog, null, null);

            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(_selectedBlog, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage, "Errors found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                //MessageBox.Show("Validated");
            }
            return false;
        }

        // ----------------------------
        // Load screen information
        // ----------------------------
        public void LoadView()
        {
            _view.ClearGrid();
            //foreach (Blog blog in _blogs)
            //    _view.AddToGrid(blog);
            getAllSinglePage(0, 10);
            if (_blogs.Count>0)
            _view.SetIndexOfGrid(0);
        }
  
        // ----------------------------
        // Selection changed
        // ----------------------------
        public void SelectedChanged(int index)
        {
             _view.selectedRow = index;
            if (index >= 0)
            {
                selectedRow = index;
                _selectedBlog = (Blog)_blogs[index];
                updateView(_selectedBlog);
                _view.SetIndexOfGrid(index);
                this._view.CanModifyID = false;

            }

        }

        public int getMaxAllPaging()// Count number of records in table
        {
            return blogService.getMaxAllPaging();
        }
        public void getAllSinglePage(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Blog blog in blogService.getAllPaging(offset, showrecords))
            {
                _view.AddToGrid(blog);
                _blogs.Add(blog);
            }
                
        }
    }
}

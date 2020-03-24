using MparWinForm07.Mvc.Model;
using MparWinForm07.Mvc.Service;
using MparWinForm07.Mvc.View;
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
    public class BlogController  
    {
        IBlogView _view;
        IList _blogList;
        Blog  _selectedObject;
        BlogService blogService = new BlogService();  

        public BlogController(IBlogView view, IList blogList)
        {
            _view = view;
            _blogList = blogList;
            view.SetController(this);
            blogService = new BlogService();
        }

        public IList Blogs
        {
            get {  return ArrayList.ReadOnly(_blogList);}
        }
        public void LoadView()
        {
            //refreshPagingInfo(Direction.First, 0);
        }

        public void getAllSinglePage(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Blog blog in blogService.getAllPaging(offset, showrecords))
                _view.AddToGrid(blog);
        }

        public void clearGrid()
        {
            
        }

        public void AddToGrid()
        {
            _selectedObject = new Blog();

            this.updateViewValues(_selectedObject);
            this._view.CanModifyID = true;
          
        }

        public void UpdateGridWithChanged(Blog blog)
        {
             
        }

        public void RemoveFromGrid(Blog blod)
        {
             
        }

        public string getIdOfGrid(Blog blog)
        {
            return "";
        }

        public void SetSelectedIdInGrid(int index)
        {
            //_view.listview1.Items[1].Selected = true;
        }
 
        public void SelectedChanged(long blogId)
        {
        }
        private void updateViewValues(Blog blog)
        {
            _view.Id = blog.BlogId;
            _view.Url = blog.Url;
        }
        private void updateWithViewValues(Blog blog)
        {
            blog.BlogId = Convert.ToInt32(_view.Id);
            blog.Url = _view.Url;
        }


        public void AddNew()
        {
            _selectedObject = new Blog();

            this.updateViewValues(_selectedObject);
            this._view.CanModifyID = true;
        }
        public void Save()
        {
            updateViewValues(_selectedObject);
            if (hasErrors(_selectedObject)) return;

            if (!this._blogList.Contains(_selectedObject))
            {

                blogService.save(_selectedObject);
                // Add new user
                this._blogList.Add(_selectedObject);
                this._view.AddToGrid(_selectedObject);
            }
            else
            {
                // Update existing
                blogService.save(_selectedObject);
                this._view.UpdateGridItem(_selectedObject);
            }
            _view.SetIndexInGrid(1111111111);
            this._view.CanModifyID = false;
        }
        public void Remove()
        {
            int id = this._view.getIndexOfGrid();
            Blog blogToRemove = new Blog();
            if (id != 0)
            {
                foreach (Blog blog in this._blogList)
                {
                    if (blog.BlogId == id)
                    {
                        blogToRemove = blog;
                        break;
                    }
                }

                if (blogToRemove != null)
                {
                    blogService.delete(_selectedObject);
                    int newSelectedIndex = this._blogList.IndexOf(blogToRemove);
                    this._blogList.Remove(blogToRemove);
                    this._view.RemoveFromGrid(blogToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _blogList.Count)
                    {
                        
                    }
                }
            }

        }
        public Boolean hasErrors(Blog blog)
        {
            Boolean noErrors = false;

            ValidationContext context = new ValidationContext(_selectedObject, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(_selectedObject, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    MessageBox.Show(result.ErrorMessage,
                                    "Errors found",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                noErrors = true;
            }
            else
            {
                //MessageBox.Show("Validated");
                noErrors = false;
            }
            return noErrors;
            // EF YourDbContext.Entity(YourEntity).GetValidationResult();
        }

        public int getMaxAllPaging()// Count number of records in table
        {
            return blogService.getMaxAllPaging();
        }

        public void createRecords(int createNumberOfRecords)
        {
            blogService.createRecords(createNumberOfRecords);
        }

    }
}

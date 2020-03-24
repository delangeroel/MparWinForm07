using MparWinForm07.Mvc.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Controller
{
    public interface iBlogController
    {
        void PostInit();
        IList Blogs();
        void updateView(Blog blog);
        void updateObject(Blog blog);
        void AddBlog();
        void RemoveBlog();
        void Save();
        Boolean errorsFound(Blog _selectedBlog);
        void LoadView();
        void SelectedChanged(int index);
        int getMaxAllPaging();
        void getAllSinglePage(int offset, int showrecords);
    }
}

using MparWinForm07.Mvc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Controller
{
    public interface IBlogView
    {
        void SetController(BlogController controller);
        
        void ClearGrid();
        void AddToGrid(Blog blog);
        void UpdateGridItem(Blog blog);
        void RemoveFromGrid(Blog blog);
        
        int getIndexOfGrid();
        void SetIndexInGrid(int index);
  
        long  Id { get; set; }
        string Url { get; set; }
        bool CanModifyID { set; }
    }
}

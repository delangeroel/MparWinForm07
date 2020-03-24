using MparWinForm07.Mvc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Controller
{
    public interface IBlog2View
    {
        void SetController(Blog2Controller controller);
        void EnableInput(Boolean enable);
        void ClearGrid();
        void AddToGrid(Blog blog);
        void UpdateGrid(Blog blog);
        void RemoveFromGrid(Blog blog);

        int getIndexOfGrid();
        void SetIndexOfGrid(int index);

        long Id { get; set; }
        string Url { get; set; }
        bool CanModifyID { set; }
        int selectedRow { get; set; }
    }
}


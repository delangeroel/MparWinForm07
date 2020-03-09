using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MparWinForm07.Mvc.Model;
using static MparWinForm07.Mvc.Model.ActionCode;

namespace MparWinForm07.Mvc.Controller
{
    public interface IActionView
    {
        void SetController(ActionCodeController controller);
        void ClearGrid();
        void AddToGrid(ActionCode action);
        void UpdateGrid(ActionCode action);
        void RemoveFromGrid(ActionCode v);
        string GetIdOfSelectedInGrid();
        void SetSelectedInGrid(ActionCode action);

        string Actioncode { get; set; }
        string Description { get; set; }
        Kleuren Kleur { get; set; }
        bool CanModifyID { set; }
    }
}

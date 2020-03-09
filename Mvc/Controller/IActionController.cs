using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MparWinForm07.Mvc.Model;
using static MparWinForm07.Mvc.Model.ActionCode;

namespace MparWinForm07.Mvc.Controller
{
    public interface IActionController
    {
        //string actioncode;
        //string description;
        //Kleuren kleur;

        IList Action();
        void AddNew();
        void LoadView();
        void Remove();
        void Save();
        void SelectedChanged(string actionKey);
        void UpdateViewDetailValues(ActionCode action);
        void UpdateWithViewValues(ActionCode action);

    }
}

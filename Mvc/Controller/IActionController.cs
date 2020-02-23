using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MparWinForm07.Mvc.Model;

namespace MparWinForm07.Mvc.Controller
{
    public interface IActionController
    {
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

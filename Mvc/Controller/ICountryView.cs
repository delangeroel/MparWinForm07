using MparWinForm07.Mvc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Controller
{
    public interface ICountryView
    {
        string countrycode { get; set; }
        string countryName { get; set; }
        byte[] Timestamp { get; set; }

        bool CanModifyID { set; }
        void SetController(CountryController controller);
        void ClearGrid();
        void AddToGrid(Country country);
        void UpdateGrid(Country country);
        void RemoveFromGrid(Country country);
        string GetIdOfSelectedInGrid();
        void SetSelectedInGrid(Country country);

    }
}

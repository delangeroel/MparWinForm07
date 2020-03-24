using MparWinForm07.Mvc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Controller
{
    public interface ICustomerView
    {
        void SetController(CustomerController controller);
        void ClearGrid();
        void AddToGrid(Customer customer);
        void UpdateGrid(Customer customer);
        void RemoveFromGrid(Customer customer);
        int GetIdOfSelectedInGrid();
        void SetSelectedInGrid(Customer customer);


        int CustomerNumber { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string CountryCode { get; set; }

       DateTime Timestamp { get; set; }
        bool CanModifyID { set; }
    }
}

using MparWinForm07.Mvc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Controller
{
    public interface ILoanView
    {
        void SetController(LoanController controller);
        void ClearGrid();
        void AddToGrid(Loan loan);
        void UpdateGrid(Loan loan);
        void RemoveFromGrid(Loan loan);
        string GetIdOfSelectedInGrid();
        void SetSelectedInGrid(Loan loan);

        long id { get; set; }
        int customerNumber { get; set; }
        decimal amount { get; set; }
        DateTime intrestDay { get; set; }
        string user { get; set; }
        DateTime changeDate { get; set; }
        Status status { get; set; }

        byte[] Timestamp { get; set; }

        bool CanModifyID { set; }
    }
}

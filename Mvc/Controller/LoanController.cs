using MparWinForm07.Mvc.Model;
using MparWinForm07.Mvc.Service;
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
    public class LoanController
    {
        ILoanView _view;
        IList _LoansList;
        Loan _selectedObject;
        LoanService loanService;

        public LoanController(ILoanView view, IList loanList)//
        {
            _view = view;
            _LoansList = loanList;
            view.SetController(this);
            loanService = new LoanService();
        }

        public IList Action()
        {
            return ArrayList.ReadOnly(_LoansList);
        }
        public void LoadView()
        {
            getAllSinglePage(0, 10);
        }
        public void LoadView(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Loan loan in loanService.getAllPaging(offset, showrecords))
                _view.AddToGrid(loan);

            if (_LoansList.Count > 0)
                _view.SetSelectedInGrid((Loan)_LoansList[0]);
        }

        public void getAllSinglePage(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Loan loan in loanService.getAllPaging(offset, showrecords))
                _view.AddToGrid(loan);

            if (_LoansList.Count > 0)
                _view.SetSelectedInGrid((Loan)_LoansList[0]);
        }
                                      
        public void SelectedChanged(long loanKey)
        {
            foreach (Loan loan in this._LoansList)
            {
                if (loan.Id==loanKey )
                {
                    _selectedObject = loan;

                    // Refresh
                    LoanService loanCodeService = new LoanService();
                    _selectedObject = loanCodeService.getLoanCode(_selectedObject.Id);
                    // End Refresh

                    UpdateViewDetailValues(_selectedObject);
                    _view.SetSelectedInGrid(_selectedObject);
                    this._view.CanModifyID = false;
                    break;
                }
            }
        }

        public void UpdateViewDetailValues(Loan loan)//
        {
            _view.id = loan.Id;
            _view.customerNumber = loan.CustomerNumber;
            _view.amount = loan.Amount;
            _view.intrestDay = loan.IntrestDay;
            _view.user = loan.User;
            _view.status = loan.Status;             
        }

        public void UpdateWithViewValues(Loan loan)//
        {
            loan.Id = _view.id;
            loan.CustomerNumber = _view.customerNumber;
            loan.Amount = _view.amount;
            loan.IntrestDay = _view.intrestDay;
            loan.User = _view.user;
            loan.Status = _view.status;

        }
               
        public void AddNew()
        {
            _selectedObject = new Loan(0, 0.0m, DateTime.Now, "", Status.Inactive);

            this.UpdateViewDetailValues(_selectedObject);
            this._view.CanModifyID = true;
        }
        public void Save()
        {
            UpdateWithViewValues(_selectedObject);
            if (hasErrors(_selectedObject)) return;


            if (!this._LoansList.Contains(_selectedObject))
            {

                loanService.save(_selectedObject);
                // Add new user
                this._LoansList.Add(_selectedObject);
                this._view.AddToGrid(_selectedObject);
            }
            else
            {
                // Update existing
                loanService.save(_selectedObject);
                this._view.UpdateGrid(_selectedObject);
            }
            _view.SetSelectedInGrid(_selectedObject);
            this._view.CanModifyID = false;
        }
        public void Remove()
        {
            string id = this._view.GetIdOfSelectedInGrid();
            Loan loanToRemove = null;

            if (id != "")
            {
                foreach (Loan loan in this._LoansList)
                {
                    if (loan.Id.CompareTo(id) == 0)
                    {
                        loanToRemove = loan;
                        break;
                    }
                }

                if (loanToRemove != null)
                {
                    loanService.delete(_selectedObject);
                    int newSelectedIndex = this._LoansList.IndexOf(loanToRemove);
                    this._LoansList.Remove(loanToRemove);
                    this._view.RemoveFromGrid(loanToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _LoansList.Count)
                    {
                        this._view.SetSelectedInGrid((Loan)_LoansList[newSelectedIndex]);
                    }
                }
            }
        }
        public Boolean hasErrors(Loan _selectedObject)
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
            return loanService.getMaxAllPaging();
        }
        public void getAllPaging(int startPage, int showrecords)
        {
            //actionCodeService.getAllPaging(startPage, showrecords);
        }
        public void create500()
        {
            loanService.create500();
        }
    }
}


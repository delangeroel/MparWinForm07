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
    public class CustomerController
    {
        ICustomerView _view;
        IList _customersList;
        Customer _selectedObject;
        CustomerService customerService;
        CountryService countryService = new CountryService();

        public CustomerController(ICustomerView view, IList customersList)//
        {
            _view = view;
            _customersList = customersList;
            view.SetController(this);
            customerService = new CustomerService();
        }

        public IList Action()
        {
            return ArrayList.ReadOnly(_customersList);
        }


        public void AddNew()
        {
            _selectedObject = new Customer();

            this.UpdateViewDetailValues(_selectedObject);
            this._view.CanModifyID = true;
        }
      public void Remove()
        {
            int id = this._view.GetIdOfSelectedInGrid();
            Customer customerToRemove = null;

            if (id != 0)
            {
                foreach (Customer customer in this._customersList)
                {
                    if (customer.CustomerNumber == id)
                    {
                        customerToRemove = customer;
                        break;
                    }
                }

                if (customerToRemove != null)
                {
                    customerService.delete(_selectedObject);
                    int newSelectedIndex = this._customersList.IndexOf(customerToRemove);
                    this._customersList.Remove(customerToRemove);
                    this._view.RemoveFromGrid(customerToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _customersList.Count)
                    {
                        this._view.SetSelectedInGrid((Customer)_customersList[newSelectedIndex]);
                    }
                }
            }
        }

        public void Save()
        {
            UpdateWithViewValues(_selectedObject);
            if (hasErrors(_selectedObject)) return;


            if (!this._customersList.Contains(_selectedObject))
            {

                customerService.save(_selectedObject);
                // Add new user
                this._customersList.Add(_selectedObject);
                this._view.AddToGrid(_selectedObject);
            }
            else
            {
                // Update existing
                customerService.save(_selectedObject);
                this._view.UpdateGrid(_selectedObject);
            }
            _view.SetSelectedInGrid(_selectedObject);
            this._view.CanModifyID = false;
        }

        public void LoadView()
        {
            getAllSinglePage(0, 10);
        }
        public void LoadView(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Customer actioncode in customerService.getAllPaging(offset, showrecords))
                _view.AddToGrid(actioncode);

            if (_customersList.Count > 0)
                _view.SetSelectedInGrid((Customer)_customersList[0]);
        }

        public void getAllSinglePage(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Customer customer in customerService.getAllPaging(offset, showrecords))
                _view.AddToGrid(customer);

            if (_customersList.Count > 0)
                _view.SetSelectedInGrid((Customer)_customersList[0]);
        }

  
        public Boolean hasErrors(Customer _selectedObject)
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

        public void SelectedChanged(int customerNumber)
        {
            foreach (Customer customer in this._customersList)
            {
                if (customer.CustomerNumber==(customerNumber)  )
                {
                    _selectedObject = customer;

                    // Refresh
                    CustomerService customerService = new CustomerService();
                    _selectedObject = customerService.getCustomerNumber(_selectedObject.CustomerNumber);
                    // End Refresh

                    UpdateViewDetailValues(_selectedObject);
                    _view.SetSelectedInGrid(_selectedObject);
                    this._view.CanModifyID = false;
                    break;
                }
            }
        }

        public void UpdateViewDetailValues(Customer customer)//
        {
            _view.CustomerNumber = customer.CustomerNumber;
            _view.Name = customer.Name;
            _view.Address = customer.Address;
            _view.City = customer.City;
            _view.CountryCode = customer.CountryCode.Countrycode;
        }

        public void UpdateWithViewValues(Customer customer)//
        {
            customer.CustomerNumber = _view.CustomerNumber;
            customer.Name = _view.Name;
            customer.Address = _view.Address;
            customer.City = _view.City;
            customer.CountryCode = countryService.getActionCode(_view.CountryCode );
        }

        public int getMaxAllPaging()// Count number of records in table
        {
            return customerService.getMaxAllPaging();
        }
        public void getAllPaging(int startPage, int showrecords)
        {

            //actionCodeService.getAllPaging(startPage, showrecords);

        }
        public void create500()
        {
            customerService.create500();
        }
    }
}


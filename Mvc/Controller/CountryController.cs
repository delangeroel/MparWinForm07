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
    public class CountryController 
    {
        ICountryView _view;
        IList _countriessList;       
        Country _selectedObject;
        CountryService countryService = new CountryService();

        public CountryController(ICountryView view, IList countriesList)//
        {
            _view = view;
            _countriessList = countriesList;
            view.SetController(this);
            //CountryService = new CountryService();
        }

        public IList Country()
        {
            return ArrayList.ReadOnly(_countriessList);
        }

        public void AddNew()
        {
            _selectedObject = new Country("", "");

            this.UpdateViewDetailValues(_selectedObject);
            this._view.CanModifyID = true;
        }

        public void LoadView()
        {
            getAllSinglePage(0, 10);
        }
        public void LoadView(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Country country in countryService.getAllPaging(offset, showrecords))
                _view.AddToGrid(country);

            if (_countriessList.Count > 0)
            {
                _view.SetSelectedInGrid((Country)_countriessList[0]);

            }
                
        }

        public void getAllSinglePage(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Country country in countryService.getAllPaging(offset, showrecords))
            {
                _view.AddToGrid(country);
            }
                

            if (_countriessList.Count > 0)
                _view.SetSelectedInGrid((Country)_countriessList[0]);
        }

        public void Remove()
        {
            int index = _view.GetSelectedIndex();
            // Remove from screen
            // Remove from list
            // Remove from disk
            try
            {
                countryService.delete(_selectedObject);
                this._countriessList.RemoveAt(index);
                _view.RemoveFromGrid(index);
            }
            catch (Exception)
            {

            }
        }

        public void Save()
        {
            int index = _view.GetSelectedIndex();

            // Move fields from screen to object
            // Check on errors
            // If no errors, determine add or update situation
            // When add: 
            //     Save record and update screen and array
            // When update:
            //     Save record and update screen and array
            //     Position cursor on updated object
            // 
            UpdateWithViewValues(_selectedObject);
            if (hasErrors(_selectedObject)) return;

            int x = _view.GetSelectedIndex();
            if (_view.GetSelectedIndex()<0)
            {

                long getLong = BitConverter.ToInt64(_selectedObject.Timestamp, 0);
                DateTime getNow = DateTime.FromBinary(getLong);

                countryService.save(_selectedObject);
                // Add new user
                this._countriessList.Add(_selectedObject);
                this._view.AddToGrid(_selectedObject);
            }
            else
            {
                // Update existing

                long getLong = BitConverter.ToInt64(_selectedObject.Timestamp, 0);
                DateTime getNow = DateTime.FromBinary(getLong);

                countryService.save(_selectedObject);
                this._view.UpdateGrid(_selectedObject);
            }
            _view.SetSelectedInGrid(_selectedObject);
            this._view.CanModifyID = false;
        }

        public Boolean hasErrors(Country _selectedObject)
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

        public void SelectedChanged(string key)
        {
            foreach (Country country in this._countriessList)
            {
                if (country.Countrycode.CompareTo(key) == 0)
                {
                    _selectedObject = country;
                    long getLong = BitConverter.ToInt64(country.Timestamp, 0);
                    DateTime getNow = DateTime.FromBinary(getLong);

                    // Refresh
                    CountryService countryService = new CountryService();
                    _selectedObject = countryService.getActionCode(_selectedObject.Countrycode);
                      getLong = BitConverter.ToInt64(_selectedObject.Timestamp, 0);
                      getNow = DateTime.FromBinary(getLong);
                    // End Refresh

                    UpdateViewDetailValues(_selectedObject);
                    getLong = BitConverter.ToInt64(_selectedObject.Timestamp, 0);
                    getNow = DateTime.FromBinary(getLong);

                    _view.SetSelectedInGrid(_selectedObject);
                    getLong = BitConverter.ToInt64(_selectedObject.Timestamp, 0);
                    getNow = DateTime.FromBinary(getLong);
                    this._view.CanModifyID = false;
                    break;
                }
            }
        }

        public void UpdateViewDetailValues(Country country)//
        {
            _view.countrycode = country.Countrycode;
            _view.countryName= country.CountryName;
            //_view.Timestamp = country.Timestamp;
        }

        public void UpdateWithViewValues(Country country)//
        {
            country.Countrycode = _view.countrycode;
            country.CountryName = _view.countryName;
            //country.Timestamp = _view.Timestamp;
        }

        public int getMaxAllPaging()// Count number of records in table
        {
            return countryService.getMaxAllPaging();
        }
        public void getAllPaging(int startPage, int showrecords)
        {

            //actionCodeService.getAllPaging(startPage, showrecords);

        }
        public void create500()
        {
            countryService.create500();
        }
    }
}

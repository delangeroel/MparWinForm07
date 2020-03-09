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
        CountryService countryService;

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
                _view.SetSelectedInGrid((Country)_countriessList[0]);
        }

        public void getAllSinglePage(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (Country country in countryService.getAllPaging(offset, showrecords))
                _view.AddToGrid(country);

            if (_countriessList.Count > 0)
                _view.SetSelectedInGrid((Country)_countriessList[0]);
        }

        public void Remove()
        {
            string id = this._view.GetIdOfSelectedInGrid();
            Country countrynToRemove = null;

            if (id != "")
            {
                foreach (Country country in this._countriessList)
                {
                    if (country.countrycode.CompareTo(id) == 0)
                    {
                        countrynToRemove = country;
                        break;
                    }
                }

                if (countrynToRemove != null)
                {
                    countryService.delete(_selectedObject);
                    int newSelectedIndex = this._countriessList.IndexOf(countrynToRemove);
                    this._countriessList.Remove(countrynToRemove);
                    this._view.RemoveFromGrid(countrynToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _countriessList.Count)
                    {
                        this._view.SetSelectedInGrid((Country)_countriessList[newSelectedIndex]);
                    }
                }
            }
        }

        public void Save()
        {
            UpdateWithViewValues(_selectedObject);
            if (hasErrors(_selectedObject)) return;


            if (!this._countriessList.Contains(_selectedObject))
            {

                countryService.save(_selectedObject);
                // Add new user
                this._countriessList.Add(_selectedObject);
                this._view.AddToGrid(_selectedObject);
            }
            else
            {
                // Update existing
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

        public void SelectedChanged(string actionKey)
        {
            foreach (Country country in this._countriessList)
            {
                if (country.countrycode.CompareTo(actionKey) == 0)
                {
                    _selectedObject = country;

                    // Refresh
                    CountryService countryService = new CountryService();
                    _selectedObject = countryService.getActionCode(_selectedObject.countrycode);
                    // End Refresh

                    UpdateViewDetailValues(_selectedObject);
                    _view.SetSelectedInGrid(_selectedObject);
                    this._view.CanModifyID = false;
                    break;
                }
            }
        }

        public void UpdateViewDetailValues(Country country)//
        {
            _view.countrycode = country.countrycode;
            _view.countryName= country.countryName; 
        }

        public void UpdateWithViewValues(Country country)//
        {
            country.countrycode = _view.countrycode;
            country.countryName = _view.countryName; 
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

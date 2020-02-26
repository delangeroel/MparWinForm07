using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using MparWinForm07.Mvc.Model;
using MparWinForm07.Mvc.Service;

namespace MparWinForm07.Mvc.Controller
{
    public class ActionCodeController : IActionController
    {
        IActionView _view;
        IList _actioncodesList;
        ActionCode _selectedObject;
        ActionCodeService actionCodeService;

        public ActionCodeController(IActionView view, IList actionList)//
        {
            _view = view;
            _actioncodesList = actionList;
            view.SetController(this);
            actionCodeService = new ActionCodeService();
        }


        public IList Action()
        {
            return ArrayList.ReadOnly(_actioncodesList);
        }

        public void AddNew()
        {
            _selectedObject = new ActionCode("", "");

            this.UpdateViewDetailValues(_selectedObject);
            this._view.CanModifyID = true;
        }

        public void LoadView() {

            getAllSinglePage(0, 10);
        }
        public void LoadView(int offset, int showrecords)
        {
            _view.ClearGrid();  
            foreach (ActionCode actioncode in actionCodeService.getAllPaging(offset, showrecords))
                _view.AddToGrid(  actioncode );

            if (_actioncodesList.Count>0)
            _view.SetSelectedInGrid((ActionCode)_actioncodesList[0]);
        }

        public void getAllSinglePage(int offset, int showrecords)
        {
            _view.ClearGrid();
            foreach (ActionCode actioncode in actionCodeService.getAllPaging(offset, showrecords))
                _view.AddToGrid(actioncode);

            if (_actioncodesList.Count > 0)
                _view.SetSelectedInGrid((ActionCode)_actioncodesList[0]);
        }

        public void Remove()
        {
            string id = this._view.GetIdOfSelectedInGrid();
            ActionCode ActionToRemove = null;

            if (id != "")
            {
                foreach (ActionCode action in this._actioncodesList)
                {
                    if (action.Actioncode.CompareTo(id) == 0)
                    {
                        ActionToRemove = action;
                        break;
                    }
                }

                if (ActionToRemove != null)
                {
                    actionCodeService.delete(_selectedObject);
                    int newSelectedIndex = this._actioncodesList.IndexOf(ActionToRemove);
                    this._actioncodesList.Remove(ActionToRemove);
                    this._view.RemoveFromGrid(ActionToRemove);

                    if (newSelectedIndex > -1 && newSelectedIndex < _actioncodesList.Count)
                    {
                        this._view.SetSelectedInGrid((ActionCode)_actioncodesList[newSelectedIndex]);
                    }
                }
            }
        }

        public void Save()
        {
            UpdateWithViewValues(_selectedObject);
            if (hasErrors(_selectedObject)) return;

            
            if (!this._actioncodesList.Contains(_selectedObject))
            {

                actionCodeService.save(_selectedObject);
                // Add new user
                this._actioncodesList.Add(_selectedObject);
                this._view.AddToGrid(_selectedObject);
            }
            else
            {
                // Update existing
                actionCodeService.save(_selectedObject);
                this._view.UpdateGrid(_selectedObject);
            }
            _view.SetSelectedInGrid(_selectedObject);
            this._view.CanModifyID = false;
        }

        public Boolean hasErrors(ActionCode _selectedObject)
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
            foreach (ActionCode action in this._actioncodesList)
            {
                if (action.Actioncode.CompareTo(actionKey) == 0)
                {
                    _selectedObject = action;

                    // Refresh
                    ActionCodeService actionCodeService = new ActionCodeService();
                    _selectedObject = actionCodeService.getActionCode(_selectedObject.Actioncode);
                    // End Refresh

                    UpdateViewDetailValues(_selectedObject);
                    _view.SetSelectedInGrid(_selectedObject);
                    this._view.CanModifyID = false;
                    break;
                }
            }
        }

        public void UpdateViewDetailValues(ActionCode action)//
        {
            _view.Actioncode = action.Actioncode;
            _view.Description = action.Description;
        }

        public void UpdateWithViewValues(ActionCode action)//
        {
            action.Actioncode = _view.Actioncode;
            action.Description = _view.Description;
        }

        public int getMaxAllPaging()// Count number of records in table
        {
            return actionCodeService.getMaxAllPaging();
        }
        public void getAllPaging(int startPage, int showrecords)
        {

            //actionCodeService.getAllPaging(startPage, showrecords);

        }
        public void create500()
        {
            actionCodeService.create500();
        }
    }
}

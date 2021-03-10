using MSLAManagementSystem.UI.Common;
using MSLAManagementSystem.UI.Interfaces;
using MSLAManagementSystem.UI.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Text;
using MSLAManagementSystem.ClientDataServices.Models;
using MSLAManagementSystem.ClientDataServices.Interfaces;
using System.Windows.Input;

namespace MSLAManagementSystem.UI.ViewModels
{
    public class PersonsPageViewModel : ViewModelBase, IPage
    {
        private IPersonServiceClient personService;
        private PersonModel selectedPerson;
        private bool loadingInProgress;
        private string currentDataOperation;
        private bool isEditMode;
        private PersonModel personToEdit;

        public PersonsPageViewModel(IPersonServiceClient personService)
        {
            this.personService = personService;
            NewPersonCommand = new RelayCommand<object>(ExecuteNewPersonCommand);
            SaveChangesCommand = new RelayCommand<object>(ExecuteSaveChangesCommand);
            CancelCommand = new RelayCommand<object>(ExecuteCancelCommand);
            EditPersonCommand = new RelayCommand<object>(ExecuteEditPersonCommand);
            IsEditMode = false;
            PersonToEdit = null;
        }

        public ICommand NewPersonCommand { get; }
        public ICommand SaveChangesCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand EditPersonCommand { get; }
        public ObservableCollection<PersonModel> Persons { get; private set; } =  new ObservableCollection<PersonModel>();

        public PageKind PageKind => PageKind.Persons;

        public string Caption => Resource.PersonsPageTitle;
        public string CurrentDataOperation
        {
            get { return currentDataOperation; }
            set
            {
                SetProperty(ref currentDataOperation, value);
            }
        }

        public Action CloseWindow { get; set; }

        public PersonModel SelectedPerson
        {
           get { return selectedPerson; }
            set
            {
                SetProperty(ref selectedPerson, value);
            }
        }

        public PersonModel PersonToEdit
        {
            get { return personToEdit; }
            set
            {
                SetProperty(ref personToEdit, value);
            }
        }

        public bool LoadingInProgress
        {
            get { return loadingInProgress; }
            set
            {
                SetProperty(ref loadingInProgress, value);
            }

        }

        public bool IsEditMode
        {
            get { return isEditMode; }
            set
            {
                SetProperty(ref isEditMode, value);
            }
        }

        public bool CanClose()
        {
            return true;
        }

        public async void Refreshe()
        {
            LoadingInProgress = true;
            var list = await personService.GetAll();

            Persons.Clear();
          
            foreach (var item in list)
            {
                Persons.Add(item);
            }

            LoadingInProgress = false;
        }

        #region Commands
        private void ExecuteNewPersonCommand(object obj)
        {
            IsEditMode = true;
            CurrentDataOperation = Resource.AddPersonTitle;
            PersonToEdit = new PersonModel();
        }
        private void ExecuteEditPersonCommand(object obj)
        {
            IsEditMode = true;
            CurrentDataOperation = Resource.EditPesonTitle;
            PersonToEdit = SelectedPerson;
        }

        private void ExecuteCancelCommand(object obj)
        {
            IsEditMode = false;
        }

        private void ExecuteSaveChangesCommand(object obj)
        {
            IsEditMode = false;
            
        }
        #endregion Commands
    }
}

using MSLAManagementSystem.UI.Common;
using MSLAManagementSystem.UI.Interfaces;
using MSLAManagementSystem.UI.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Text;
using MSLAManagementSystem.ClientDataServices.Models;
using MSLAManagementSystem.ClientDataServices.Interfaces;
using System.Windows.Input;
using System.Windows;

namespace MSLAManagementSystem.UI.ViewModels
{
    public class PersonsPageViewModel : ViewModelBase, IPage
    {
        private readonly IPersonServiceClient personService;
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
        }

        public ICommand NewPersonCommand { get; }
        public ICommand SaveChangesCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand EditPersonCommand { get; }
        public ObservableCollection<PersonModel> Persons { get; private set; } = new ObservableCollection<PersonModel>();

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
                OnPropertyChanged(nameof(IsEnableEditUser));
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
                OnPropertyChanged(nameof(IsEnableAddUser));
                OnPropertyChanged(nameof(IsEnableEditUser));
            }
        }

        public bool IsEnableAddUser
        {
            get
            { 
                return IsEditMode == false; 
            }

        }

        public bool IsEnableEditUser
        {
            get
            {
                return SelectedPerson != null && SelectedPerson.Id != 0 && IsEditMode == false;
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

            if (Persons.Count > 0)
                SelectedPerson = Persons.Count > 0 ? Persons[0] : new PersonModel();

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

        private async  void ExecuteSaveChangesCommand(object obj)
        {
            
            try
            {
                var person = await personService.Create(PersonToEdit);
                Persons.Add(person);
                IsEditMode = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion Commands
    }
}

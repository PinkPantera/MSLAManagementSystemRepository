using MSLAManagementSystem.Core.Models;
using MSLAManagementSystem.UI.Common;
using MSLAManagementSystem.UI.Interfaces;
using MSLAManagementSystem.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MSLAManagementSystem.ClientDataServices.Models;
using MSLAManagementSystem.ClientDataServices.Interfaces;

namespace MSLAManagementSystem.UI.ViewModels
{
    public class PersonsPageViewModel : ViewModelBase, IPage
    {
        private IPersonServiceClient personService;
        private PersonModel selectedPerson;
        private bool loadingInProgress;

        public PersonsPageViewModel(IPersonServiceClient personService)
        {
            this.personService = personService;
        }

        public ObservableCollection<PersonModel> Persons { get; private set; } =  new ObservableCollection<PersonModel>();

        public PageKind PageKind => PageKind.Persons;

        public string Caption => Resource.PersonsPageTitle;

        public Action CloseWindow { get; set; }

        public PersonModel SelectedPerson
        {
           get { return selectedPerson; }
            set
            {
                SetProperty(ref selectedPerson, value);
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
    }
}

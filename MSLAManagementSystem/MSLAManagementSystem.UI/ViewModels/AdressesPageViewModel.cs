using MSLAManagementSystem.UI.Common;
using MSLAManagementSystem.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI.ViewModels
{
    public class AdressesPageViewModel : ViewModelBase,IPage
    {
        public PageKind PageKind => PageKind.Adresses;

        public string Caption => Resource.AdressesPageTitle;

        public Action CloseWindow { get; set; }

        public bool CanClose()
        {
            return true;
        }

        public void Refreshe()
        {
           
        }
    }
}

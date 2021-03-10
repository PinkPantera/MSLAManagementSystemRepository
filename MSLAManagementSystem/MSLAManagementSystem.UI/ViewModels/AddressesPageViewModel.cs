using MSLAManagementSystem.UI.Common;
using MSLAManagementSystem.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI.ViewModels
{
    public class AddressesPageViewModel : ViewModelBase,IPage
    {
        public PageKind PageKind => PageKind.Addresses;

        public string Caption => Resource.AddressesPageTitle;

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

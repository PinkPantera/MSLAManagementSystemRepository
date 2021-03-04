using MSLAManagementSystem.UI.Common;
using MSLAManagementSystem.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI.ViewModels
{
    public class MainPageViewModel : IPage
    {
        public PageKind PageKind => PageKind.Main;

        public string Caption => Resource.CurrentDayPageTitle;

        public Action CloseWindow { get ; set; }

        public bool CanClose()
        {
            return true;
        }

        public void Refreshe()
        {
           
        }
    }
}

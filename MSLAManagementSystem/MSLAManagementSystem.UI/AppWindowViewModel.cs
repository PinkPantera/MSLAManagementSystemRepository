using MSLAManagementSystem.UI.Interfaces;
using MSLAManagementSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI
{
    public class AppWindowViewModel : ViewModelBase, ICloseable
    {

        public AppWindowViewModel()
        {
            WindowTitle = "Test";
        }

        public string WindowTitle
        {
            get;set;
            //get { return windowTitle; }
            //private set
            //{ SetProperty(ref windowTitle, value); }
        }

        public Action CloseWindow { get; set; }

        public bool CanClose()
        {
            return true;
        }
    }
}

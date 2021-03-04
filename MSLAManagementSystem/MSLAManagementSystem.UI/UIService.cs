using MSLAManagementSystem.InversionOfControl;
using MSLAManagementSystem.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MSLAManagementSystem.UI
{
    public class UIService : IUIService
    {
        private AppWindowViewModel appWindowViewModel;
        public Window GetAppWindow()
        {
            return new AppWindow
            {
                DataContext = appWindowViewModel
            };
        }

        public void Initialize()
        {
            appWindowViewModel = IoC.Container.Resolve<AppWindowViewModel>();
        }

        public void ShowError(Exception e)
        {

        }

        public bool? ShowMessageBox(string message, string caption = null)
        {
            throw new NotImplementedException();
        }
    }
}

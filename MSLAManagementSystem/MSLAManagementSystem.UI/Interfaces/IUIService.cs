using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MSLAManagementSystem.UI.Interfaces
{
    public interface IUIService
    {
        Window GetAppWindow();
        void Initialize();
        bool? ShowMessageBox(string message, string caption = null);

        void ShowError(Exception e);
    }
}

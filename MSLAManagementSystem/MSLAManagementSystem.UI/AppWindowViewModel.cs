using MSLAManagementSystem.UI.Common;
using MSLAManagementSystem.UI.Extensions;
using MSLAManagementSystem.UI.Interfaces;
using MSLAManagementSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MSLAManagementSystem.UI
{
    public class AppWindowViewModel : ViewModelBase, ICloseable
    {
        private IPage selectedPage;
        private IPageProvider pageProvider;

        public AppWindowViewModel(IPageProvider pageProvider)
        {
            WindowTitle = Resource.WindowTitle;
            MenuCommand = new RelayCommand<object>(ExecuteMenuCommand);
            ExitCommand = new RelayCommand<object>(ExecuteExitCommand);
            this.pageProvider = pageProvider;
        }

        public ICommand MenuCommand { get; }
        public ICommand ExitCommand { get; }

        public string WindowTitle
        {
            get; set;
            //get { return windowTitle; }
            //private set
            //{ SetProperty(ref windowTitle, value); }
        }

        public IPage SelectedPage
        {
            get { return selectedPage; }
            set { SetProperty(ref selectedPage, value); }
        }

        public Action CloseWindow { get; set; }

        public bool CanClose()
        {
            return true;
        }

        #region Commands
        private void ExecuteMenuCommand(object obj)
        {
            if (obj == null)
                return;

            PageKind pageKind = obj.ToString().ConvertToPageKind();

            if (pageKind != PageKind.Unknown)
            {
                SelectedPage = pageProvider.GetPage(pageKind);
                SelectedPage.Refreshe();
            }

           // TopTitle = SelectedPage.Caption;
        }

        private void ExecuteExitCommand(object obj)
        {
            CloseWindow?.Invoke();
        }
        #endregion Commands
    }
}

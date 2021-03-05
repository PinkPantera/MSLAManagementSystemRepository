using MSLAManagementSystem.InversionOfControl;
using MSLAManagementSystem.UI.Common;
using MSLAManagementSystem.UI.Interfaces;
using MSLAManagementSystem.UI.Providers;
using MSLAManagementSystem.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.UI
{
    public static class Bootstrapper
    {
        public static void Initialize(DependencyContainer container)
        {
            container.Register<IUIService, UIService>(Lifetime.Singleton);

            //register pages 
            container.Register<IPage, MainPageViewModel>(PageKind.Main.ToString(), Lifetime.Singleton);
            container.Register<IPage, PersonsPageViewModel>(PageKind.Persons.ToString(), Lifetime.Singleton);
            container.Register<IPage, AdressesPageViewModel>(PageKind.Adresses.ToString(), Lifetime.Singleton);

            container.Register<IPageProvider, PageProvider>(Lifetime.Singleton);
        }
    }
}

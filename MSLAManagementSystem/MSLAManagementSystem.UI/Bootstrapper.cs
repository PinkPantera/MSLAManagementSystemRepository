using MSLAManagementSystem.InversionOfControl;
using MSLAManagementSystem.UI.Interfaces;
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
        }
    }
}

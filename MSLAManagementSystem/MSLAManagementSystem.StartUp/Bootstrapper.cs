using MSLAManagementSystem.InversionOfControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.StartUp
{
    public static class Bootstrapper
    {
        public static void Initialize(DependencyContainer container)
        {
           UI.Bootstrapper.Initialize(container);
        }
    }
}

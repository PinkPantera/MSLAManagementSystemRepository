using MSLAManagementSystem.ClientDataServices.Interfaces;
using MSLAManagementSystem.ClientDataServices.ServicesClient;
using MSLAManagementSystem.InversionOfControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSLAManagementSystem.ClientDataServices
{
    public static class Bootstrapper
    {
        public static void Initialize(DependencyContainer container)
        {
            container.Register<IAdressServiceClient, AdressServiceClient>(Lifetime.Singleton);
            container.Register<IPersonServiceClient, PersonServiceClient>(Lifetime.Singleton);
        }
    }
}

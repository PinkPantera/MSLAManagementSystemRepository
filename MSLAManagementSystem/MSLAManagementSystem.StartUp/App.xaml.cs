using MSLAManagementSystem.InversionOfControl;
using MSLAManagementSystem.UI;
using MSLAManagementSystem.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MSLAManagementSystem.StartUp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private volatile bool disposed;
        private static readonly string WaitHandleName = "MSLAManagementSystem" + Environment.UserName;
        private static EventWaitHandle waitHandle;

        public App()
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Bootstrapper.Initialize(IoC.Container);
        }

        private IUIService UIService { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool created;
            waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, WaitHandleName, out created);

            if (created)
            {
                UIService = IoC.Container.Resolve<IUIService>();
                UIService.Initialize();

                var mainWindow = UIService.GetAppWindow();
                mainWindow.Closed += (sender, e) =>
                {
                    Current.Shutdown();
                };
                mainWindow.Show();
            }
            else
            {
                try
                {
                    waitHandle = EventWaitHandle.OpenExisting(WaitHandleName);
                    waitHandle.Set();
                }
                finally
                {
                    Shutdown();
                }
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (!disposed)
            {
                disposed = true;
            }

            if (!disposed)
            {
                disposed = true;
                waitHandle.Dispose();
            }

            if (e.ApplicationExitCode == ExceptionHandler.NotResolvedCriticalFailureCode)
            {
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}

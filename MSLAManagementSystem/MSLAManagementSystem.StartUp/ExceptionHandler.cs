using MSLAManagementSystem.InversionOfControl;
using MSLAManagementSystem.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MSLAManagementSystem.StartUp
{
    public static class ExceptionHandler
    {
        // Need explicit resolving from IoC in order to get instances as early as possible
        // private static ILogger Logger => IoC.Container.Resolve<ILogger>();
        private static IUIService UIService => IoC.Container.Resolve<IUIService>();

        public const int NotResolvedCriticalFailureCode = 1;

        public static void Init()
        {
            Application.Current.DispatcherUnhandledException += Application_UnhandledException;
            AppDomain.CurrentDomain.UnhandledException += AppCrashException;
            TaskScheduler.UnobservedTaskException += Task_UnhandledException;
        }

        // Will handle non critical exception for Tasks
        private static void Task_UnhandledException(object sender, UnobservedTaskExceptionEventArgs eventArgs)
        {
            ShowAppError(eventArgs.Exception);
        }

        // Will close application, but allow to write logs
        private static void AppCrashException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            //Logger?.LogFatalError(exception);
        }

        // Will handle non critical exception for application
        private static void Application_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //TODO define critical errors
            e.Handled = true;
            ShowAppError(e.Exception);
        }

        private static void ShowAppError(Exception e)
        {
            var shouldShutDown = System.Windows.Application.Current.MainWindow == null;
            //Logger?.LogError(e);
            UIService?.ShowError(e);
            if (shouldShutDown)
            {
                //Logger?.LogFatalError(e);
                Application.Current.Shutdown(NotResolvedCriticalFailureCode);
            }
        }
    }
}

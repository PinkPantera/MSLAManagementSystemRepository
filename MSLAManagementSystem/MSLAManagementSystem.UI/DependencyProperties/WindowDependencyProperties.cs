using MSLAManagementSystem.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MSLAManagementSystem.UI.DependencyProperties
{
    public class WindowProperties
    {
        public static readonly DependencyProperty EnableWindowClosingProperty =
    DependencyProperty.RegisterAttached("EnableWindowClosing", typeof(bool), typeof(WindowProperties), new PropertyMetadata(false, OnEnableWindowClosingChanged));

        public static void SetEnableWindowClosing(DependencyObject dependencyObject, bool enableWindowClosing)
        {
            dependencyObject.SetValue(EnableWindowClosingProperty, enableWindowClosing);
        }

        public static bool GetEnableWindowClosing(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(EnableWindowClosingProperty);
        }

        private static void OnEnableWindowClosingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Window window)
            {
                window.Loaded += (s, e) =>
                {
                    if (window.DataContext is ICloseable viewModel)
                    {
                        viewModel.CloseWindow += () =>
                        {
                            window.Close();
                        };
                        window.Closing += (s, e) =>
                        {
                            e.Cancel = !viewModel.CanClose();

                            if (e.Cancel)
                            {
                                MessageBox.Show("Can't close application");
                            }
                        };
                    }
                };
            }
        }
    }
}

using System;
using System.Windows;
using System.Windows.Threading;

namespace Watermarker.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            DispatcherUnhandledException += (object sender, DispatcherUnhandledExceptionEventArgs args) =>
            {
                Exception ex = args.Exception;

                MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}", ex.GetType().FullName);

                args.Handled = true;
            };
        }
    }
}

using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Watermarker.Config;
using Watermarker.GUI.ViewModels;
using Watermarker.Jobs;

namespace Watermarker.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WatermarkSettings wmSettings = new WatermarkSettings();
            WatermarkDrawer drawer = new WatermarkDrawer();

            WatermarkSettingsViewModel viewModel = new WatermarkSettingsViewModel(drawer, wmSettings);
            DataContext = viewModel;
        }

        private void ValidateNumericTextBoxes(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]{1,3}$");
        }
    }
}

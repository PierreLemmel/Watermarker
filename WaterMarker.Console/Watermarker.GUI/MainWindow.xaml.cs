using System;
using System.Windows;
using System.Windows.Input;
using Watermarker.Config;
using Watermarker.GUI.ViewModels;
using Watermarker.Jobs;
using Watermarker.Serialization;

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

            SettingsSerializer settingsSerializer = new SettingsSerializer();
            WatermarkSettings wmSettings = settingsSerializer.RestoreSettings() ?? new WatermarkSettings();
            WatermarkDrawer drawer = new WatermarkDrawer();

            WatermarkSettingsViewModel viewModel = new WatermarkSettingsViewModel(drawer, wmSettings);
            DataContext = viewModel;

            Closing += (sender, ea) => settingsSerializer.SaveSettings(wmSettings);
        }

        private void ValidateNumericTextBoxes(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !float.TryParse(e.Text, out _);
        }
    }
}
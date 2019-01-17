using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using Watermarker.Config;
using Watermarker.GUI.Commands;
using Watermarker.Jobs;

namespace Watermarker.GUI.ViewModels
{
    public class WatermarkSettingsViewModel : INotifyPropertyChanged
    {
        private WatermarkSettings Model { get; }
        private WatermarkDrawer Drawer { get; }

        public WatermarkSettingsViewModel(WatermarkDrawer drawer, WatermarkSettings model)
        {
            Drawer = drawer ?? throw new ArgumentNullException(nameof(drawer));
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public bool EraseFile
        {
            get { return Model.EraseFile; }
            set
            {
                if (value != EraseFile)
                {
                    Model.EraseFile = value;
                    RaisesPropertyChanged(nameof(EraseFile));
                }
            }
        }

        public string TransformedFileSuffix
        {
            get { return Model.TransformedFileSuffix; }
            set
            {
                if (value != TransformedFileSuffix)
                {
                    Model.TransformedFileSuffix = value;
                    RaisesPropertyChanged(nameof(TransformedFileSuffix));
                }
            }
        }

        public Anchor Anchor
        {
            get { return Model.Anchor; }
            set
            {
                if (value != Anchor)
                {
                    Model.Anchor = value;
                    RaisesPropertyChanged(nameof(Anchor));
                }
            }
        }

        public string Text
        {
            get { return Model.Text; }
            set
            {
                if (value != Text)
                {
                    Model.Text = value;
                    RaisesPropertyChanged(nameof(Text));
                }
            }
        }

        public Color Color
        {
            get { return Model.Color; }
            set
            {
                if (value != Color)
                {
                    Model.Color = value;
                    RaisesPropertyChanged(nameof(Color));
                }
            }
        }

        public int HMargin
        {
            get { return Model.HMargin; }
            set
            {
                if (value != HMargin)
                {
                    Model.HMargin = value;
                    RaisesPropertyChanged(nameof(HMargin));
                }
            }
        }

        public int VMargin
        {
            get { return Model.VMargin; }
            set
            {
                if (value != VMargin)
                {
                    Model.VMargin = value;
                    RaisesPropertyChanged(nameof(VMargin));
                }
            }
        }

        public ICommand DrawWatermarks => new Command<WatermarkSettingsViewModel>(
            () =>
            {
                using (CommonOpenFileDialog dialog = new CommonOpenFileDialog()
                    {
                        IsFolderPicker = true,
                        EnsurePathExists = true
                    })
                {
                    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        string directory = dialog.FileName;
                        IEnumerable<string> files = Directory.GetFiles(directory, "*.png, *.jpg, *.jpeg");

                        foreach (string file in files) Console.WriteLine(file);
                    }
                }
            });

        private void RaisesPropertyChanged(string propertyName)
            => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

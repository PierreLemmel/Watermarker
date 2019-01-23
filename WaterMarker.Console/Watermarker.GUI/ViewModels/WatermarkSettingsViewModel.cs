using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public bool EraseFiles
        {
            get { return Model.EraseFiles; }
            set
            {
                if (value != EraseFiles)
                {
                    Model.EraseFiles = value;
                    RaisesPropertyChanged(nameof(EraseFiles));
                }
            }
        }

        public bool IncludeSubFolders
        {
            get { return Model.IncludeSubFolders; }
            set
            {
                if (value != IncludeSubFolders)
                {
                    Model.IncludeSubFolders = value;
                    RaisesPropertyChanged(nameof(IncludeSubFolders));
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

        public string FontName
        {
            get { return Model.FontName; }
            set
            {
                if (value != FontName)
                {
                    Model.FontName = value;
                    RaisesPropertyChanged(nameof(FontName));
                }
            }
        }

        public FontType FontType
        {
            get { return Model.FontType; }
            set
            {
                if (value != FontType)
                {
                    Model.FontType = value;
                    RaisesPropertyChanged(nameof(FontType));
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

        public float HMargin
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

        public float VMargin
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

        public float TextSize
        {
            get { return Model.TextSize; }
            set
            {
                if (value != TextSize)
                {
                    Model.TextSize = value;
                    RaisesPropertyChanged(nameof(TextSize));
                }
            }
        }

        public TextOrientation TextOrientation
        {
            get { return Model.TextOrientation; }
            set
            {
                if (value != TextOrientation)
                {
                    Model.TextOrientation = value;
                    RaisesPropertyChanged(nameof(TextOrientation));
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
                        string dirPath = dialog.FileName + "\\";

                        SearchOption searchOption = IncludeSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                        IReadOnlyCollection<string> files = Directory
                            .EnumerateFiles(dirPath, "*", searchOption)
                            .Where(file => file.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase)
                                        || file.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase)
                                        || file.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase))
                            .ToList();

                        Drawer.Draw(files, Model);
                    }
                }
            });

        private void RaisesPropertyChanged(string propertyName)
            => PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
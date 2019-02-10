using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileClusterRenamer.ViewModel;
using System.ComponentModel;

namespace FileClusterRenamer.View
{
    /// <summary>
    /// Interaction logic for FileClusterView.xaml
    /// </summary>
    public partial class FileClusterView : UserControl
    {
        public FileClusterView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog() { IsFolderPicker = true, InitialDirectory = @"C:\Users" };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtFolderPath.Text = dialog.FileName;
                // Todo fill out list of files here.
            }
        }

        private void DoButton_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder
        }
    }

    
    
}
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
        public string SelectedFolderPath
        {
            get { return (string)GetValue(SelectedFolderPathProperty); }
            set { SetValue(SelectedFolderPathProperty, value); }
        }

        public static readonly DependencyProperty SelectedFolderPathProperty =
            DependencyProperty.Register("SelectedPath", typeof(string), typeof(FileClusterView), 
                new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectedFolderPathChanged))
            {
                BindsTwoWayByDefault = true,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

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
                
            }
        }

        private static void SelectedFolderPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FileClusterView)d).txtFolderPath.Text = e.NewValue.ToString();

            MessageBox.Show("Changed!");
        }

        private void DoButton_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder
        }


        //public partial class PathSelector : UserControl
        //{

        //    private static void SelectedPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //    {
        //        MessageBox.Show("Changed!");
        //        // How to update the values here??
        //    }



        //    private void SelectedPathTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //    {
        //        SelectedPath = SelectedPathTxtBox.Text;
        //    }
        //}

    }
}
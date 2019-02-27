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

        //private static void SelectedFolderPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    ((FileClusterView)d).txtFolderPath.Text = e.NewValue.ToString();

        //    MessageBox.Show("Changed!");
        //}

        private void DoButton_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder
        }
    }
}
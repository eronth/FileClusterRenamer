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
            var fileBrowser = new System.Windows.Forms.FolderBrowserDialog();
            //fileBrowser.CheckFileExists;
            //fileBrowser.CheckPathExists;
            //fileBrowser.ReadOnlyChecked;
            //multiselect

            if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string FolderToOpen = fileBrowser.RootFolder.ToString();

                //MessageBox.Show(FolderToOpen, "test caption please ignore");
                ////OR

                ////System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                ////etc
                ///
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = "C:\\Users";
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    MessageBox.Show("You selected: " + dialog.FileName);
                }
            }
        }

    }
}

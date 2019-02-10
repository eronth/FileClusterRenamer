using FileClusterRenamer.ViewModel;
using System.Windows;

namespace FileClusterRenamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FileClusterRenamerViewModel();
        }

        private void FileClusterViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            FileClusterRenamerViewModel fileClusterRenamerViewModelObject = new FileClusterRenamerViewModel();
            fileClusterRenamerViewModelObject.LoadFileCluster();

            FileClusterViewControl.DataContext = fileClusterRenamerViewModelObject;
        }
    }
}

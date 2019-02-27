using System;
using System.Collections.Generic;
using FileClusterRenamer.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FileClusterRenamer.ViewModel
{
    class FileClusterRenamerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public System.Windows.Input.ICommand BrowseClick { get; }
        public System.Windows.Input.ICommand ApplyClick { get; }
        public FileClusterRenamerViewModel()
        {
            BrowseClick = new DelegateCommand(BrowseFolderAction);
            ApplyClick = new DelegateCommand(ApplyChangesAction);
        }

        private void BrowseFolderAction()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog() { IsFolderPicker = true, InitialDirectory = @"C:\Users" };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Folder = dialog.FileName;
            }
        }

        private void ApplyChangesAction()
        {
            String printoutlist = string.Empty;
            foreach (FileNode file in FileCluster )
            {
                if (file.IsSelected)
                {
                    File.Move(file.InitialFilePath, file.FilePath);
                    printoutlist += file.InitialFilePath + "\n"
                        + file.FilePath + "\n";
                }
            }
            MessageBox.Show(printoutlist);
        }
        public OptionControls _options { get; set; } = new OptionControls();
        public OptionControls Options
        {
            get { return _options; }
            set
            {
                _options = value;
                RaisePropertyChangedEvent("Options");
            }
        }

        public FolderAccess FolderAccessItem { get; set; } = new FolderAccess();
        public string Folder
        {
            get { return FolderAccessItem.FolderLocation; }
            set
            {
                FolderAccessItem.FolderLocation = value;
                RaisePropertyChangedEvent("Folder");

                // TODO  Validate folder path.
                RepopulateFileList();
            }
        }

        public ObservableCollection<FileNode> _fileCluster = new ObservableCollection<FileNode>();
        public ObservableCollection<FileNode> FileCluster
        {
            get { return _fileCluster; }
            set
            {
                _fileCluster = value;
                RaisePropertyChangedEvent("FileCluster");
            }
        }

        public void LoadFileCluster()
        {
            Folder = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            FileCluster = new ObservableCollection<FileNode>();
            RepopulateFileList();
        }

        private void RepopulateFileList()
        {
            // Clear old list.
            FileCluster.Clear();
            // TODO error handling.
            DirectoryInfo di = new DirectoryInfo(Folder);
            FileInfo[] Files = di.GetFiles("*");

            // TODO handle filtering.

            foreach (FileInfo file in Files)
            {
                FileCluster.Add(
                new FileNode
                {
                    IsSelected = false,
                    FileName = Path.GetFileNameWithoutExtension(file.Name),
                    FileLocation = file.DirectoryName,
                    FileExtension = file.Extension,
                    InitialFilePath = file.FullName
                });
            }
        }
    }
}

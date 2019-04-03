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

        /// <summary>
        /// Action to perform when the Browse button is clicked.
        /// </summary>
        private void BrowseFolderAction()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog() { IsFolderPicker = true, InitialDirectory = @"C:\Users" };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Folder = dialog.FileName;
            }
        }

        /// <summary>
        /// Action to perform when hitting apply. Will update all checked items.
        /// </summary>
        private void ApplyChangesAction()
        {
            String printoutlist = string.Empty;
            foreach (FileNode file in FileCluster )
            {
                if (file.IsSelected)
                {
                    // Using options, remove from the start and end of name.
                    file.FileName = file.FileName.Remove(0, Options.IsRemoveStart ? Options.RemoveStartAmount : 0);
                    if (Options.IsRemoveEnd && (Options.RemoveEndAmount > 0))
                    {
                        file.FileName = file.FileName
                            .Remove(file.FileName.Length -  Options.RemoveEndAmount);
                    }

                    // Only bother to actually perform a move if the filepath is different.
                    if (!file.InitialFilePath.Equals(file.FilePath))
                    {
                        File.Move(file.InitialFilePath, file.FilePath);
                    }

                    // TODO remove this debugging stuff.
                    printoutlist += file.InitialFilePath + "\n"
                        + file.FilePath + "\n";

                    file.InitialFilePath = file.FilePath;

                }
            }
            RepopulateFileList();
            // Todo remove this debugging stuff.
            //MessageBox.Show(printoutlist);
        }


        public OptionControls _options { get; set; } = new OptionControls();
        public OptionControls Options
        {
            get { return _options; }
            set
            {
                _options = value;
                RaisePropertyChangedEvent("Options");
                MessageBox.Show("Changed.");
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
            Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

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

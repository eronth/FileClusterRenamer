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

namespace FileClusterRenamer.ViewModel
{
    class FileClusterRenamerViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                // FileCluster.Clear();

                // TODO Pull in files from the selected folder.

                // TODO handle filtering.
                //FileCluster.Add(new FileNode { IsSelected = true, FileName = "brash", FileLocation = $"C:\\Slut", FileExtension = "png" });
                //FileCluster.Add(new FileNode { IsSelected = true, FileName = "crash", FileLocation = $"C:\\Slut", FileExtension = "png" });
                //FileCluster.Add(new FileNode { IsSelected = true, FileName = "prash", FileLocation = $"C:\\Slut", FileExtension = "png" });
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

            foreach (FileInfo file in Files)
            {
                FileCluster.Add(
                new FileNode
                {
                    IsSelected = true,
                    FileName = Path.GetFileNameWithoutExtension(file.Name),
                    FileLocation = file.DirectoryName,
                    FileExtension = file.Extension
                });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FileClusterRenamer.Model
{
    public class FileClusterRenamerModel { }

    public class FileCluster : INotifyPropertyChanged
    {
        private string fileLocation;
        public string FileLocation
        {
            get
            {
                return fileLocation;
            }
            set
            {
                if (fileLocation != value)
                {
                    fileLocation = value;
                    RaisePropertyChanged("FileLocation");
                    RaisePropertyChanged("FilePath");
                }
            }
        }
        
        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                if (fileName != value)
                {
                    fileName = value;
                    RaisePropertyChanged("FileName");
                    RaisePropertyChanged("FilePath");
                }
            }
        }

        private string fileExtension;
        public string FileExtension
        {
            get
            {
                return fileExtension;
            }
            set
            {
                if (fileExtension != value)
                {
                    fileExtension = value;
                    RaisePropertyChanged("FileExtension");
                    RaisePropertyChanged("FilePath");
                }
            }
        }

        public string FilePath
        {
            get
            {
                return $@"{fileLocation}\{fileName}.{fileExtension}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}

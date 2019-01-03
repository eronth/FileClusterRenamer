using System;
using System.Collections.Generic;
using FileClusterRenamer.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileClusterRenamer.ViewModel
{
    class FileClusterRenamerViewModel
    {
        public ObservableCollection<FileCluster> FileClusters { get; set; }

        public void LoadFileCluster()
        {
            FileClusters  = new ObservableCollection<FileCluster>
            {
                new FileCluster { FileName = "ash", FileLocation = $"C:\\Slut", FileExtension = "png" },
                new FileCluster { FileName = "rash", FileLocation = $"C:\\Slut", FileExtension = "png" },
                new FileCluster { FileName = "trash", FileLocation = $"C:\\Slut", FileExtension = "png" }
            };
        }
    }
}

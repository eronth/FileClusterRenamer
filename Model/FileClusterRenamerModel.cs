using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace FileClusterRenamer.Model
{
    public class FileClusterRenamerModel
    {
        
    }

    public class OptionControls
    {
        public bool IsRemoveStart { get; set; }
        public int RemoveStartAmount { get; set; }
        public bool IsRemoveEnd { get; set; }
        public int RemoveEndAmount { get; set; }
    }

    public class FolderAccess
    {
        public string FolderLocation { get; set; }
    }

    public class FileNode
    {
        public string InitialFilePath { get; set; }

        public string FileLocation { get; set; }
       
        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public bool IsSelected { get; set; }

        public string FilePath
        {
            get
            {
                return IsSelected?$@"{FileLocation}\{FileName}{FileExtension}":string.Empty;
            }
        }
    }

}

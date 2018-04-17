using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLReader
{
    static class FileDialog
    {
        public static string ReturnPath ()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml;*.XML)|*.xml;*.XML";
            if (openFileDialog.ShowDialog() == true)
                File.ReadAllText(openFileDialog.FileName);
            string _path = openFileDialog.FileName.ToString();

            return _path;
        }
    }
}

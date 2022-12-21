using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsqueciMe.UWP {
    class FileAccesHelper {
        public static string GetLocalFilePathWindows(string filename)
        {
            string path = global::Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return System.IO.Path.Combine(path, filename);

        }
    }
}

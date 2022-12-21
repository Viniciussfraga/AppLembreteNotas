using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsqueciMe.Droid {
    class FileAccesHelper {

        public static string GetLocalFilePathIOS(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");
            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }
            return System.IO.Path.Combine(libFolder, filename);
        }
    }
}
}
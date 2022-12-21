using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsqueciMe.Droid {
    class FileAccesHelper {
        public static string GetLocalFilePathAndroid(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);

        }
    }
}
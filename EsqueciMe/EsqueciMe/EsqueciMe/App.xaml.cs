using EsqueciMe.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsqueciMe {
    public partial class App : Application {
        public static string DbName;
        public static string DbPath;
        public App()
        {
            InitializeComponent();

            MainPage = new PagePrincipal();
        }

        public App(string path, string dbName)
        {
            InitializeComponent();
            App.DbName = dbName;
            App.DbPath = path;
            MainPage = new PagePrincipal();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

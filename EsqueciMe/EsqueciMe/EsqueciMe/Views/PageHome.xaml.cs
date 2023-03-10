using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsqueciMe.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHome : ContentPage {
        public PageHome()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //img inserir
            FlyoutPage p = Application.Current.MainPage as FlyoutPage;
            p.Detail = new NavigationPage(new PageCadastrar());
            p.IsPresented = false;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //img localizar
            FlyoutPage p = Application.Current.MainPage as FlyoutPage;
            p.Detail = new NavigationPage(new PageListar());
            p.IsPresented = false;
        }

    }
}
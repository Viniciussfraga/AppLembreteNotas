using EsqueciMe.Models;
using EsqueciMe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsqueciMe.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage {
        public PageListar()
        {
            InitializeComponent();
            AtualizaLista();
        }
        public void AtualizaLista()
        {
            ServicesDBNotas dBNotas = new ServicesDBNotas(App.DbPath);
            

            if (swFavorito.IsToggled)
            {
                ListaNotas.ItemsSource = dBNotas.ListarFavoritos();
            }
            else
            {
                ListaNotas.ItemsSource = dBNotas.ListarNotas();
            }
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelNotas nota = ListaNotas.SelectedItem as ModelNotas;
            //Chamada da page cadastrar
            FlyoutPage p = Application.Current.MainPage as FlyoutPage;
            p.Detail = new NavigationPage(new PageCadastrar(nota));
        }

        private void swFavorito_Toggled(object sender, ToggledEventArgs e)
        {
            AtualizaLista();
        }
    }
}
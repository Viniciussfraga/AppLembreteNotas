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
        public void InserirItens()
        {
          
            ModelNotas nota = new ModelNotas();
            nota.Titulo = "Teste: " + DateTime.Now.ToString();
            nota.Dados = "Será que funciona de primeira?";
            nota.Favorito = false;

            ServicesDBNotas dBNotas = new ServicesDBNotas(App.DbPath);
            dBNotas.Inserir(nota);
            DisplayAlert("Resultado da operação: ", dBNotas.StatusMessage, "OK");
        }

        public void AtualizaLista()
        {
            ServicesDBNotas dBNotas = new ServicesDBNotas(App.DbPath);
            ListaNotas.ItemsSource = dBNotas.ListarNotas();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            InserirItens();
            AtualizaLista();
        }
    }
}
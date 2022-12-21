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
    public partial class PageCadastrar : ContentPage {
        public PageCadastrar()
        {
            InitializeComponent();
        }
        public PageCadastrar(ModelNotas nota)
        {
            InitializeComponent();
            btSalvar.Text = "Alterar";
            entryCodigo.IsVisible = true;

            entryCodigo.Text = nota.Id.ToString();
            entryTitulo.Text = nota.Titulo;
            editorDados.Text = nota.Dados;
            swFavorito.IsToggled = nota.Favorito;
        }
        private void btSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelNotas nota = new ModelNotas();
                nota.Titulo = entryTitulo.Text;
                nota.Dados = editorDados.Text;
                nota.Favorito = swFavorito.IsToggled;

                ServicesDBNotas dBNotas = new ServicesDBNotas(App.DbPath);

                if (btSalvar.Text == "Inserir")
                {
                    dBNotas.Inserir(nota);
                    DisplayAlert("Resultado da operação: ", dBNotas.StatusMessage, "OK");
                }
                else
                {

                }
                FlyoutPage p = Application.Current.MainPage as FlyoutPage;
                p.Detail = new PageHome();
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro: ", ex.Message, "OK");
            }
            
        }
        private void btCancelar_Clicked(object sender, EventArgs e)
        {
            FlyoutPage p = Application.Current.MainPage as FlyoutPage;
            p.Detail = new PageHome();
        }
    }
}
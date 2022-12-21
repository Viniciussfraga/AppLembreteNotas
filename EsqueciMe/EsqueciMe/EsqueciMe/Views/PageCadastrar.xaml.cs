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
        #region Construtores
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
            btExcluir.IsVisible = true;
        }
        #endregion

        #region Métodos
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
                    nota.Id = Convert.ToInt32(entryCodigo.Text);
                    dBNotas.Alterar(nota);
                    DisplayAlert("Resultado da operação", dBNotas.StatusMessage, "OK");
                }
                FlyoutPage p = Application.Current.MainPage as FlyoutPage;
                p.Detail = new NavigationPage(new PageHome());
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro: ", ex.Message, "OK");
            }
            
        }
        private void btCancelar_Clicked(object sender, EventArgs e)
        {
            FlyoutPage p = Application.Current.MainPage as FlyoutPage;
            p.Detail = new NavigationPage(new PageHome());
        }

        private async void btExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir Registro", "Deseja excluir a nota atual?", "Sim", "Não");
            if (resp)
            {
                ServicesDBNotas dBNotas = new ServicesDBNotas(App.DbPath);
                int id = Convert.ToInt32(entryCodigo.Text);
                dBNotas.Excluir(id);
                await DisplayAlert("Resultado da operação", dBNotas.StatusMessage, "OK");
                FlyoutPage p = Application.Current.MainPage as FlyoutPage;
                p.Detail = new NavigationPage(new PageHome());
            }
        }
        #endregion
    }
}
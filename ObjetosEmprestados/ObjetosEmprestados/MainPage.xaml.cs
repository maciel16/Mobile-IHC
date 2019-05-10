using System.Collections.Generic;
using Xamarin.Forms;

using ObjetosEmprestados.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using ObjetosEmprestados.Views;
using ObjetosEmprestados.Services;

namespace ObjetosEmprestados
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<ObjetoEmprestado> objetosEmprestados;

        public MainPage()
        {
            InitializeComponent();

            /*
            objetosEmprestados = GetTodosObjetosEmprestados();
            ObjetoListView.ItemsSource = objetosEmprestados;
            */
        }

        protected override void OnAppearing()
        {

            objetosEmprestados = GetTodosObjetosEmprestados();
            ObjetoListView.ItemsSource = objetosEmprestados;
            base.OnAppearing();
        }


        public ObservableCollection<ObjetoEmprestado> GetTodosObjetosEmprestados()
        {
            /*
            return new ObservableCollection<ObjetoEmprestado>()
            {
                new ObjetoEmprestado(){
                    Descricao ="Livro Game AI Pro",
                    Nome ="Marcio",
                    Data = DateTime.Now
                },
                new ObjetoEmprestado(){
                    Descricao ="Celular para capturar Pokemon",
                    Nome ="Eduardo",
                    Data = new DateTime(2019,03,29)
                },
                new ObjetoEmprestado(){
                    Descricao ="Book 1",
                    Nome ="Pedro",
                    Data = new DateTime(2019,02,01)
                }
            };
            */

            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            return new ObservableCollection<ObjetoEmprestado>(dao.GetTodos());

        }

        private void OnObjetoProcurado(object sender, TextChangedEventArgs e)
        {
            string texto = ObjetoSearchBar.Text;
            ObjetoListView.ItemsSource = objetosEmprestados.Where(
                x => x.Descricao.ToLowerInvariant().Contains(texto.ToLowerInvariant())
                );
        }

        private void OnObjetoSelecionado(object sender, SelectedItemChangedEventArgs e)
        {
            //var objetoEmprestado = e.SelectedItem as ObjetoEmprestado;
            ObjetoEmprestado objetoEmprestado = e.SelectedItem as ObjetoEmprestado;
            Navigation.PushAsync(page: new EditObjectPage(objetoEmprestado));
            
        }

        private void OnAdicionarObjetoEmprestado(object sender, EventArgs e)
        {
            Navigation.PushAsync(page: new EditObjectPage(null));
        }
    }
}

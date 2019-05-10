using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetosEmprestados.Models;
using ObjetosEmprestados.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObjetosEmprestados.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditObjectPage : ContentPage
	{
        private ObjetoEmprestado objetoEmprestado;

        public EditObjectPage (ObjetoEmprestado objetoEmpretado)
		{
			InitializeComponent ();

            
            if (objetoEmpretado != null) //editar e excluir
            {
                this.objetoEmprestado = objetoEmpretado;
                DescricaoEntry.Text = objetoEmpretado.Descricao;
                NomeEntry.Text = objetoEmpretado.Nome;
                DataDatePicker.Date = objetoEmpretado.Data;
                Title = "Editar Objeto Emprestado";
                SalvarButton.IsVisible = false;
                AtualizarButton.IsVisible = true;
                ExcluirButton.IsVisible = true;
            }
            else //novo objeto, so editar
            {
                DataDatePicker.Date = DateTime.Now;
                Title = "Novo Objeto Emprestado";
            }
                        
            /*
            DescricaoEntry.Text = objetoEmpretado.Descricao;
            NomeEntry.Text = objetoEmpretado.Nome;
            DataEntry.Text = objetoEmpretado.Data.ToString("dd/MM/yy");
            */
        }

        private void OnSalvar(object sender, EventArgs e)
        {
            //cria objeto e guarda as informacoes que vem
            ObjetoEmprestado objeto = new ObjetoEmprestado();
            objeto.Descricao = DescricaoEntry.Text;
            objeto.Nome = NomeEntry.Text;
            objeto.Data = DataDatePicker.Date;
            //enviados para o banco de dados (salvar)

            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.Inserir(objeto);

            Navigation.PopAsync(); //fechar a tela
        }

        private void OnAtualizar(object sender, EventArgs e)
        {
            //atualiza as informacoes
            objetoEmprestado.Descricao = DescricaoEntry.Text;
            objetoEmprestado.Nome = NomeEntry.Text;
            objetoEmprestado.Data = DataDatePicker.Date;

            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.Atualizar(objetoEmprestado);

            Navigation.PopAsync();
        }

        private void OnExcluir(object sender, EventArgs e)
        {
            //excluir as informacoes
            ObjetoEmprestadoDAO dao = new ObjetoEmprestadoDAO();
            dao.ExcluirPorId(objetoEmprestado.Id);

            Navigation.PopAsync();
        }
    }
}
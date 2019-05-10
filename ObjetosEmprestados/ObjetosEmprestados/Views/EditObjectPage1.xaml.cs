using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetosEmprestados.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObjetosEmprestados.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditObjectPage1 : ContentPage
	{

        public EditObjectPage1 (ObjetoEmprestado objetoEmpretado)
		{
			InitializeComponent ();

            DescricaoEntry.Text = objetoEmpretado.Descricao;
            NomeEntry.Text = objetoEmpretado.Nome;
            DataEntry.Text = objetoEmpretado.Data.ToString("dd/MM/yy");
        }

    }
}
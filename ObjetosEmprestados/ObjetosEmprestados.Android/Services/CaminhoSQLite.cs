using System;
using System.IO;
using ObjetosEmprestados.Droid.Services;
using ObjetosEmprestados.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CaminhoSQLite))]
namespace ObjetosEmprestados.Droid.Services
{

    public class CaminhoSQLite : ICaminhoSQLite
    {
        public string GetCaminhoDB(string nomeDB)
        {
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(caminho, nomeDB);
        }
    }

    
}
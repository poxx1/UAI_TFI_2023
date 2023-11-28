using Controladores;
using System;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Corrupcion : System.Web.UI.Page
    {
        BackupService backup = new BackupService();
        string pathActual = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Restaurar al backup mas reciente.
            DirectoryInfo directory = new DirectoryInfo("C://Backup//");
            //Es un quilombo ese LINQ pero saca el ultimo file y lo ordena por fecha a demas de buscar solo .baks.
            var myFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).ToList().Where(x => x.Extension == ".bak").ToList().First();
            pathActual = "C://Backup//" + myFile.FullName;
            backup.realizarRestore(pathActual);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Recalcular digitos verificadores.

        }
    }
}
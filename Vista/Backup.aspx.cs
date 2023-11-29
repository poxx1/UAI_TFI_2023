using Controladores;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Servicios;
using Model;

namespace Vista
{
    public partial class Backup : System.Web.UI.Page
    {
        BackupService backup = new BackupService();
        string pathActual = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            checkCreateDirectory();
            backup.realizarBackup("C://Backup");
            BitacoraService bitacoraService = new BitacoraService();
            UserModel user = new UserModel();
            bitacoraService.LogData("Login", $"El usuario {user.Name} realizo un backup.", "Media");
            GlobalMessage.MessageBox(this, "Se realizo el backup");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                checkCreateDirectory();
                pathActual = "C://Backup//" + FileUpload1.FileName;

                backup.realizarRestore(pathActual);

                BitacoraService bitacoraService = new BitacoraService();
                UserModel user = new UserModel();
                bitacoraService.LogData("Login", $"El usuario {user.Name} realizo un restore de la base de datos.", "Media");
                GlobalMessage.MessageBox(this,"Se realizo el restore");
            }
        }
        private void checkCreateDirectory()
        {
            string path = "C://Backup";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
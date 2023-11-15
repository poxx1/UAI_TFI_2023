using Controladores;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Backup : System.Web.UI.Page
    {
        BackupService backup = new BackupService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            checkCreateDirectory();
            //Backup
            backup.realizarBackup(Environment.SpecialFolder.MyDocuments.ToString()+"//Backup"); ;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            checkCreateDirectory();
            //Restore
            backup.realizarRestore(Environment.SpecialFolder.MyDocuments.ToString() + "//Backup");
        }
        private void checkCreateDirectory()
        {
            string path = Environment.SpecialFolder.MyDocuments.ToString() + "//Backup";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
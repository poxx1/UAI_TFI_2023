using System;
using System.IO;
using System.Text;
using AccesoDatos;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Controladores
{
    public class BackupService
    {
        private BackupRepository backupRepository;

        public BackupService()
        {
            backupRepository = new BackupRepository();
        }
        public String realizarBackup(String directorio)
        {
            String date = DateTime.Now.Date.ToShortDateString();
            date = date.Replace("/", "_");
            String nombreDelBack = "TFI_" + date + "-";
            directorio += "//" + nombreDelBack;
            backupRepository.realizarBackup(1, directorio);
            return directorio + "1.bak";
        }
        public void eliminarArchivo(String path)
        {
            File.Delete(path);
        }
        public void realizarRestore(String fullPath)
        {
            StringBuilder bs = new StringBuilder();
            bs.Append(" FROM DISK = '" + fullPath + "' ");
            backupRepository.realizarRestore(bs.ToString());
        }
    }
}
using Modelos;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Servicios
{
    public class BitacoraService
    {
        private string getCurrentTime()
        {
            //Para no tener problemas con las fechas, le hardcodeo a la verga la cultura y siempre
            //me mantiene el mismo formato. Si en la bd lo guardo como date y no como string soy un tarado.
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            return DateTime.Now.ToString("HH:mm:ss");
        }
        private string getCurrentDate()
        {
            //Para no tener problemas con las fechas, le hardcodeo a la verga la cultura y siempre
            //me mantiene el mismo formato. Si en la bd lo guardo como date y no como string soy un tarado.
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            return DateTime.Now.ToString("MM/dd/yy");
        }
        private string getCurrentUser()
        {
            try
            {
                return SessionModel.GetInstance.user.Nickname;
            }
            catch (Exception)
            {
                //MessageBox.Show("Error obteniendo el usuario actual");
                //MessageBox.Show(ex.Message);
                return "error";
            }
        }
        private int getCurrentUserID()
        {
            try
            {
                return SessionModel.GetInstance.user.Id;
            }
            catch (Exception)
            {             
                return 0;
            }
        }
        public bool LogData(string actividad, string informacion, string prioridad)
        {
            LogModel log = new LogModel();
            log.Usuario = getCurrentUser();
            log.Hora = getCurrentTime();
            log.Fecha = getCurrentDate();
            log.Details = actividad;
            log.Info = informacion;
            log.Priority = prioridad;

           BitacoraRepository logRepo = new BitacoraRepository();

            return logRepo.saveLog(log);
        }

        public List<LogModel> ListLogs()
        {
            BitacoraRepository log = new BitacoraRepository();
            return log.listLogs();
        }
    }
}
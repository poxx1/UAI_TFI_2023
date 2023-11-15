using Controladores;
using DataAccess;
using DigitosVerificadoresLib.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class IntegrityService 
    {
        List<IDVService> services = new List<IDVService>();

        public IntegrityService()
        {
            services.Add( new UserService());
        }
        public List<String> check()
        {
            List<String> result = new List<String>();

            //result.AddRange(checkDBService());
            result.AddRange(checkDV());

            return result;
        }

        public void recalcDV()
        {
            services.ForEach(service => service.reacalcDV());
        }

        private List<String> checkDV()
        {
            List<String> result = new List<String>();

            try
            {
                services.ForEach(service => result.AddRange(service.checkintegrity()));
            }
            catch ( Exception )
            {
                result.Add("Errores al obtener informacion por favor verifique la coneccion a la BD");
            }

            return result;
        }
    }
}

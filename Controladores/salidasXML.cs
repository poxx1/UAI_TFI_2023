using API;
using DigitosVerificadoresLib.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class salidasXML
    {
        public string llamarWebService(string webServiceName)
        {
            WebService1 webService1 = new WebService1();
            if (webServiceName == "solicitudesAprobadas") return webService1.getSolicitudesAprobadas().ToString();
            if (webServiceName == "solicitudesPendientes") return webService1.getSolicitudesAprobadas().ToString();
            if (webServiceName == "solicitudesTotales") return webService1.getSolicitudesAprobadas().ToString();

            else return "";
        }


    }
}
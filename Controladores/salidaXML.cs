using AccesoDatos;
using API;
using DigitosVerificadoresLib.services;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladores
{
    public class salidaXML
    {
        SolicitudRepository sr = new SolicitudRepository();

        public string llamarWebService(string webServiceName)
        {
            WebService1 webService1 = new WebService1();
            if (webServiceName == "solicitudesAprobadas") return webService1.getSolicitudesAprobadas().ToString();
            if (webServiceName == "solicitudesPendientes") return webService1.getSolicitudesPendientes().ToString();
            if (webServiceName == "solicitudesTotales") return webService1.getSolicitudesTotales().ToString();
            else return "";
        }
        public List<InterpretacionModel> solicitudesAprobadas() 
        {
            return sr.listSolicitudes().Where(x => x.isApproved == true).ToList();
        }
        public List<InterpretacionModel> solicitudesPendientes()
        {
            return sr.listSolicitudes().Where(x => x.isApproved == false).ToList();
        }
        public List<InterpretacionModel> solicitudesTotales()
        {
            return sr.listSolicitudes();
        }

        public bool exportarSolicitudesPendientes() { 
            //No se si es necesario incluso, porque esto lo hago desde la view
            return true; }
        public bool exportarSolicitudesAprobadas() { 

            return true; }
        public bool exportarSolicitudesTotales() { 

            return true; }
    }
}
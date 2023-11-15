﻿using AccesoDatos;
using Modelos;
using System.Collections.Generic;

namespace Controladores
{
    public class SolicitudService
    {
        SolicitudRepository repository = new SolicitudRepository();

        public bool createSolicitud(InterpretacionModel interpretacion)
        {
            return repository.createSolicitud(interpretacion);
        }

        public List<InterpretacionModel> listSolicitud()
        {
            return repository.listSolicitudes();
        }

        public bool deleteSolicitud()
        {
            return false;
        }
    }
}
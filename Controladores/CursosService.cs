using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Modelos;

namespace Servicios
{
    public class CursosService
    {
        CursosRepository cr = new CursosRepository();

        public bool  addCurso(CursosModel curso) {

            cr.addCurso(curso);
            return true;
        }

        public bool updateCurso(CursosModel curso)
        {

            cr.updateCurso(curso);
            return true;
        }

        public bool deleteCurso(CursosModel curso)
        {

            cr.deleteCurso(curso);
            return true;
        }

        public List<CursosModel> listCursos() {
            return cr.listCursos();
        }
    }
}

using AccesoDatos;
using System.Linq;
using System.Web.Services;

namespace API
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SolicitudRepository sr = new SolicitudRepository();

        [WebMethod]
        public int getSolicitudesTotales()
        {
            return sr.listSolicitudes().Count();
        }
        public int getSolicitudesAprobadas()
        {
            return sr.listSolicitudes().Where(x => x.isApproved == true).ToList().Count();
        }
        public int getSolicitudesPendientes()
        {
            return sr.listSolicitudes().Where(x => x.isApproved != true).ToList().Count();
        }
    }
}
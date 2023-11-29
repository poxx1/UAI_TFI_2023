using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Vista
{
    public partial class MenuItems : System.Web.UI.Page
    {
        CursosService cs = new CursosService();
        public static List<string> items;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListBox1.SelectedIndex = 0;
                //FALTA agregar lista a la session para que se guarde.
                if (Session["carrito"] == null)
                {
                    items = new List<string>();
                    Session["carrito"] = items;
                }

                //Foreach 
                List<string> listCursos = new List<string>();

                foreach (CursosModel curso in listarCursos())
                {
                    listCursos.Add(curso.Name);
                }

                //Listar cursos
                ListBox1.DataSource = listCursos;
                ListBox1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Redirect
            HttpContext.Current.Response.Redirect("MenuCarrito.aspx");
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CursosModel cursoActual = new CursosModel();
            string curso = ListBox1.SelectedValue.ToString();
            //string[] curso = cursoFull[0].ToString().Split(' ');

            cursoActual = listarCursos().Where(x => x.Name.Contains(curso.ToString())).ToList().First();

            if (cursoActual != null)
            {
                Label4.Text = cursoActual.Name;
                Label3.Text = "ARS$" + cursoActual.Price.ToString();
                Label2.Text = cursoActual.Description;
            }

            if(items!=null)
                items.Add(ListBox1.SelectedValue.ToString());


            BitacoraService bitacoraService = new BitacoraService();
            UserModel user = new UserModel();
            bitacoraService.LogData("Login", $"El usuario {user.Name} agrego un item al carrito.", "Media");
            GlobalMessage.MessageBox(this, $"Se agrego el item al carrito");
        }
        private List<CursosModel> listarCursos() {
            return cs.listCursos();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
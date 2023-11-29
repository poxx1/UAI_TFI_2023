using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class EditarCursos : System.Web.UI.Page
    {
        CursosService cs = new CursosService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Listar cursos
            if (!IsPostBack)
            {
                cargarDropDown();
            }
        }

        private void cargarDropDown()
        {
            List<CursosModel> list = new List<CursosModel>();
            list = cs.listCursos();
            List<string> cursos = new List<string>();
            foreach (CursosModel curso in list)
            {
                cursos.Add(curso.Name);
            }
            DropDownList1.DataSource = cursos;
            DropDownList1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Get current curso
            string cursoActual = DropDownList1.SelectedValue;
            CursosModel currentCurso = new CursosModel();
            currentCurso = cs.listCursos().Where(x => x.Name == cursoActual).ToList().FirstOrDefault();

            TextBox1.Text = currentCurso.Name;
            TextBox2.Text = currentCurso.Description;
            TextBox3.Text = currentCurso.Price.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Editar los datos del curso
            //Get current curso
            string cursoActual = DropDownList1.SelectedValue;
            CursosModel currentCurso = new CursosModel();
            currentCurso = cs.listCursos().Where(x => x.Name == cursoActual).ToList().FirstOrDefault();
            currentCurso.Name = TextBox1.Text;
            currentCurso.Description = TextBox2.Text;
            currentCurso.Price = float.Parse(TextBox3.Text);
            cs.updateCurso(currentCurso);
            cargarDropDown();

            BitacoraService bitacoraService = new BitacoraService();
            UserModel user = new UserModel();
            bitacoraService.LogData("Login", $"El usuario {user.Name} edito un curso.", "Media");
            GlobalMessage.MessageBox(this, "Se realizo el backup");
        }
    }
}
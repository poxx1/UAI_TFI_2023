using Modelos;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Permissions : System.Web.UI.Page
    {
        PermissionsService permissionsService;
        Family seleccion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            permissionsService = new PermissionsService();

            if (!Page.IsPostBack)
            {
                //Usuario
                DropDownList1.DataSource = null;
                DropDownList1.DataSource = permissionsService.GetAllPermission();
                DropDownList1.DataBind();

                //Patentes
                DropDownList2.DataSource = null;
                DropDownList2.DataSource = permissionsService.GetAllPatentes();
                DropDownList2.DataBind();

                var ListFamilias = permissionsService.GetAllFamilies();

                //Familia
                DropDownList3.DataSource = null;
                DropDownList3.DataSource = ListFamilias;
                DropDownList3.DataBind();

                //Familia por ID
                //List<int> listaIDs = new List<int>();

                foreach (Family family in ListFamilias)
                {
                    if (family.Id.ToString() == DropDownList3.Text)
                    {
                        //listaIDs.Add(family.Id);
                        ListFamilias.Remove(family);
                    }
                }

                //permissionsService.GetAllFamilies()
                DropDownList4.DataSource = null;
                DropDownList4.DataSource = ListFamilias;
                DropDownList4.DataBind();

                MostrarFamilia(true);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var item = permissionsService.GetAllFamilies().Where(x => x.Nombre.ToString() == DropDownList3.SelectedItem.Text).Single();
            seleccion = new Family();
            seleccion.Id = item.Id;
            seleccion.Nombre = item.Nombre;

            MostrarFamilia(true);
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Patentes

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Familias con ID
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Usuarios
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Guardar patente
            Patent p = new Patent()
            {
                Nombre = TextBox1.Text,
                //Permiso = (PermissionsEnum)DropDownList1.SelectedItem
            };

            permissionsService.SaveComponent(p, false);
            //Reload de la pagina asi muestra la nueva patente

            //MessageBox.Show("Patente guardada correctamente");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {

                Family p = new Family()
                {
                    Nombre = TextBox2.Text//.GetStringMinLength(3)???
                };
                permissionsService.SaveComponent(p, true);
                //Reload de la pagina asi muestra la nueva familia

                //MessageBox.Show("Familia guardada correctamente");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ocurrio un Error " + (ex.Message ?? (":" + ex.Message)));
            }
        }
        private void MostrarFamilia(bool init)
        {
            if (seleccion == null) return;

            IList<Component> flia = null;
            if (init)
            {
                flia = permissionsService.GetAll("=" + seleccion.Id);

                foreach (Component i in flia)
                    seleccion.AddChild(i);
            }
            else
            {
                flia = seleccion.Childs;
            }

            TreeView1.Nodes.Clear();

            TreeNode root = new TreeNode(seleccion.Nombre);
            root.Value = seleccion.ToString(); //fijate que onda
            TreeView1.Nodes.Add(root);

            foreach (Component item in flia)
            {
                MostrarEnTreeView(root, item);
            }

            TreeView1.ExpandAll();
        }
        private void MostrarEnTreeView(TreeNode tn, Component component)
        {
            TreeNode node = new TreeNode(component.Nombre);
            tn.Value = component.ToString();
            tn.ChildNodes.Add(node);
            if (component.Childs != null)
                foreach (Component item in component.Childs)
                {
                    MostrarEnTreeView(node, item);
                }
        }
    }
}
using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Vista
{
    public partial class FamiliaPatente : System.Web.UI.Page
    {
        PermissionsService permissionsService;
        Family seleccion;
        public static bool inEng = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            if ((bool)Session["permission"] != true) HttpContext.Current.Response.Redirect("Default.aspx");
            
            //Idioma
            if ((int)Session["language"] == 1) inEng = false; //1 = ESP
            if ((int)Session["language"] == 2) inEng = true; //2 = ENG

            permissionsService = new PermissionsService();
            
            if (!Page.IsPostBack)
            {
                //Patentes
                DropDownList2.DataSource = null;
                DropDownList2.DataSource = permissionsService.GetAllPatentes();
                DropDownList2.DataBind();

                var ListFamilias = permissionsService.GetAllFamilies();

                //Familia
                DropDownList3.DataSource = null;
                DropDownList3.DataSource = ListFamilias;
                DropDownList3.DataBind();

                //MostrarFamilia(true); Hacer un metodo que lo autocargue
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
            //Familias

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                ////Guardar familia
                PermissionsService ps = new PermissionsService();
                string value = TreeView1.SelectedNode.Value;

                //Traerme a la familia.
                List<Patent> list = new List<Patent>();
                //list = ps.GetAllPatentes();

                Family components = ps.GetAllFamilies().Where(x => x.Nombre == value).ToList().FirstOrDefault();

                var listaHijos = TreeView1.SelectedNode.ChildNodes;
                foreach (TreeNode child in listaHijos)
                {
                    //Child.txt
                    components.AddChild(ps.GetAllPatentes().Where(x => x.Nombre == child.Text).ToList().FirstOrDefault());
                }

                ps.SaveFamily(components);

                BitacoraService bitacoraService = new BitacoraService();
                UserModel user = new UserModel();
                bitacoraService.LogData("Login", $"El usuario {user.Name} modifico una familia.", "Media");
                GlobalMessage.MessageBox(this, $"Se modifico la familia");
            }
            catch(Exception ex) { GlobalMessage.MessageBox(this, $"Error modificando la familia"); }
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
        protected void Button4_Click(object sender, EventArgs e)
        {
            try 
            { 
            TreeNode nuevaPatente = new TreeNode();
            nuevaPatente.Text = DropDownList2.SelectedItem.Text.ToString();
            
                //Error de nulidad
                TreeView1.Nodes.Add(nuevaPatente);
                
                //Agregar permiso
                TreeView1.SelectedNode.ChildNodes.Add(nuevaPatente);
                TreeView1.ExpandAll();
                TreeView1.DataBind();

            }
            catch (Exception) { }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            //Quitar permiso

            //ESTA PORONGA NO ANDA, HAY QUE COPIARSE DEL METODO DE ARRIBA BUTTON 4, y hacer lo mismo
            try
            {
                TreeNode currentPatente = new TreeNode();
                currentPatente.Text = DropDownList2.SelectedItem.Text.ToString();
                var list = TreeView1.SelectedNode.ChildNodes.Cast<TreeNode>().ToList();
                
                foreach (TreeNode node in list)
                {
                    if (node.Text == currentPatente.Text)
                        TreeView1.SelectedNode.ChildNodes.Remove(node);
                }

                TreeView1.ExpandAll();
                TreeView1.DataBind();
            }
            catch (Exception) { }

            try
            {
                ////Guardar familia
                PermissionsService ps = new PermissionsService();
                string value = TreeView1.SelectedNode.Value;

                //Traerme a la familia.
                List<Patent> list = new List<Patent>();
                //list = ps.GetAllPatentes();

                Family components = ps.GetAllFamilies().Where(x => x.Nombre == value).ToList().FirstOrDefault();

                var listaHijos = TreeView1.SelectedNode.ChildNodes;
                foreach (TreeNode child in listaHijos)
                {
                    //Child.txt
                    components.AddChild(ps.GetAllPatentes().Where(x => x.Nombre == child.Text).ToList().FirstOrDefault());
                }

                ps.SaveFamily(components);

                BitacoraService bitacoraService = new BitacoraService();
                UserModel user = new UserModel();
                bitacoraService.LogData("Login", $"El usuario {user.Name} modifico una familia.", "Media");
                GlobalMessage.MessageBox(this, $"Se modifico la familia");
            }
            catch (Exception ex) { GlobalMessage.MessageBox(this, $"Error modificando la familia"); }
        }
    }
}
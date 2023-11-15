using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Vista.Customs
{
    public partial class ValidatePassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Password checker

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
          // Free 
        }

        public string getText()
        {
            return TextBox1.Text;
        }
        protected void tb_KeyDown(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length <= 5)
            {
                Label1.ForeColor = System.Drawing.Color.IndianRed;
                Label1.Text = "La contraseña es demaciado corta!";
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.IndianRed;
                Label1.Text = "La contraseña es aceptable";
            }
        }
    }
}
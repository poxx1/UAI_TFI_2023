using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Customs
{
    public partial class ValidateLetras : System.Web.UI.UserControl
    {
        public bool valid = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tb_KeyDown(object sender, EventArgs e)
        {
        
        }
        public bool isValid()
        {
            string email = TextBox1.Text;
            Regex regex = new Regex(@"^\d$");
            valid = regex.IsMatch(email);
            return valid;
        }
    }
}
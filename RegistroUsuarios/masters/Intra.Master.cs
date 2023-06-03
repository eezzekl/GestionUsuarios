using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.masters
{
    public partial class Intra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("UsrLogin");
            Response.Redirect("~/Public/Login.aspx");
        }
    }
}
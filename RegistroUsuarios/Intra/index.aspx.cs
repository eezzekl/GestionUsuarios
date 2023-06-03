using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Intra
{
    public partial class index : System.Web.UI.Page
    {
        UsuarioService usrServices;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsrLogin"] == null)
            {
                //Si es igual a null quiere decir que no tiene sesion y no se pemite el acceso. 
                //Redirige a login 
                Response.Redirect("~/Public/Login.aspx");
            }
            fillTable();
            
        }

        void fillTable()
        {
            usrServices = new UsuarioService();
            var usuarios = usrServices.ObtenerTodosLosUsuarios();
            gvusuarios.DataSource = usuarios;
            gvusuarios.DataBind();

        }
        public void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("UsrLogin");
            Response.Redirect("~/Public/Login.aspx");
        }
        
        public void BtnDelete_Click(object sender, EventArgs e)
        {
            var BtnConsultar = (Button)sender;
            var selectedRow = (GridViewRow)BtnConsultar.NamingContainer;
            var id = selectedRow.Cells[1].Text;
            Response.Redirect($"~/Intra/CRUD.aspx?id={id}&op=D");
        }

        public void BtnUpdate_Click(object sender, EventArgs e)
        {
            var BtnConsultar = (Button)sender;
            var selectedRow = (GridViewRow)BtnConsultar.NamingContainer;
            var id = selectedRow.Cells[1].Text;
            Response.Redirect($"~/Intra/CRUD.aspx?id={id}&op=U");
        }

        public void BtnRead_Click(object sender, EventArgs e)
        {
            var BtnConsultar = (Button)sender;
            var selectedRow = (GridViewRow)BtnConsultar.NamingContainer;
            var id = selectedRow.Cells[1].Text;
            Response.Redirect($"~/Intra/CRUD.aspx?id={id}&op=R");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Intra/CRUD.aspx?op=C");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using Business;

namespace RegistroUsuarios.Public
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BtnIngresar_Click (object sender, EventArgs e)
        {
            UsuarioService usr = new UsuarioService();
            var loginDTO = new UsuarioLoginDTO()
            {
                Usuario = txtUsuario.Text.Trim(),
                Pswd = txtPassword.Text.Trim()
            };
            try
            {
                var usuario = usr.LoginUsuario(loginDTO);

                if (usuario.Id != 0)
                {
                    //Sesion de usuario 
                    Session["UsrLogin"] = usuario;
                    Response.Redirect("~/Intra/index.aspx");
                }

                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos";
                    //Mensaje de sesion falsa
                }
            }
            catch  (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
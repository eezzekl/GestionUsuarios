using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Public
{
    public partial class Registro : System.Web.UI.Page
    {
        int id = 0;
        UsuarioService usr;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void limpiaCampos()
        {
            txtCorreo.Text = "";
            txtPswd.Text = "";
            txtUsuario.Text = "";
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text == "" || txtPswd.Text == "" || txtCorreo.Text == "")
            {
                lblError.Text = "Todos los campos deben ser llenados";
                return;
            }

            if (txtConfPswd.Text != txtPswd.Text)
            {
                lblError.Text = "Las contraseñas no coinciden";
                return;
            }

            usr = new UsuarioService();
            var usuario = new Usuario()
            {
                usuario = txtUsuario.Text.Trim(),
                Pswd = txtPswd.Text.Trim(),
                CorreoElectronico = txtCorreo.Text.Trim(),
                Sexo = ddlSexo.SelectedValue
            };
            try
            {
                var registro = "";
                if (id == 0)
                     registro = usr.CreaUsuario(usuario);
                else
                {
                    usuario.Id = id;
                    registro = usr.UpdateUsuario(usuario);
                }

                if (registro != "")
                {
                    //Sesion de usuario 
                    if (Session["UsrLogin"] == null)
                        Session["UsrLogin"] = usuario;
                    Response.Redirect("~/Intra/index.aspx");
                }

                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos";
                    //Mensaje de sesion falsa
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }



        }

    }
}
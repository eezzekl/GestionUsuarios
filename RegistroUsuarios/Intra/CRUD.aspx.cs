using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios.Intra
{
    public partial class CRUD : System.Web.UI.Page
    {
        UsuarioService usrServices;
        private static int sId = -1;
        private static string opc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsrLogin"] == null)
            {
                //Si es igual a null quiere decir que no tiene sesion y no se pemite el acceso. 
                //Redirige a login 
                Response.Redirect("~/Public/Login.aspx");
            }

            if (Request.QueryString["op"] != null)
            {
                opc = Request.QueryString["op"].ToString();
                switch (opc)
                {
                    case "C":
                        lblTitulo.Text = "Crea Usuario";
                        BtnCreate.Visible = true;
                        break;
                    case "U":
                        lblTitulo.Text = "Actualiza Usuario";
                        BtnUpdate.Visible = true;
                        break;
                    case "R":
                        lblTitulo.Text = "Consulta de Usuario";
                        break;
                    case "D":
                        lblTitulo.Text = "Eliminar Usuario";
                        BtnDelete.Visible = true;
                        break;
                    default:
                        lblTitulo.Text = "Consulta de Usuario";
                        break;
                }
            }
            //Se obtienen los datos recibidos de la url 
            if (Request.QueryString["id"] != null)
            {
                sId = Convert.ToInt32(Request.QueryString["id"].ToString());
                llenaDatos();
            }
            HabilitaCampos(opc);
        }



        private void llenaDatos()
        {
            usrServices = new UsuarioService();
            try
            {
                var usuario = usrServices.ObtenerUsuarioPorId(sId);
                txtCorreo.Text = usuario.CorreoElectronico;
                txtUsuario.Text = usuario.Usuario;
                ddlSexo.SelectedValue = usuario.Sexo;
                if (opc == "R")
                {
                    txtEstatus.Text = usuario.Estatus;
                    txtFCreacion.Text = usuario.FechaCreacion.ToString();
                    fsInformativos.Visible = true;
                }
            }
            catch
            {
                lblError.Text = $"No se encontro usuario con el Id {sId}";
                lblError.Visible = true;
            }


        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtPswd.Text == "" || txtCorreo.Text == "")
            {
                lblError.Text = "Todos los campos deben ser llenados";
                lblError.Visible = true;
                return;
            }

            if (txtConfPswd.Text != txtPswd.Text)
            {
                lblError.Text = "Las contraseñas no coinciden";
                lblError.Visible = true;
                return;
            }

            usrServices = new UsuarioService();
            var usr = new Usuario()
            {
                usuario = txtUsuario.Text.Trim(),
                Pswd = txtPswd.Text.Trim(),
                CorreoElectronico = txtCorreo.Text.Trim(),
                Sexo = ddlSexo.SelectedValue,
                Id = sId
            };
            var registro = usrServices.UpdateUsuario(usr);
            if (registro != "")
            {
                lblExito.Text = $"El usuario {usr.usuario} se ha actualizado correctamente";
                lblExito.Visible = true;
                Response.Redirect("~/Intra/index.aspx");
            }

            else
            {
                lblError.Text = "Usuario o contraseña incorrectos";
                lblError.Visible = true;
                //Mensaje de sesion falsa
            }

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            usrServices = new UsuarioService();

            var registro = usrServices.EliminaUsuario(sId);
            if (registro != "")
            {
                lblExito.Text = $"El usuario se ha actualizado correctamente";
                lblExito.Visible = true;
                Response.Redirect("~/Intra/index.aspx");
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtPswd.Text == "" || txtCorreo.Text == "")
            {
                lblError.Text = "Todos los campos deben ser llenados";
                lblError.Visible = true;
                return;
            }

            if (txtConfPswd.Text != txtPswd.Text)
            {
                lblError.Text = "Las contraseñas no coinciden";
                lblError.Visible = true;
                return;
            }

            usrServices = new UsuarioService();
            var usr = new Usuario()
            {
                usuario = txtUsuario.Text.Trim(),
                Pswd = txtPswd.Text.Trim(),
                CorreoElectronico = txtCorreo.Text.Trim(),
                Sexo = ddlSexo.SelectedValue
            };
            var registro = usrServices.CreaUsuario(usr);
            if (registro != "")
            {
                lblExito.Text = $"El usuario {usr.usuario} se ha creado correctamente";
                lblExito.Visible = true;
                Response.Redirect("~/Intra/index.aspx");
            }

        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Intra/index.aspx");
        }

        private void HabilitaCampos(string opc)
        {
            switch (opc)
            {
                case "C":
                    txtUsuario.Enabled = true;
                    txtPswd.Enabled = true;
                    txtCorreo.Enabled = true;
                    ddlSexo.Enabled = true;
                    dvconContra.Visible = true;//Se muestra la informacion para confirmar la contraseña.
                    break;
                case "U":
                    txtUsuario.Enabled = true;
                    txtPswd.Enabled = true;
                    txtCorreo.Enabled = true;
                    ddlSexo.Enabled = true;
                    dvconContra.Visible = true;//Se muestra la informacion para confirmar la contraseña.
                    break;
                case "R": //Se deshabilitan todos los campos.
                    txtUsuario.Enabled = false;
                    txtPswd.Enabled = false;
                    txtCorreo.Enabled = false;
                    ddlSexo.Enabled = false;
                    dvconContra.Visible = false;//se oculta la confirmacion de contraseña 
                    break;
                case "D":
                    txtUsuario.Enabled = false;
                    txtPswd.Enabled = false;
                    txtCorreo.Enabled = false;
                    ddlSexo.Enabled = false;
                    dvconContra.Visible = false;//se oculta la confirmacion de contraseña 
                    break;
            }
        }
    }
}
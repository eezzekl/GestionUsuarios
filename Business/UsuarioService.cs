using DAL;
using Entities;
using RegistroUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuarioService
    {
        private UsuariosDAO usrDAO;

        public UsuarioService()
        {
            usrDAO = new UsuariosDAO();
        }

        public UsuarioDTO ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = usrDAO.ObtenerUsuarioPorId(id);
            return ConvertirUsuarioAUsuarioDTO(usuario);
        }

        public List<UsuarioDTO> ObtenerTodosLosUsuarios()
        {
            List<Usuario> usuarios = usrDAO.ObtenerTodosLosUsuarios();
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();

            foreach (var usuario in usuarios)
            {
                var usuarioDTO = ConvertirUsuarioAUsuarioDTO(usuario);
                usuariosDTO.Add(usuarioDTO);
            }

            return usuariosDTO;
        }

        public Usuario LoginUsuario( UsuarioLoginDTO usr )
        {
            return usrDAO.LoginUsuario(usr);
        }

        public string EliminaUsuario(int id)
        {
            return usrDAO.InactivaUsuario(id);
        }

        public string CreaUsuario(Usuario usr)
        {
            if (!IsValidUser(usr))
            {
                throw new Exception("No se cumplen las validaciones para la creacion del usuario");
            }
            return usrDAO.AddUsuario(usr);
        }

        public string UpdateUsuario(Usuario usr)
        {
            if (!IsValidUser(usr))
            {
                throw new Exception("Los datos de usuario no son validos");
            }
            return usrDAO.UpdateUsuario(usr);
        }

        private bool IsValidUser(Usuario usr)
        {
            if (usr.CorreoElectronico == "" || usr.usuario == "" || usr.Pswd == "" || usr.Sexo == "")
                return false;
            else if (usr.usuario.Length < 7)
                return false;
            else if (!RegexUtilities.IsValidEmail(usr.CorreoElectronico))
                return false;
            else if (!RegexUtilities.IsValidPassword(usr.Pswd))
                return false;
            return true;
        }

        private UsuarioDTO ConvertirUsuarioAUsuarioDTO(Usuario usuario)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                CorreoElectronico = usuario.CorreoElectronico,
                Usuario = usuario.usuario,
                Estatus = usuario.Estatus,
                Sexo = usuario.Sexo,
                FechaCreacion = usuario.FechaCreacion
            };

            return usuarioDTO;
        }

        private Usuario ConvertirUsuarioDTOAUsuario(UsuarioDTO usuario)
        {
            Usuario usr = new Usuario
            {
                Id = usuario.Id,
                CorreoElectronico = usuario.CorreoElectronico,
                usuario = usuario.Usuario,
                Estatus = usuario.Estatus,
                Sexo = usuario.Sexo,
                FechaCreacion = usuario.FechaCreacion
            };

            return usr;
        }
    }
}

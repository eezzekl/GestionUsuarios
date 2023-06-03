using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class UsuariosDAO
    {
        private static string cnstr;
        public UsuariosDAO() {
            cnstr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        private Usuario MapUsuarioFromReader(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            DataTable schemaTable = reader.GetSchemaTable();
            usuario.Id = (int)reader["Id"];
            if (schemaTable.Select("ColumnName = 'CorreoElectronico'").Length > 0)
                usuario.CorreoElectronico = (string)reader["CorreoElectronico"];
            if (schemaTable.Select("ColumnName = 'Usuario'").Length > 0)
                usuario.usuario = (string)reader["Usuario"];
            if (schemaTable.Select("ColumnName = 'Pswd'").Length > 0)
                usuario.Pswd = Convert.ToString( (byte[])reader["Pswd"]);
            if (schemaTable.Select("ColumnName = 'Estatus'").Length > 0)
                usuario.Estatus = (string)reader["Estatus"];
            if (schemaTable.Select("ColumnName = 'Sexo'").Length > 0)
                usuario.Sexo = (string)reader["Sexo"];
            if (schemaTable.Select("ColumnName = 'FechaCreacion'").Length > 0)
                usuario.FechaCreacion = (DateTime)reader["FechaCreacion"];

            return usuario;
        }

        /// <summary>
        /// Obtenemos un usuario por id
        /// </summary>
        /// <param name="id">id del usuario</param>
        /// <returns>objeto usuario</returns>
        public Usuario ObtenerUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                string query = "ObtenerUsuarioById";
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return MapUsuarioFromReader(reader);
                }

                return null;
            }
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                string query = "ObtenerListadoUsuarios";
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    Usuario usuario = MapUsuarioFromReader(reader);
                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        public Usuario LoginUsuario(UsuarioLoginDTO usr)
        {
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                string query = "LoginUsuario";
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usr.Usuario;
                command.Parameters.Add("@Pswd", SqlDbType.VarChar, 100).Value = usr.Pswd;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    return MapUsuarioFromReader(reader);

                }
            }

            return null;
        }

        public string AddUsuario(Usuario usr)
        {
            var resultado = "";
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                string query = "CrearUsuario";
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usr.usuario;
                command.Parameters.Add("@Pswd", SqlDbType.VarChar, 100).Value = usr.Pswd;
                command.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 100).Value = usr.CorreoElectronico;
                command.Parameters.Add("@Sexo", SqlDbType.VarChar, 100).Value = usr.Sexo;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    resultado = (string)reader["Resultado"];
                }
            }

            return resultado;
        }

        public string UpdateUsuario(Usuario usr)
        {
            var resultado = "";
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                string query = "ActualizarUsuario";
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@Id", SqlDbType.Int).Value = usr.Id;
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usr.usuario;
                command.Parameters.Add("@Pswd", SqlDbType.VarChar, 100).Value = usr.Pswd;
                command.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 100).Value = usr.CorreoElectronico;
                command.Parameters.Add("@Sexo", SqlDbType.VarChar, 100).Value = usr.Sexo;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    resultado = (string)reader["Resultado"];
                }
            }

            return resultado;
        }

        public string InactivaUsuario(int id)
        {
            var resultado = "";
            using (SqlConnection connection = new SqlConnection(cnstr))
            {
                string query = "InactivarUsuario";
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                {
                    resultado = (string)reader["Resultado"];
                }
            }

            return resultado;
        }

    }
}

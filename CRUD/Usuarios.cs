using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Usuarios
    {
        private string cadenaConexion;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }

        public Usuarios(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public bool CrearUsuario(string nombre, string direccion, string identificacion, string usuario, string clave, int idRol)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                string query = "INSERT INTO Usuarios (Nombre, Direccion, Identificacion, Usuario, Clave, Id_Rol) VALUES (@Nombre, @Direccion, @Identificacion, @Usuario, @Clave, @IdRol)";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Identificacion", identificacion);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@IdRol", idRol);


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool ValidarCredenciales(string usuario, string clave)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Clave = @Clave";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Clave", clave);

                    connection.Open();
                    int result = (int)command.ExecuteScalar();

                    // Si result es mayor que 0, las credenciales son válidas.
                    return result > 0;
                }
            }
        }

        public List<Usuarios> ObtenerUsuarios()
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT UsuarioID, Nombre, Direccion, Identificacion, Usuario, Clave, Id_Rol FROM Usuarios";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios usuario = new Usuarios(cadenaConexion)
                            {
                                Id = (int)reader["UsuarioID"],
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Identificacion = reader["Identificacion"].ToString(),
                                Usuario = reader["Usuario"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                IdRol = (int)reader["Id_Rol"]
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }

        public string ValidarCredencialesYObtenerUsuario(string usuario, string clave)
        {
            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT Nombre FROM Usuarios WHERE Usuario = @Usuario AND Clave = @Clave";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Clave", clave);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return result.ToString(); // Devuelve el nombre de usuario si las credenciales son válidas.
                    }
                }
            }

            return null; // Devuelve null si las credenciales son inválidas.
        }



    }
}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Paquetes
    {
        private string cadenaConexion;
        public int PaqueteID { get; set; }
        public string TipoPaquete { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int UsuarioID { get; set; }
        public Paquetes(string cadenaConexion)
        {
            
            this.cadenaConexion = cadenaConexion;
        }
        public List<Paquetes> ObtenerPaquetesPorUsuario(int usuarioID)
        {
            List<Paquetes> paquetes = new List<Paquetes>();

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT * FROM Paquetes WHERE Id_Usuario = @Id_Usuario";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Id_Usuario", usuarioID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Paquetes paquete = new Paquetes(cadenaConexion)
                        {
                            PaqueteID = (int)reader["PaqueteID"],
                            UsuarioID = (int)reader["ID_Usuario"],
                            TipoPaquete = reader["TipoPaquete"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Costo = (decimal)reader["Costo"]
                        };

                        paquetes.Add(paquete);
                    }

                    reader.Close();
                }
            }

            return paquetes;
        }


    }
}

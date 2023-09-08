using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CRUD; // Asumo que este es el espacio de nombres donde tienes lógica relacionada con la base de datos

namespace Capa_Presentacion.UI.Autenticacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = usuarioTextBox.Text;
            string clave = claveTextBox.Text;
            

            // Crea una instancia de UsuariosDAL y pasa la cadena de conexión desde tu configuración.
            Usuarios usuariosDAL = new Usuarios(ConfigurationManager.ConnectionStrings["conexion"].ToString());

            string nombreRealUsuario = usuariosDAL.ValidarCredencialesYObtenerUsuario(usuario, clave);

            // Crea una nueva conexión para el procedimiento almacenado
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                con.Open();

                // Llama al procedimiento almacenado con un valor nulo para @Patron.
                SqlCommand cmd = new SqlCommand("sp_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asigna valores para @usuario y @clave.
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@clave", clave);

                // Asigna un valor nulo o predeterminado para @Patron.
                cmd.Parameters.AddWithValue("@Patron", DBNull.Value); // O cmd.Parameters.AddWithValue("@Patron", "ValorPredeterminado");

                // Ejecuta el procedimiento almacenado.
                SqlDataReader rd = cmd.ExecuteReader();

                // Valida las credenciales utilizando tu lógica personalizada (UsuariosDAL).
                bool inicioSesionExitoso = usuariosDAL.ValidarCredenciales(usuario, clave);

                if (inicioSesionExitoso)
                {
                    Session["Nombre"] = nombreRealUsuario;
                    Response.Redirect("/UI/Autenticacion/Luego_Sesion.aspx");
                }
                else
                {
                    lblMensaje.Text = "Credenciales incorrectas. Inténtalo de nuevo.";
                }
            }
        }
    }
}


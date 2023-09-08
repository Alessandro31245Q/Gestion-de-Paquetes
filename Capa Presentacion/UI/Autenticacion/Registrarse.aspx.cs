using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD;


namespace Capa_Presentacion.UI.Autenticacion
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            
            string nombre = nombreTextBox.Text;
            string direccion = direccionTextBox.Text;
            string identificacion = identificacionTextBox.Text;
            string usuario = usuarioTextBox.Text;
            string clave = claveTextBox.Text;
            int idRol = 0; // Implementa esta función según cómo manejes los roles en tu formulario.

            // Crea una instancia de UsuariosDAL y pasa la cadena de conexión desde tu configuración.
            Usuarios usuariosDAL = new Usuarios(ConfigurationManager.ConnectionStrings["conexion"].ToString());

            bool registroExitoso = usuariosDAL.CrearUsuario(nombre, direccion, identificacion, usuario, clave, idRol);

            if (registroExitoso)
            {
                Response.Redirect("/UI/Autenticacion/Login.aspx");
            }
            else
            {
                lblMensaje.Text = "Hubo un error durante el registro.";
            }
        }

     



    }
}
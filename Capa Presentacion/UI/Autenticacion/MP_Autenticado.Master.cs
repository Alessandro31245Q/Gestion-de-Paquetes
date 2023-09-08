using Capa_Presentacion.UI.Paquetes;
using CRUD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Capa_Presentacion.UI.Autenticacion
{
    public partial class MP_Autenticado : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int usuarioID = ObtenerUsuarioID(); // Implementa esta función según tu lógica

                // Crea una instancia de la clase Paquetes con la cadena de conexión
                CRUD.Paquetes paquetesDAL = new CRUD.Paquetes(ConfigurationManager.ConnectionStrings["conexion"].ToString());

                // Obtén la lista de paquetes para el usuario
                var paquetesDelUsuario = paquetesDAL.ObtenerPaquetesPorUsuario(usuarioID);
                gridPaquetes.DataSource = paquetesDelUsuario;
                gridPaquetes.DataBind();


                // Enlaza los datos al control GridView
                gridPaquetes.DataSource = paquetesDelUsuario;
                if (Session["Nombre"] != null)
                {
                    string userName = Session["Nombre"].ToString();

                    lblUserName.Text = "Bienvenido, " + userName;
                   
                }
            }
        }

        // Este método debe obtener el ID de usuario del usuario que inició sesión
        private int ObtenerUsuarioID()
        {
         
            if (Session["ID_Usuario"] != null)
            {
                return Convert.ToInt32(Session["ID_Usuario"]);
            }
            else
            {
                return 0; // Devuelve 0 si no se puede determinar el ID de usuario.
            }
        }

    }
}

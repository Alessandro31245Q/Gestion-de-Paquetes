using CRUD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Presentacion.UI.Paquetes;

namespace Capa_Presentacion.UI.Autenticacion
{
    public partial class Luego_Sesion : System.Web.UI.Page
    {
        protected List<Usuarios> ListaUsuariosRegistrados { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtén la lista de usuarios desde tu capa de datos
                Usuarios usuariosDAL = new Usuarios(ConfigurationManager.ConnectionStrings["conexion"].ToString());
                List<Usuarios> listaUsuarios = usuariosDAL.ObtenerUsuarios();

                // Enlaza la lista de usuarios al GridView
                gridUsuarios.DataSource = listaUsuarios;
                gridUsuarios.DataBind();
            }
        }
        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capa_Presentacion.UI
{
    public partial class MP : System.Web.UI.MasterPage
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                this.MasterPageFile = "~/MP_Autenticado.master";
            }
            else
            {
                this.MasterPageFile = "~/MP.master";
            }
        }

    }
}
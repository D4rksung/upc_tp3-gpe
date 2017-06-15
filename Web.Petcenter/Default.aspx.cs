using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Petcenter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Session["_Seguridad"] = new Entidades.Petcenter.Seguridad() { idUsuario = 1, Nombres = "Usuario sistema", strConexion = "conexion de la base de datos", indHabilitado = 1 };
            }

        }
    }
}
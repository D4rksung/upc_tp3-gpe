using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Petcenter
{
    public class SessionUsuario
    {

        private string conexion;

        private static SessionUsuario instance = null;

        private SessionUsuario() {

        }

        public static SessionUsuario GetInstance()
        {
            if (instance == null)
            {
                instance = new SessionUsuario();
                instance.conexion = System.Configuration.ConfigurationManager.AppSettings["database"].ToString();
            }
                

            return instance;
        }

    }
}

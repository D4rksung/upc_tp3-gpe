using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocio.Petcenter
{


   public interface IProgramacion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="idServicio"></param>
        /// <param name="idCita"></param>
        /// <param name="dtEmpleados"></param>
        /// <param name="idDetalleCita"></param>
        /// <param name="idSector"></param>
        /// <param name="accion"></param>
        /// <param name="motivoAnulacion"></param>
        /// <returns></returns>
        Boolean GrabarProgramación(Int32 idServicio, String idCita, DataTable dtEmpleados, Int32 idDetalleCita, Int32 idSector, Int32 accion, String motivoAnulacion);
    }
}

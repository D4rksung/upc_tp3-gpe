using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Negocio.Petcenter
{
   public interface IProgramacion
    {
        Boolean GrabarProgramación(Int32 idServicio, String idCita, DataTable dtEmpleados, Int32 idDetalleCita, Int32 idSector, Int32 accion, String MotivoAnulacion);
    }
}

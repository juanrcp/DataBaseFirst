using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.Modelo
{
    public class Empleado
    {
        public Empleado()
        {
            NivelAccesos = new HashSet<NivelAcceso>();
        }

        public int Id { get; set; }
        public string NombreEmpleado { get; set; }

        public virtual ICollection<NivelAcceso> NivelAccesos { get; set; }
    }
}

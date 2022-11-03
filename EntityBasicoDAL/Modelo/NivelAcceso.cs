using System;
using System.Collections.Generic;

namespace EntityBasicoDAL.Modelo
{
    public partial class NivelAcceso
    {
        public int Id { get; set; }
        public string NivelAcceso1 { get; set; } = null!;
        public string DescAcceso { get; set; } = null!;
        public int? EmpleadoId { get; set; }

        public virtual Empleado? Empleado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    public class ObservacionDetalleAuditoria
    {
        public int ID { get; set; }

        public int DetalleAuditoriaID { get; set; }

        public int ObservacionID { get; set; }

        public bool Contemplada { get; set; }
    }
}

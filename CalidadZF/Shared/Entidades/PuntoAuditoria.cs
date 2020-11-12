using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    [Table("tblPuntosAuditoria")]
    public class PuntoAuditoria
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }
    }
}

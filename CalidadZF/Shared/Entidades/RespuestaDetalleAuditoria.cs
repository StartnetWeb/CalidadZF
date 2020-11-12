using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    [Table("tblRespuestasDetalleAuditoria")]
    public class RespuestaDetalleAuditoria
    {
        public int ID { get; set; }

        [NotMapped]
        public int PuntoAuditoriaID { get; set; }

        public string Descripcion { get; set; }

        public string ClaseHtml { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    [Table("tblDetallesAuditoria")]
    public class DetalleAuditoria
    {
        public int ID { get; set; }

        [ForeignKey("Auditoria")]
        public int AuditoriaID { get; set; }

        [ForeignKey("RespuestaDetalleAuditoria")]
        public int RespuestaID { get; set; }

        [ForeignKey("PuntoAuditoria")]
        public int PuntoAuditoriaID { get; set; }

        public virtual Auditoria Auditoria { get; set; }

        public virtual RespuestaDetalleAuditoria RespuestaDetalleAuditoria { get; set; }

        public virtual PuntoAuditoria PuntoAuditoria { get; set; }
    }
}

using CalidadZF.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadZF.Shared.DTOs
{
    public class AuditoriaDTO
    {
        public int ID { get; set; }
        public string NroOrden { get; set; }
        public string NroPieza { get; set; }

        public Area Area { get; set; }
        public Proceso Proceso { get; set; }
        public Maquina Maquina { get; set; }

        public Operario Operario { get; set; }
        public Operario Supervisor { get; set; }

        public List<DetalleAuditoria> DetallesAuditoria { get; set; }
    }
}

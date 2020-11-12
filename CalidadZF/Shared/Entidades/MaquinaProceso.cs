using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    [Table("tblMaquinasProceso")]
    public class MaquinaProceso
    {
        public int ID { get; set; }

        [ForeignKey("Proceso")]
        public int ProcesoID { get; set; }

        [ForeignKey("Maquina")]
        public int MaquinaID { get; set; }

        public virtual Proceso Proceso { get; set; }

        public virtual Maquina Maquina { get; set; }
    }
}

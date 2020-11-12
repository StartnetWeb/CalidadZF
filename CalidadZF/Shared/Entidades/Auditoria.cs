using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    [Table("tblAuditorias")]
    public class Auditoria
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //Numero del Mes de la auditoria. Ej.: 8
        public int Mes { get; set; }

        //Numero del año de la auditoria. Ej.: 2020
        public int Anio { get; set; }

        [StringLength(5, ErrorMessage = "El formato de la hora tiene que ser HH:MM. Ej.: 09:45")]
        public string Hora { get; set; }

        [NotMapped]
        public int AreaID { get; set; }

        [NotMapped]
        public int ProcesoID { get; set; }

        [NotMapped]
        public int MaquinaID { get; set; }

        [ForeignKey("MaquinaProceso")]
        public int MaquinaProcesoID { get; set; }

        //Nro de orden de produccion, dato obtenido al scannear el codigo de barras
        public string NroOrden { get; set; }

        //Nro de orden de produccion, dato obtenido al scannear el codigo de barras
        public string NroPieza { get; set; }

        //UserId del operario
        [ForeignKey("Operario")]
        public int OperarioID { get; set; }

        //UserId del supervisor
        [ForeignKey("Supervisor")]
        public int SupervisorID { get; set; }

        //UserId del auditor
        public int UserID { get; set; }

        public bool DeBaja { get; set; }

        [DataType(DataType.Date)]
        public DataType FechaBaja { get; set; }

        public int UserBajaID { get; set; }

        public virtual MaquinaProceso MaquinaProceso { get; set; }
        public virtual Operario Operario { get; set; }
        public virtual Operario Supervisor { get; set; }

        [NotMapped]
        public List<DetalleAuditoria> DetallesAuditoria { get; set; }

        //[ForeignKey("Area")]
        //public int AreaID { get; set; }

        //[ForeignKey("Proceso")]
        //public int ProcesoID { get; set; }

        //public virtual Area Area { get; set; }

        //public virtual Proceso Proceso { get; set; }
    }
}

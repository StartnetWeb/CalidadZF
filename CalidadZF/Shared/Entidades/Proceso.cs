﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    [Table("tblProcesos")]
    public class Proceso
    {
        public int ID { get; set; }

        [ForeignKey("Area")]
        public int AreaID { get; set; }

        [StringLength(240, ErrorMessage = "El largo del texto no puede superar 240 Caracteres")]
        public string Descripcion { get; set; }

        public virtual Area Area { get; set; }
    }
}

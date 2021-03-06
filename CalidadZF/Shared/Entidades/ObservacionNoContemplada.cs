﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    public class ObservacionNoContemplada
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public bool ParaLaLinea { get; set; }

        [ForeignKey("AreaResponsable")]
        public int AreaResponsableID { get; set; }

        public string UserID { get; set; }

        public virtual Area AreaResponsable { get; set; }
    }
}

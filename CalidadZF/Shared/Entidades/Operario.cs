﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalidadZF.Shared.Entidades
{
    [Table("tblOperarios")]
    public class Operario
    {
        public int ID { get; set; }

        public bool Auditor { get; set; }

        public bool Supervisor { get; set; }

        [StringLength(4,ErrorMessage = "")]
        public string Legajo { get; set; }

        [StringLength(80, ErrorMessage = "")]
        public string Nombre { get; set; }

        [StringLength(80, ErrorMessage = "")]
        public string Apellido { get; set; }

        public string ApellidoYNombre { get { return Apellido + ", " + Nombre; } }

    }
}

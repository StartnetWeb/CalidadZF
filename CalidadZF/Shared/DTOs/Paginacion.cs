using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadZF.Shared.DTOs
{
    public class Paginacion
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
    }
}

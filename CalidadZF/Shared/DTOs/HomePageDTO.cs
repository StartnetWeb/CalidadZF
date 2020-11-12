using CalidadZF.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadZF.Shared.DTOs
{
    public class HomePageDTO
    {
        public List<Pelicula> PeliculasEnCartelera { get; set; }
        public List<Pelicula> ProximosEstrenos { get; set; }
    }
}

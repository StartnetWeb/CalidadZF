using CalidadZF.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadZF.Shared.DTOs
{
    public class PeliculaActualizacionDTO
    {
        public Pelicula Pelicula { get; set; }
        public List<Persona> Actores { get; set; }
        public List<Genero> GenerosSeleccionados { get; set; }
        public List<Genero> GenerosNoSeleccionados { get; set; }
    }
}

using System.Collections.Generic;
using System.Text.Json;

namespace CalidadZF.Client.Helpers
{
    public class RegistroDbLocal
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public JsonElement Cuerpo { get; set; }
    }

    public class RegistrosDbLocal
    {
        public List<RegistroDbLocal> ObjetosACrear { get; set; } = new List<RegistroDbLocal>();
        public List<RegistroDbLocal> ObjetosABorrar { get; set; } = new List<RegistroDbLocal>();

        public int ObtenerPendientes()
        {
            var resultado = 0;

            resultado += ObjetosACrear.Count;
            resultado += ObjetosABorrar.Count;

            return resultado;
        }

    }
}

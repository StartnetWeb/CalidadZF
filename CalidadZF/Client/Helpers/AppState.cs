using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadZF.Client.Helpers
{
    public class AppState
    {
        public event Func<Task> OnActualizarSincronizacionesPendientes;
        public async Task NotificarActualizarSincronizacionesPendientes() => 
            await OnActualizarSincronizacionesPendientes?.Invoke();
    }
}

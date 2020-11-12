using AutoMapper;
using CalidadFZ.Server.Helpers;
using CalidadFZ.Shared.DTOs;
using CalidadFZ.Shared.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadFZ.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class MaquinasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MaquinasController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Maquina>>> Get()
        {
            return await context.Maquinas.ToListAsync();
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Maquina>>> Get([FromQuery] Paginacion paginacion)
        //{
        //    var queryable = context.Maquinas.AsQueryable();
        //    await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
        //    return await queryable.Paginar(paginacion).ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Maquina>> Get(int id)
        {
            var maquina = await context.Maquinas.FirstOrDefaultAsync(x => x.ID == id);

            if (maquina == null) { return NotFound(); }

            return maquina;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Maquina>>> Get(string textoBusqueda, int? id)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda) || !id.HasValue) { return new List<Maquina>(); }
            textoBusqueda = textoBusqueda.ToLower();

            var maquinasProceso = await context.MaquinasProceso
                .Where(x => x.ProcesoID == id).ToListAsync();

            var maquinasProcesosID = maquinasProceso.Select(x => x.MaquinaID).ToList();

            var maquinas = await context.Maquinas
                .Where(x => maquinasProcesosID.Contains(x.ID) && x.Descripcion.ToLower().Contains(textoBusqueda)).ToListAsync();

            foreach (var maquina in maquinas)
            {
                maquina.ProcesoMaquinaID = maquinasProceso.Where(x => x.MaquinaID == maquina.ID).Select(x => x.ID).FirstOrDefault();
            }

            return maquinas;
        }
    }
}

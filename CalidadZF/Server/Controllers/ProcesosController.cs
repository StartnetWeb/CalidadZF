using AutoMapper;
using CalidadZF.Server.Helpers;
using CalidadZF.Shared.DTOs;
using CalidadZF.Shared.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadZF.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class ProcesosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProcesosController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Proceso>>> Get()
        {
            return await context.Procesos.ToListAsync();
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Proceso>>> Get([FromQuery] Paginacion paginacion)
        //{
        //    var queryable = context.Procesos.AsQueryable();
        //    await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
        //    return await queryable.Paginar(paginacion).ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Proceso>> Get(int id)
        {
            var proceso = await context.Procesos.FirstOrDefaultAsync(x => x.ID == id);

            if (proceso == null) { return NotFound(); }

            return proceso;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Proceso>>> Get(string textoBusqueda, int? id)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda) || !id.HasValue) { return new List<Proceso>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.Procesos
                .Where(x => x.AreaID == id.Value && x.Descripcion.ToLower().Contains(textoBusqueda)).ToListAsync();
        }

    }
}

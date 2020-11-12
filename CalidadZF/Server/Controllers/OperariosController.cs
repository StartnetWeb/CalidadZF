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
    public class OperariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OperariosController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Operario>>> Get()
        {
            return await context.Operarios.ToListAsync();
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Area>>> Get([FromQuery] Paginacion paginacion)
        //{
        //    var queryable = context.Areas.AsQueryable();
        //    await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
        //    return await queryable.Paginar(paginacion).ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Operario>> Get(int id)
        {
            var area = await context.Operarios.FirstOrDefaultAsync(x => x.ID == id);

            if (area == null) { return NotFound(); }

            return area;
        }

        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Operario>>> Get(string textoBusqueda, int? tipoFiltro)
        {
            bool supervisor = false, auditor = false;

            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Operario>(); }

            textoBusqueda = textoBusqueda.ToLower();

            switch (tipoFiltro)
            {
                //Si *tipoFiltro* es 1 estoy buscando un operario que sea supervisor
                case 1:
                    supervisor = true;
                    break;
                //Si *tipoFiltro* es 2 estoy buscando un operario que sea auditor
                case 2:
                    auditor = true;
                    break;
                //Si *tipoFiltro* es null estoy buscando un operario que no sea auditor ni supervisor
                default:
                    break;
            }

            return await context.Operarios
                .Where(x => x.Auditor == auditor && 
                            x.Supervisor == supervisor && 
                            x.Legajo.ToLower().Contains(textoBusqueda)).ToListAsync();
        }
    }
}

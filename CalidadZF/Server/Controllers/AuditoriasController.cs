using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using CalidadZF.Shared.DTOs;
using CalidadZF.Shared.Entidades;
using CalidadZF.Server.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadZF.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class AuditoriasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AuditoriasController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Auditoria>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Auditorias.AsQueryable();

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);

            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AuditoriaDTO>> Get(int id)
        {
            var Auditoria = await context.Auditorias.Where(x => x.ID == id)
                                                    .Include(x => x.MaquinaProceso)
                                                    .Include(x => x.Operario)
                                                    .Include(x => x.Supervisor)
                                                    .FirstOrDefaultAsync();

            if (Auditoria == null) { return NotFound(); }

            Area area = new Area();
            Proceso proceso = new Proceso();
            Maquina maquina = new Maquina();

            if (await context.Procesos.AnyAsync(x => x.ID == Auditoria.MaquinaProceso.ProcesoID))
            {
                proceso = await context.Procesos.Where(x => x.ID == Auditoria.MaquinaProceso.ProcesoID)
                                                .FirstOrDefaultAsync();
            }

            if (await context.Areas.AnyAsync(x => x.ID == proceso.AreaID))
            {
                area = await context.Areas.Where(x => x.ID == proceso.AreaID)
                                          .FirstOrDefaultAsync();
            }

            if (await context.Maquinas.AnyAsync(x => x.ID == Auditoria.MaquinaProceso.MaquinaID))
            {
                maquina = await context.Maquinas.Where(x => x.ID == Auditoria.MaquinaProceso.MaquinaID)
                                                .FirstOrDefaultAsync();
            }

            if (await context.DetallesAuditoria.AnyAsync(x => x.AuditoriaID == id))
            {
                Auditoria.DetallesAuditoria = await context.DetallesAuditoria.Where(x => x.AuditoriaID == id)
                                                                             .ToListAsync();
            }

            var AuditoriaDTO = new AuditoriaDTO();

            AuditoriaDTO.NroOrden = Auditoria.NroOrden;
            AuditoriaDTO.NroPieza = Auditoria.NroPieza;
            AuditoriaDTO.Area = area;
            AuditoriaDTO.Proceso = proceso;
            AuditoriaDTO.Maquina = maquina;
            AuditoriaDTO.Operario = Auditoria.Operario;
            AuditoriaDTO.Supervisor = Auditoria.Supervisor;
            AuditoriaDTO.DetallesAuditoria = Auditoria.DetallesAuditoria;

            return AuditoriaDTO;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Auditoria auditoria)
        {
            context.Add(auditoria);
            await context.SaveChangesAsync();

            int AuditoriaID = auditoria.ID;

            foreach (var detalle in auditoria.DetallesAuditoria)
            {
                detalle.AuditoriaID = AuditoriaID;
            }

            context.DetallesAuditoria.AddRange(auditoria.DetallesAuditoria);
            await context.SaveChangesAsync();

            return auditoria.ID;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Auditoria auditoria)
        {
            //Obtengo el registro de auditoria a modificar
            var auditoriaDB = await context.Auditorias.FirstOrDefaultAsync(x => x.ID == auditoria.ID);

            //Retorno NotFound si no existe el registro de auditoria
            if (auditoriaDB == null) { return NotFound(); }

            //"implementa" cambios en el obejo auditoria en auditoriaDB, para asi guardarlo en la base de datos*
            auditoriaDB = mapper.Map(auditoria, auditoriaDB);

            //Guarda Cambios
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

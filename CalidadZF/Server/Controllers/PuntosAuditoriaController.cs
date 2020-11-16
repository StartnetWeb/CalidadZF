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
    public class PuntosAuditoriaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PuntosAuditoriaController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<PuntoAuditoria>>> Get()
        {
            return await context.PuntosAuditoria.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PuntoAuditoria>> Get(int id)
        {
            var PuntoAuditoria = await context.PuntosAuditoria.FirstOrDefaultAsync(x => x.ID == id);

            if (PuntoAuditoria == null) { return NotFound(); }

            return PuntoAuditoria;
        }
    }
}

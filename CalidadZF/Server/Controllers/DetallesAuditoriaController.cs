using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using CalidadZF.Shared.DTOs;
using CalidadZF.Shared.Entidades;
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
    public class DetallesAuditoriaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DetallesAuditoriaController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<DetalleAuditoria>>> Get(int id)
        {
            List<DetalleAuditoria> detallesAuditoria = new List<DetalleAuditoria>();

            if (await context.DetallesAuditoria.AnyAsync(x => x.AuditoriaID == id))
            {
                detallesAuditoria = await context.DetallesAuditoria.Where(x => x.AuditoriaID == id)
                                                                   .ToListAsync();
            }

            return detallesAuditoria;
        }

        [HttpPut]
        public async Task<ActionResult> Put(DetalleAuditoria detalleAuditoria)
        {
            context.Attach(detalleAuditoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

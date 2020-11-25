﻿using CalidadZF.Shared.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalidadZF.Server
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.GeneroId, x.PeliculaId });
            modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.PeliculaId, x.PersonaId });

            var roleAdminId = "89086180-b978-4f90-9dbd-a7040bc93f41";
            var usuarioAdminId = "8095f754-629b-4a5c-92dd-fbcec41af12d";

            var roleAdmin = new IdentityRole() 
            { Id = roleAdminId, Name = "admin", NormalizedName = "admin" };

            var hasher = new PasswordHasher<IdentityUser>();

            var usuarioAdmin = new IdentityUser()
            {
                Id = usuarioAdminId,
                Email = "felipe@hotmail.com",
                UserName = "felipe@hotmail.com",
                NormalizedUserName = "felipe@hotmail.com",
                NormalizedEmail = "felipe@hotmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "75d8d0f2-398c-46a2-B!d5e-03092cb1d513")
            };

            //modelBuilder.Entity<IdentityUser>().HasData(usuarioAdmin);

            //modelBuilder.Entity<IdentityUserRole<string>>()
            //    .HasData(new IdentityUserRole<string>() { RoleId = roleAdminId, UserId = usuarioAdminId });

            modelBuilder.Entity<IdentityRole>().HasData(roleAdmin);

            modelBuilder.Entity<Genero>().HasData(new Genero()
            { Id = 1, Nombre = "Acción" });

            base.OnModelCreating(modelBuilder);
        }
        //public DbSet<GeneroPelicula> GenerosPeliculas { get; set; }
        //public DbSet<Pelicula> Peliculas { get; set; }
        //public DbSet<Genero> Generos { get; set; }
        //public DbSet<Persona> Personas { get; set; }
        //public DbSet<PeliculaActor> PeliculasActores { get; set; }
        //public DbSet<VotoPelicula> VotosPeliculas { get; set; }
        //public DbSet<Notificacion> Notificaciones { get; set; }

        //Zf
        public DbSet<Operario> Operarios { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Proceso> Procesos { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<MaquinaProceso> MaquinasProceso { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<DetalleAuditoria> DetallesAuditoria { get; set; }
        public DbSet<PuntoAuditoria> PuntosAuditoria { get; set; }
        public DbSet<RespuestaDetalleAuditoria> RespuestasDetalleAuditoria { get; set; }

    }
}

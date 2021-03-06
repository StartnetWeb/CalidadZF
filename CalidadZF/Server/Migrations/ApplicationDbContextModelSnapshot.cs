﻿// <auto-generated />
using System;
using CalidadZF.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalidadZF.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Area", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(240)")
                        .HasMaxLength(240);

                    b.HasKey("ID");

                    b.ToTable("tblAreas");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Auditoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<bool>("DeBaja")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("FechaBaja")
                        .HasColumnType("int");

                    b.Property<string>("Hora")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<int>("MaquinaProcesoID")
                        .HasColumnType("int");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.Property<string>("NroOrden")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroPieza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperarioID")
                        .HasColumnType("int");

                    b.Property<int>("SupervisorID")
                        .HasColumnType("int");

                    b.Property<int>("UserBajaID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MaquinaProcesoID");

                    b.HasIndex("OperarioID");

                    b.HasIndex("SupervisorID");

                    b.ToTable("tblAuditorias");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.DetalleAuditoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuditoriaID")
                        .HasColumnType("int");

                    b.Property<int>("PuntoAuditoriaID")
                        .HasColumnType("int");

                    b.Property<int>("RespuestaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AuditoriaID");

                    b.HasIndex("PuntoAuditoriaID");

                    b.HasIndex("RespuestaID");

                    b.ToTable("tblDetallesAuditoria");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Acción"
                        });
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.GeneroPelicula", b =>
                {
                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.HasKey("GeneroId", "PeliculaId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("GeneroPelicula");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Maquina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(240)")
                        .HasMaxLength(240);

                    b.HasKey("ID");

                    b.ToTable("tblMaquinas");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.MaquinaProceso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaquinaID")
                        .HasColumnType("int");

                    b.Property<int>("ProcesoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MaquinaID");

                    b.HasIndex("ProcesoID");

                    b.ToTable("tblMaquinasProceso");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Operario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<bool>("Auditor")
                        .HasColumnType("bit");

                    b.Property<string>("Legajo")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<bool>("Supervisor")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("tblOperarios");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EnCartelera")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Lanzamiento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resumen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.PeliculaActor", b =>
                {
                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Personaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PeliculaId", "PersonaId");

                    b.HasIndex("PersonaId");

                    b.ToTable("PeliculaActor");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Proceso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaID")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(240)")
                        .HasMaxLength(240);

                    b.HasKey("ID");

                    b.HasIndex("AreaID");

                    b.ToTable("tblProcesos");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.PuntoAuditoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tblPuntosAuditoria");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.RespuestaDetalleAuditoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaseHtml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tblRespuestasDetalleAuditoria");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "89086180-b978-4f90-9dbd-a7040bc93f41",
                            ConcurrencyStamp = "e2d51384-d1dc-402a-95a8-a912664165a4",
                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Auditoria", b =>
                {
                    b.HasOne("CalidadZF.Shared.Entidades.MaquinaProceso", "MaquinaProceso")
                        .WithMany()
                        .HasForeignKey("MaquinaProcesoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalidadZF.Shared.Entidades.Operario", "Operario")
                        .WithMany()
                        .HasForeignKey("OperarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalidadZF.Shared.Entidades.Operario", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.DetalleAuditoria", b =>
                {
                    b.HasOne("CalidadZF.Shared.Entidades.Auditoria", "Auditoria")
                        .WithMany()
                        .HasForeignKey("AuditoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalidadZF.Shared.Entidades.PuntoAuditoria", "PuntoAuditoria")
                        .WithMany()
                        .HasForeignKey("PuntoAuditoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalidadZF.Shared.Entidades.RespuestaDetalleAuditoria", "RespuestaDetalleAuditoria")
                        .WithMany()
                        .HasForeignKey("RespuestaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.GeneroPelicula", b =>
                {
                    b.HasOne("CalidadZF.Shared.Entidades.Genero", "Genero")
                        .WithMany("GeneroPeliculas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalidadZF.Shared.Entidades.Pelicula", "Pelicula")
                        .WithMany("GenerosPelicula")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.MaquinaProceso", b =>
                {
                    b.HasOne("CalidadZF.Shared.Entidades.Maquina", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalidadZF.Shared.Entidades.Proceso", "Proceso")
                        .WithMany()
                        .HasForeignKey("ProcesoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.PeliculaActor", b =>
                {
                    b.HasOne("CalidadZF.Shared.Entidades.Pelicula", "Pelicula")
                        .WithMany("PeliculasActor")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalidadZF.Shared.Entidades.Persona", "Persona")
                        .WithMany("PeliculasActor")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalidadZF.Shared.Entidades.Proceso", b =>
                {
                    b.HasOne("CalidadZF.Shared.Entidades.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

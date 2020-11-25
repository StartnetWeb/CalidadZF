using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalidadZF.Server.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(nullable: false),
                    Resumen = table.Column<string>(nullable: true),
                    EnCartelera = table.Column<bool>(nullable: false),
                    Trailer = table.Column<string>(nullable: true),
                    Lanzamiento = table.Column<DateTime>(nullable: false),
                    Poster = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Biografia = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAreas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAreas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblMaquinas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaquinas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblOperarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auditor = table.Column<bool>(nullable: false),
                    Supervisor = table.Column<bool>(nullable: false),
                    Legajo = table.Column<string>(maxLength: 4, nullable: true),
                    Nombre = table.Column<string>(maxLength: 80, nullable: true),
                    Apellido = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOperarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblPuntosAuditoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPuntosAuditoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblRespuestasDetalleAuditoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    ClaseHtml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRespuestasDetalleAuditoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneroPelicula",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(nullable: false),
                    GeneroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroPelicula", x => new { x.GeneroId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaActor",
                columns: table => new
                {
                    PersonaId = table.Column<int>(nullable: false),
                    PeliculaId = table.Column<int>(nullable: false),
                    Personaje = table.Column<string>(nullable: true),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaActor", x => new { x.PeliculaId, x.PersonaId });
                    table.ForeignKey(
                        name: "FK_PeliculaActor_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaActor_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProcesos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProcesos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblProcesos_tblAreas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "tblAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMaquinasProceso",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcesoID = table.Column<int>(nullable: false),
                    MaquinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMaquinasProceso", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblMaquinasProceso_tblMaquinas_MaquinaID",
                        column: x => x.MaquinaID,
                        principalTable: "tblMaquinas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMaquinasProceso_tblProcesos_ProcesoID",
                        column: x => x.ProcesoID,
                        principalTable: "tblProcesos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblAuditorias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Mes = table.Column<int>(nullable: false),
                    Anio = table.Column<int>(nullable: false),
                    Hora = table.Column<string>(maxLength: 5, nullable: true),
                    MaquinaProcesoID = table.Column<int>(nullable: false),
                    NroOrden = table.Column<string>(nullable: true),
                    NroPieza = table.Column<string>(nullable: true),
                    OperarioID = table.Column<int>(nullable: false),
                    SupervisorID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DeBaja = table.Column<bool>(nullable: false),
                    FechaBaja = table.Column<int>(nullable: false),
                    UserBajaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuditorias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblAuditorias_tblMaquinasProceso_MaquinaProcesoID",
                        column: x => x.MaquinaProcesoID,
                        principalTable: "tblMaquinasProceso",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAuditorias_tblOperarios_OperarioID",
                        column: x => x.OperarioID,
                        principalTable: "tblOperarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tblAuditorias_tblOperarios_SupervisorID",
                        column: x => x.SupervisorID,
                        principalTable: "tblOperarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tblDetallesAuditoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditoriaID = table.Column<int>(nullable: false),
                    RespuestaID = table.Column<int>(nullable: false),
                    PuntoAuditoriaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDetallesAuditoria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblDetallesAuditoria_tblAuditorias_AuditoriaID",
                        column: x => x.AuditoriaID,
                        principalTable: "tblAuditorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDetallesAuditoria_tblPuntosAuditoria_PuntoAuditoriaID",
                        column: x => x.PuntoAuditoriaID,
                        principalTable: "tblPuntosAuditoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDetallesAuditoria_tblRespuestasDetalleAuditoria_RespuestaID",
                        column: x => x.RespuestaID,
                        principalTable: "tblRespuestasDetalleAuditoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89086180-b978-4f90-9dbd-a7040bc93f41", "e2d51384-d1dc-402a-95a8-a912664165a4", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Acción" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroPelicula_PeliculaId",
                table: "GeneroPelicula",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaActor_PersonaId",
                table: "PeliculaActor",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditorias_MaquinaProcesoID",
                table: "tblAuditorias",
                column: "MaquinaProcesoID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditorias_OperarioID",
                table: "tblAuditorias",
                column: "OperarioID");

            migrationBuilder.CreateIndex(
                name: "IX_tblAuditorias_SupervisorID",
                table: "tblAuditorias",
                column: "SupervisorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDetallesAuditoria_AuditoriaID",
                table: "tblDetallesAuditoria",
                column: "AuditoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDetallesAuditoria_PuntoAuditoriaID",
                table: "tblDetallesAuditoria",
                column: "PuntoAuditoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDetallesAuditoria_RespuestaID",
                table: "tblDetallesAuditoria",
                column: "RespuestaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaquinasProceso_MaquinaID",
                table: "tblMaquinasProceso",
                column: "MaquinaID");

            migrationBuilder.CreateIndex(
                name: "IX_tblMaquinasProceso_ProcesoID",
                table: "tblMaquinasProceso",
                column: "ProcesoID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProcesos_AreaID",
                table: "tblProcesos",
                column: "AreaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GeneroPelicula");

            migrationBuilder.DropTable(
                name: "PeliculaActor");

            migrationBuilder.DropTable(
                name: "tblDetallesAuditoria");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "tblAuditorias");

            migrationBuilder.DropTable(
                name: "tblPuntosAuditoria");

            migrationBuilder.DropTable(
                name: "tblRespuestasDetalleAuditoria");

            migrationBuilder.DropTable(
                name: "tblMaquinasProceso");

            migrationBuilder.DropTable(
                name: "tblOperarios");

            migrationBuilder.DropTable(
                name: "tblMaquinas");

            migrationBuilder.DropTable(
                name: "tblProcesos");

            migrationBuilder.DropTable(
                name: "tblAreas");
        }
    }
}

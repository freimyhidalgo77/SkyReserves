using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkyReserves.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesibilidad2",
                columns: table => new
                {
                    AccesibilidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesibilidad2", x => x.AccesibilidadId);
                });

            migrationBuilder.CreateTable(
                name: "Destino2",
                columns: table => new
                {
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino2", x => x.DestinoId);
                });

            migrationBuilder.CreateTable(
                name: "Hora2",
                columns: table => new
                {
                    HoraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaViaje = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hora2", x => x.HoraID);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalida1",
                columns: table => new
                {
                    NacionalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalida1", x => x.NacionalidadId);
                });

            migrationBuilder.CreateTable(
                name: "Origen2",
                columns: table => new
                {
                    OrigenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origen2", x => x.OrigenId);
                });

            migrationBuilder.CreateTable(
                name: "Pago2",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago2", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "Pasaportes2",
                columns: table => new
                {
                    PasaporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisResidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPasaporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmitidoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasaportes2", x => x.PasaporteId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente2",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccesibilidadId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente2", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente2_Accesibilidad2_AccesibilidadId",
                        column: x => x.AccesibilidadId,
                        principalTable: "Accesibilidad2",
                        principalColumn: "AccesibilidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva2",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destino2DestinoId = table.Column<int>(type: "int", nullable: true),
                    Origen2OrigenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva2", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva2_Destino2_Destino2DestinoId",
                        column: x => x.Destino2DestinoId,
                        principalTable: "Destino2",
                        principalColumn: "DestinoId");
                    table.ForeignKey(
                        name: "FK_Reserva2_Origen2_Origen2OrigenId",
                        column: x => x.Origen2OrigenId,
                        principalTable: "Origen2",
                        principalColumn: "OrigenId");
                });

            migrationBuilder.CreateTable(
                name: "Vuelo2",
                columns: table => new
                {
                    VueloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigenId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    NumeroPasajeros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo2", x => x.VueloID);
                    table.ForeignKey(
                        name: "FK_Vuelo2_Destino2_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destino2",
                        principalColumn: "DestinoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelo2_Origen2_OrigenId",
                        column: x => x.OrigenId,
                        principalTable: "Origen2",
                        principalColumn: "OrigenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VuelosEspeciales2",
                columns: table => new
                {
                    VuelosEspecialesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaIda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrigenId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VuelosEspeciales2", x => x.VuelosEspecialesId);
                    table.ForeignKey(
                        name: "FK_VuelosEspeciales2_Destino2_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destino2",
                        principalColumn: "DestinoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VuelosEspeciales2_Origen2_OrigenId",
                        column: x => x.OrigenId,
                        principalTable: "Origen2",
                        principalColumn: "OrigenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasaportesDetalle",
                columns: table => new
                {
                    PasaporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasaportesDetalle", x => x.PasaporteId);
                    table.ForeignKey(
                        name: "FK_PasaportesDetalle_Pasaportes2_PasaporteId",
                        column: x => x.PasaporteId,
                        principalTable: "Pasaportes2",
                        principalColumn: "PasaporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asientos2",
                columns: table => new
                {
                    AsientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VueloId = table.Column<int>(type: "int", nullable: false),
                    Fila = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Existencia = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos2", x => x.AsientoId);
                    table.ForeignKey(
                        name: "FK_Asientos2_Reserva2_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva2",
                        principalColumn: "ReservaId");
                });

            migrationBuilder.CreateTable(
                name: "ClaseVuelo2",
                columns: table => new
                {
                    ClaseVueloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcionClase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseVuelo2", x => x.ClaseVueloId);
                    table.ForeignKey(
                        name: "FK_ClaseVuelo2_Reserva2_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva2",
                        principalColumn: "ReservaId");
                });

            migrationBuilder.CreateTable(
                name: "AsientoDetalles1",
                columns: table => new
                {
                    AsientoDetalleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    AsientoId = table.Column<int>(type: "int", nullable: false),
                    Fila = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsientoDetalles1", x => x.AsientoDetalleID);
                    table.ForeignKey(
                        name: "FK_AsientoDetalles1_Asientos2_AsientoId",
                        column: x => x.AsientoId,
                        principalTable: "Asientos2",
                        principalColumn: "AsientoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsientoDetalles1_Reserva2_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva2",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaseVueloDetalle",
                columns: table => new
                {
                    ClaseVueloDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    ClaseVueloId = table.Column<int>(type: "int", nullable: false),
                    DescripcionClase = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseVueloDetalle", x => x.ClaseVueloDetalleId);
                    table.ForeignKey(
                        name: "FK_ClaseVueloDetalle_ClaseVuelo2_ClaseVueloId",
                        column: x => x.ClaseVueloId,
                        principalTable: "ClaseVuelo2",
                        principalColumn: "ClaseVueloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaseVueloDetalle_Reserva2_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva2",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Asientos2",
                columns: new[] { "AsientoId", "Existencia", "Fila", "Letra", "ReservaId", "VueloId" },
                values: new object[,]
                {
                    { 1, 1, "1", "A", null, 1 },
                    { 2, 1, "2", "B", null, 2 },
                    { 3, 1, "1", "C", null, 3 },
                    { 4, 1, "1", "D", null, 4 },
                    { 5, 1, "1", "E", null, 5 },
                    { 6, 1, "1", "F", null, 6 },
                    { 7, 1, "2", "A", null, 7 },
                    { 8, 1, "2", "B", null, 8 },
                    { 9, 1, "2", "C", null, 9 },
                    { 10, 1, "2", "D", null, 10 },
                    { 11, 1, "2", "E", null, 11 },
                    { 12, 1, "2", "F", null, 12 },
                    { 13, 1, "3", "A", null, 13 },
                    { 14, 1, "3", "B", null, 14 },
                    { 15, 1, "3", "C", null, 15 },
                    { 16, 1, "3", "D", null, 16 },
                    { 17, 1, "3", "E", null, 17 },
                    { 18, 1, "3", "F", null, 18 }
                });

            migrationBuilder.InsertData(
                table: "ClaseVuelo2",
                columns: new[] { "ClaseVueloId", "ReservaId", "descripcionClase" },
                values: new object[,]
                {
                    { 1, null, "Economy Class" },
                    { 2, null, "Bussiness Class" },
                    { 3, null, "Tourist Class" },
                    { 4, null, "Firts Class" },
                    { 5, null, "Smart Class" }
                });

            migrationBuilder.InsertData(
                table: "UserAccount2",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Arajet", "Admin", "Araject@gmail.com" },
                    { 2, "Cliente", "User", "Cliente@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsientoDetalles1_AsientoId",
                table: "AsientoDetalles1",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsientoDetalles1_ReservaId",
                table: "AsientoDetalles1",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos2_ReservaId",
                table: "Asientos2",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseVuelo2_ReservaId",
                table: "ClaseVuelo2",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseVueloDetalle_ClaseVueloId",
                table: "ClaseVueloDetalle",
                column: "ClaseVueloId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseVueloDetalle_ReservaId",
                table: "ClaseVueloDetalle",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente2_AccesibilidadId",
                table: "Cliente2",
                column: "AccesibilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva2_Destino2DestinoId",
                table: "Reserva2",
                column: "Destino2DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva2_Origen2OrigenId",
                table: "Reserva2",
                column: "Origen2OrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo2_DestinoId",
                table: "Vuelo2",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo2_OrigenId",
                table: "Vuelo2",
                column: "OrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_VuelosEspeciales2_DestinoId",
                table: "VuelosEspeciales2",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_VuelosEspeciales2_OrigenId",
                table: "VuelosEspeciales2",
                column: "OrigenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsientoDetalles1");

            migrationBuilder.DropTable(
                name: "ClaseVueloDetalle");

            migrationBuilder.DropTable(
                name: "Cliente2");

            migrationBuilder.DropTable(
                name: "Hora2");

            migrationBuilder.DropTable(
                name: "Nacionalida1");

            migrationBuilder.DropTable(
                name: "Pago2");

            migrationBuilder.DropTable(
                name: "PasaportesDetalle");

            migrationBuilder.DropTable(
                name: "UserAccount2");

            migrationBuilder.DropTable(
                name: "Vuelo2");

            migrationBuilder.DropTable(
                name: "VuelosEspeciales2");

            migrationBuilder.DropTable(
                name: "Asientos2");

            migrationBuilder.DropTable(
                name: "ClaseVuelo2");

            migrationBuilder.DropTable(
                name: "Accesibilidad2");

            migrationBuilder.DropTable(
                name: "Pasaportes2");

            migrationBuilder.DropTable(
                name: "Reserva2");

            migrationBuilder.DropTable(
                name: "Destino2");

            migrationBuilder.DropTable(
                name: "Origen2");
        }
    }
}

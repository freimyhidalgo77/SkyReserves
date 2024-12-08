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
                name: "Accesibilidad",
                columns: table => new
                {
                    AccesibilidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesibilidad", x => x.AccesibilidadId);
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    AsientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fila = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.AsientoId);
                });

            migrationBuilder.CreateTable(
                name: "ClaseVuelo",
                columns: table => new
                {
                    ClaseVueloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcionClase = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseVuelo", x => x.ClaseVueloId);
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
                name: "Hora",
                columns: table => new
                {
                    HoraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaViaje = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hora", x => x.HoraID);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalida",
                columns: table => new
                {
                    NacionalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalida", x => x.NacionalidadId);
                });

            migrationBuilder.CreateTable(
                name: "Origen",
                columns: table => new
                {
                    OrigenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origen", x => x.OrigenId);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
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
                    table.PrimaryKey("PK_Pago", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "Pasaportes",
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
                    table.PrimaryKey("PK_Pasaportes", x => x.PasaporteId);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigenId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
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
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
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
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Accesibilidad_AccesibilidadId",
                        column: x => x.AccesibilidadId,
                        principalTable: "Accesibilidad",
                        principalColumn: "AccesibilidadId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Vuelo2_Origen_OrigenId",
                        column: x => x.OrigenId,
                        principalTable: "Origen",
                        principalColumn: "OrigenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VuelosEspeciales",
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
                    table.PrimaryKey("PK_VuelosEspeciales", x => x.VuelosEspecialesId);
                    table.ForeignKey(
                        name: "FK_VuelosEspeciales_Destino2_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destino2",
                        principalColumn: "DestinoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VuelosEspeciales_Origen_OrigenId",
                        column: x => x.OrigenId,
                        principalTable: "Origen",
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
                        name: "FK_PasaportesDetalle_Pasaportes_PasaporteId",
                        column: x => x.PasaporteId,
                        principalTable: "Pasaportes",
                        principalColumn: "PasaporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsientoDetalles",
                columns: table => new
                {
                    AsientoDetalleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    AsientoId = table.Column<int>(type: "int", nullable: false),
                    Fila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsientoDetalles", x => x.AsientoDetalleID);
                    table.ForeignKey(
                        name: "FK_AsientoDetalles_Asientos_AsientoId",
                        column: x => x.AsientoId,
                        principalTable: "Asientos",
                        principalColumn: "AsientoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsientoDetalles_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
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
                        name: "FK_ClaseVueloDetalle_ClaseVuelo_ClaseVueloId",
                        column: x => x.ClaseVueloId,
                        principalTable: "ClaseVuelo",
                        principalColumn: "ClaseVueloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaseVueloDetalle_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Existencia", "Fila", "Letra" },
                values: new object[,]
                {
                    { 1, 1, "1", "A" },
                    { 2, 1, "2", "B" },
                    { 3, 1, "1", "C" },
                    { 4, 1, "1", "D" },
                    { 5, 1, "1", "E" },
                    { 6, 1, "1", "F" },
                    { 7, 1, "2", "A" },
                    { 8, 1, "2", "B" },
                    { 9, 1, "2", "C" },
                    { 10, 1, "2", "D" },
                    { 11, 1, "2", "E" },
                    { 12, 1, "2", "F" },
                    { 13, 1, "3", "A" },
                    { 14, 1, "3", "B" },
                    { 15, 1, "3", "C" },
                    { 16, 1, "3", "D" },
                    { 17, 1, "3", "E" },
                    { 18, 1, "3", "F" }
                });

            migrationBuilder.InsertData(
                table: "ClaseVuelo",
                columns: new[] { "ClaseVueloId", "descripcionClase" },
                values: new object[,]
                {
                    { 1, "Economy Class" },
                    { 2, "Bussiness Class" },
                    { 3, "Tourist Class" },
                    { 4, "Firts Class" },
                    { 5, "Smart Class" }
                });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Arajet", "Admin", "Araject@gmail.com" },
                    { 2, "Cliente", "User", "Cliente@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsientoDetalles_AsientoId",
                table: "AsientoDetalles",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsientoDetalles_ReservaId",
                table: "AsientoDetalles",
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
                name: "IX_Cliente_AccesibilidadId",
                table: "Cliente",
                column: "AccesibilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo2_DestinoId",
                table: "Vuelo2",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo2_OrigenId",
                table: "Vuelo2",
                column: "OrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_VuelosEspeciales_DestinoId",
                table: "VuelosEspeciales",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_VuelosEspeciales_OrigenId",
                table: "VuelosEspeciales",
                column: "OrigenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsientoDetalles");

            migrationBuilder.DropTable(
                name: "ClaseVueloDetalle");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Hora");

            migrationBuilder.DropTable(
                name: "Nacionalida");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PasaportesDetalle");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "Vuelo2");

            migrationBuilder.DropTable(
                name: "VuelosEspeciales");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "ClaseVuelo");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Accesibilidad");

            migrationBuilder.DropTable(
                name: "Pasaportes");

            migrationBuilder.DropTable(
                name: "Destino2");

            migrationBuilder.DropTable(
                name: "Origen");
        }
    }
}

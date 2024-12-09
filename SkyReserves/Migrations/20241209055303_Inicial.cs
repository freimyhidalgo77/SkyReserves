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
                    VueloId = table.Column<int>(type: "int", nullable: false),
                    Fila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    descripcionClase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseVuelo", x => x.ClaseVueloId);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    DestinoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    destino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.DestinoId);
                });

            migrationBuilder.CreateTable(
                name: "FlightDeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDeals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GenerosId);
                });

            migrationBuilder.CreateTable(
                name: "Hora",
                columns: table => new
                {
                    HoraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hora", x => x.HoraID);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidad",
                columns: table => new
                {
                    NacionalidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidad", x => x.NacionalidadId);
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
                    ClaseVueloId = table.Column<int>(type: "int", nullable: false),
                    TarjetaNumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    MontoPagar = table.Column<double>(type: "float", nullable: false)
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
                    NombrePila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccesibilidadId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasaportes", x => x.PasaporteId);
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
                name: "Clientes",
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
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Accesibilidad_AccesibilidadId",
                        column: x => x.AccesibilidadId,
                        principalTable: "Accesibilidad",
                        principalColumn: "AccesibilidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigenId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    NumeroPasajeros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_Destino_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destino",
                        principalColumn: "DestinoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Origen_OrigenId",
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
                        name: "FK_VuelosEspeciales_Destino_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Destino",
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
                name: "PasaporteDetalles",
                columns: table => new
                {
                    PasaporteId = table.Column<int>(type: "int", nullable: false),
                    PaisResidencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPasaporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpendidoPor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadNatal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasaporteDetalles", x => x.PasaporteId);
                    table.ForeignKey(
                        name: "FK_PasaporteDetalles_Pasaportes_PasaporteId",
                        column: x => x.PasaporteId,
                        principalTable: "Pasaportes",
                        principalColumn: "PasaporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Asientos",
                columns: new[] { "AsientoId", "Existencia", "Fila", "Letra", "VueloId" },
                values: new object[,]
                {
                    { 1, 5, "1", "A", 1 },
                    { 2, 5, "2", "B", 1 }
                });

            migrationBuilder.InsertData(
                table: "FlightDeals",
                columns: new[] { "Id", "Description", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "Como administrador, aquí podrás gestionar la configuración: crear, editar o eliminar de manera eficiente.", "/Imagenes/Timer.png " },
                    { 2, "Como administrador, aquí podrás gestionar la configuración: crear, editar o eliminar de manera eficiente.", "/Imagenes/Clase.jpeg" },
                    { 3, "Como administrador, aquí podrás gestionar la configuración: crear, editar o eliminar de manera eficiente.", "/Imagenes/Accesibilidad.png" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GenerosId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Femenino" },
                    { 3, "Prefiero no decirlo" }
                });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Arajet", "Admin", "Arajet@gmail.com" },
                    { 2, "Cliente", "User", "Cliente@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_AccesibilidadId",
                table: "Clientes",
                column: "AccesibilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_DestinoId",
                table: "Reserva",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_OrigenId",
                table: "Reserva",
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
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "ClaseVuelo");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "FlightDeals");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Hora");

            migrationBuilder.DropTable(
                name: "Nacionalidad");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PasaporteDetalles");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "VuelosEspeciales");

            migrationBuilder.DropTable(
                name: "Accesibilidad");

            migrationBuilder.DropTable(
                name: "Pasaportes");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Origen");
        }
    }
}

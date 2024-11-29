﻿using System;
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
                name: "ClaseVuelo",
                columns: table => new
                {
                    ClaseVueloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcionClase = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    PasaporteId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    AsientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.AsientoId);
                    table.ForeignKey(
                        name: "FK_Asientos_Reserva_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reserva",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsientoDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsientoId = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    Fila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsientoDetalles", x => x.DetalleId);
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

            migrationBuilder.InsertData(
                table: "AsientoDetalles",
                columns: new[] { "DetalleId", "AsientoId", "Existencia", "Fila", "Letra", "ReservaId" },
                values: new object[,]
                {
                    { 1, 1, 1, "1", "A", 0 },
                    { 2, 2, 1, "1", "B", 0 },
                    { 3, 3, 1, "2", "C", 0 },
                    { 4, 4, 3, "2", "D", 0 },
                    { 5, 5, 1, "3", "A", 0 },
                    { 6, 6, 1, "3", "B", 0 },
                    { 7, 7, 1, "4", "C", 0 },
                    { 8, 8, 3, "4", "D", 0 },
                    { 9, 9, 1, " 5", "A", 0 },
                    { 10, 10, 1, "5", "B", 0 },
                    { 11, 11, 1, "6", "C", 0 },
                    { 12, 12, 3, "6", "D", 0 },
                    { 13, 13, 1, "7", "A", 0 },
                    { 14, 14, 1, "7", "B", 0 },
                    { 15, 15, 1, "8", "C", 0 },
                    { 16, 16, 3, "8", "D", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Will04", "Admin", "Wilmer" },
                    { 2, "Perez05", "User", "Juan" }
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
                name: "IX_Asientos_ReservaId",
                table: "Asientos",
                column: "ReservaId");

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
                name: "AsientoDetalles");

            migrationBuilder.DropTable(
                name: "ClaseVuelo");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Hora");

            migrationBuilder.DropTable(
                name: "Nacionalidad");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PasaporteDetalles");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "VuelosEspeciales");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Accesibilidad");

            migrationBuilder.DropTable(
                name: "Pasaportes");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Destino");

            migrationBuilder.DropTable(
                name: "Origen");
        }
    }
}

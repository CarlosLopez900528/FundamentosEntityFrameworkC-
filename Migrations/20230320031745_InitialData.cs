using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myproject.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("43ebe791-deae-43e5-815d-e74ba2f91a02"), "Esta es la decripcion de + Actividades personales", "Actividades personales", 50 },
                    { new Guid("43ebe791-deae-43e5-815d-e74ba2f91a11"), "Esta es la decripcion de + Actividades pendientes", "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("43ebe791-deae-43e5-815d-e74ba2f91587"), new Guid("43ebe791-deae-43e5-815d-e74ba2f91a11"), "Necesito aprender acerca de Graphql", new DateTime(2023, 3, 19, 22, 17, 45, 235, DateTimeKind.Local).AddTicks(9419), 1, "Aprender Graphql" },
                    { new Guid("43ebe791-deae-43e5-815d-e74ba2f91965"), new Guid("43ebe791-deae-43e5-815d-e74ba2f91a02"), "Necesito aprender acerca de React", new DateTime(2023, 3, 19, 22, 17, 45, 235, DateTimeKind.Local).AddTicks(9441), 0, "Aprender React" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("43ebe791-deae-43e5-815d-e74ba2f91587"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("43ebe791-deae-43e5-815d-e74ba2f91965"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("43ebe791-deae-43e5-815d-e74ba2f91a02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("43ebe791-deae-43e5-815d-e74ba2f91a11"));
        }
    }
}

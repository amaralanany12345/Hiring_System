using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiring.Migrations
{
    /// <inheritdoc />
    public partial class employeeVacancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeVacancies",
                columns: table => new
                {
                    vacancyId = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    vacancyState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVacancies", x => new { x.vacancyId, x.employeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeVacancies_employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeVacancies_vacancies_vacancyId",
                        column: x => x.vacancyId,
                        principalTable: "vacancies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVacancies_employeeId",
                table: "EmployeeVacancies",
                column: "employeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVacancies");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiring.Migrations
{
    /// <inheritdoc />
    public partial class companyEmailAndPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVS_employees_employeeId",
                table: "CVS");

            migrationBuilder.AddColumn<string>(
                name: "companyEmail",
                table: "companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "companyPassword",
                table: "companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CVS_employees_employeeId",
                table: "CVS",
                column: "employeeId",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVS_employees_employeeId",
                table: "CVS");

            migrationBuilder.DropColumn(
                name: "companyEmail",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "companyPassword",
                table: "companies");

            migrationBuilder.AddForeignKey(
                name: "FK_CVS_employees_employeeId",
                table: "CVS",
                column: "employeeId",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

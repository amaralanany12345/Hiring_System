using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hiring.Migrations
{
    /// <inheritdoc />
    public partial class cv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "employeeCvId",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CVS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVS", x => x.id);
                    table.ForeignKey(
                        name: "FK_CVS_employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVS_employeeId",
                table: "CVS",
                column: "employeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVS");

            migrationBuilder.DropColumn(
                name: "employeeCvId",
                table: "employees");
        }
    }
}

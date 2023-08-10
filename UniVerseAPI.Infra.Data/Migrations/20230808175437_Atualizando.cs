using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniVerseAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Atualizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Course",
                type: "CHAR(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Course",
                type: "CHAR(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(6)");
        }
    }
}

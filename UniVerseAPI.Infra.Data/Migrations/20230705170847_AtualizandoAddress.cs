using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniVerseAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__People__C1FF9309991D9366",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "AddressEntity",
                type: "INT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "AddressEntity",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.CreateIndex(
                name: "UQ__People__C1FF9309991D9366",
                table: "People",
                column: "Cpf",
                unique: true);
        }
    }
}

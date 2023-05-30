using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniVerseAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressEntity",
                table: "AddressEntity");

            migrationBuilder.RenameTable(
                name: "AddressEntity",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "AddressEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressEntity",
                table: "AddressEntity",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniVerseAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReformulandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Teacher",
                type: "BIT",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "false");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Teacher",
                type: "BIT",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Subject",
                type: "BIT",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "false");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Subject",
                type: "BIT",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Student",
                type: "BIT",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "false");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Student",
                type: "BIT",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "People",
                type: "BIT",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "false");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "People",
                type: "BIT",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Course",
                type: "BIT",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "false");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Course",
                type: "BIT",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Class",
                type: "BIT",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "false");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Class",
                type: "BIT",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "AddressEntity",
                type: "BIT",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "false");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "AddressEntity",
                type: "BIT",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "true");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Teacher",
                type: "BIT",
                nullable: false,
                defaultValueSql: "false",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Teacher",
                type: "BIT",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Subject",
                type: "BIT",
                nullable: false,
                defaultValueSql: "false",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Subject",
                type: "BIT",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Student",
                type: "BIT",
                nullable: false,
                defaultValueSql: "false",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Student",
                type: "BIT",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "People",
                type: "BIT",
                nullable: false,
                defaultValueSql: "false",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "People",
                type: "BIT",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Course",
                type: "BIT",
                nullable: false,
                defaultValueSql: "false",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Course",
                type: "BIT",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Class",
                type: "BIT",
                nullable: false,
                defaultValueSql: "false",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Class",
                type: "BIT",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "AddressEntity",
                type: "BIT",
                nullable: false,
                defaultValueSql: "false",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "AddressEntity",
                type: "BIT",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValueSql: "1");
        }
    }
}

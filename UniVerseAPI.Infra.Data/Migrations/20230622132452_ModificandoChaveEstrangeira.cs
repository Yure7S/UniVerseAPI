using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniVerseAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoChaveEstrangeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "GroupStudentClass_fk2",
                table: "GroupStudentClass");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudentClass_ClassId",
                table: "GroupStudentClass",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "GroupStudentClass_fk2",
                table: "GroupStudentClass",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "GroupStudentClass_fk2",
                table: "GroupStudentClass");

            migrationBuilder.DropIndex(
                name: "IX_GroupStudentClass_ClassId",
                table: "GroupStudentClass");

            migrationBuilder.AddForeignKey(
                name: "GroupStudentClass_fk2",
                table: "GroupStudentClass",
                column: "StudentId",
                principalTable: "Class",
                principalColumn: "Id");
        }
    }
}

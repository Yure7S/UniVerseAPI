using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniVerseAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class revolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "GroupStudentClass_fk0",
                table: "GroupStudentClass");

            migrationBuilder.DropForeignKey(
                name: "GroupStudentClass_fk2",
                table: "GroupStudentClass");

            migrationBuilder.DropIndex(
                name: "IX_GroupStudentClass_ClassId",
                table: "GroupStudentClass");

            migrationBuilder.DropIndex(
                name: "IX_GroupStudentClass_StudentId",
                table: "GroupStudentClass");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "GroupStudentClass");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "GroupStudentClass");

            migrationBuilder.CreateTable(
                name: "ClassStudent",
                columns: table => new
                {
                    ClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudent", x => new { x.ClassesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ClassStudent_Class_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_StudentsId",
                table: "ClassStudent",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudent");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                table: "GroupStudentClass",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "GroupStudentClass",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudentClass_ClassId",
                table: "GroupStudentClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudentClass_StudentId",
                table: "GroupStudentClass",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "GroupStudentClass_fk0",
                table: "GroupStudentClass",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "GroupStudentClass_fk2",
                table: "GroupStudentClass",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id");
        }
    }
}

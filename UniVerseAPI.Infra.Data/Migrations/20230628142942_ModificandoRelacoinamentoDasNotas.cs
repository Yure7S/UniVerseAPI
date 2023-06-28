using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniVerseAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoRelacoinamentoDasNotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Grades_fk0",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "Student_fk0",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "Subject_fk3",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropTable(
                name: "GroupStudentClass");

            migrationBuilder.DropTable(
                name: "ReportCard");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropIndex(
                name: "IX_Subject_PeriodId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Student_ReportCardId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "AssessmentId",
                table: "Grades",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_AssessmentId",
                table: "Grades",
                newName: "IX_Grades_SubjectId");

            migrationBuilder.AddColumn<decimal>(
                name: "FinalExameGrade",
                table: "Grades",
                type: "DECIMAL(18,0)",
                nullable: true,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<decimal>(
                name: "FirstNote",
                table: "Grades",
                type: "DECIMAL(18,0)",
                nullable: true,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<decimal>(
                name: "SecondNote",
                table: "Grades",
                type: "DECIMAL(18,0)",
                nullable: true,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Grades",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "TookFinalExame",
                table: "Grades",
                type: "BIT",
                nullable: true,
                defaultValueSql: "0");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "Grades_fk0",
                table: "Grades",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Grades_fk1",
                table: "Grades",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Grades_fk0",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "Grades_fk1",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "FinalExameGrade",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "FirstNote",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SecondNote",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TookFinalExame",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Grades",
                newName: "AssessmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                newName: "IX_Grades_AssessmentId");

            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "Grades",
                type: "decimal(18,0)",
                nullable: true,
                defaultValueSql: "0");

            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.Id);
                    table.ForeignKey(
                        name: "Assessment_fk0",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupStudentClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudentClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    EnrolledStudents = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GRADES",
                        column: x => x.GradesId,
                        principalTable: "Grades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PERIOD",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SUBJECT",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_PeriodId",
                table: "Subject",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ReportCardId",
                table: "Student",
                column: "ReportCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_SubjectId",
                table: "Assessment",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCard_GradesId",
                table: "ReportCard",
                column: "GradesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCard_PeriodId",
                table: "ReportCard",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCard_SubjectId",
                table: "ReportCard",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "Grades_fk0",
                table: "Grades",
                column: "AssessmentId",
                principalTable: "Assessment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Student_fk0",
                table: "Student",
                column: "ReportCardId",
                principalTable: "ReportCard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Subject_fk3",
                table: "Subject",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id");
        }
    }
}

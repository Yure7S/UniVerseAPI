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
            migrationBuilder.DropForeignKey(
                name: "Assessment_fk0",
                table: "Assessment");

            migrationBuilder.DropForeignKey(
                name: "Grades_fk0",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "People_fk0",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_GRADES",
                table: "ReportCard");

            migrationBuilder.DropForeignKey(
                name: "FK_PERIOD",
                table: "ReportCard");

            migrationBuilder.DropForeignKey(
                name: "FK_SUBJECT",
                table: "ReportCard");

            migrationBuilder.DropForeignKey(
                name: "Student_fk0",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "Student_fk1",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "Student_fk2",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "Subject_fk0",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "Subject_fk1",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "Subject_fk2",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "Subject_fk3",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "Teacher_fk0",
                table: "Teacher");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Subject",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "People",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "Grades",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Address",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 8);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessment_Subject_SubjectId",
                table: "Assessment",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Assessment_AssessmentId",
                table: "Grades",
                column: "AssessmentId",
                principalTable: "Assessment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Address_AddressId",
                table: "People",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportCard_Grades_GradesId",
                table: "ReportCard",
                column: "GradesId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportCard_Period_PeriodId",
                table: "ReportCard",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportCard_Subject_SubjectId",
                table: "ReportCard",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_People_PeopleId",
                table: "Student",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_ReportCard_ReportCardId",
                table: "Student",
                column: "ReportCardId",
                principalTable: "ReportCard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Class_ClassId",
                table: "Subject",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Course_CourseId",
                table: "Subject",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Period_PeriodId",
                table: "Subject",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_People_PeopleId",
                table: "Teacher",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessment_Subject_SubjectId",
                table: "Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Assessment_AssessmentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Address_AddressId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportCard_Grades_GradesId",
                table: "ReportCard");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportCard_Period_PeriodId",
                table: "ReportCard");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportCard_Subject_SubjectId",
                table: "ReportCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_People_PeopleId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_ReportCard_ReportCardId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Class_ClassId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Course_CourseId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Period_PeriodId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_People_PeopleId",
                table: "Teacher");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Subject",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "People",
                type: "char(11)",
                unicode: false,
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "Grades",
                type: "decimal(18,0)",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Address",
                type: "char(8)",
                unicode: false,
                fixedLength: true,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldUnicode: false,
                oldMaxLength: 8);

            migrationBuilder.AddForeignKey(
                name: "Assessment_fk0",
                table: "Assessment",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Grades_fk0",
                table: "Grades",
                column: "AssessmentId",
                principalTable: "Assessment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "People_fk0",
                table: "People",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GRADES",
                table: "ReportCard",
                column: "GradesId",
                principalTable: "Grades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PERIOD",
                table: "ReportCard",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SUBJECT",
                table: "ReportCard",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Student_fk0",
                table: "Student",
                column: "ReportCardId",
                principalTable: "ReportCard",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Student_fk1",
                table: "Student",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Student_fk2",
                table: "Student",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Subject_fk0",
                table: "Subject",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Subject_fk1",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Subject_fk2",
                table: "Subject",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Subject_fk3",
                table: "Subject",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Teacher_fk0",
                table: "Teacher",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}

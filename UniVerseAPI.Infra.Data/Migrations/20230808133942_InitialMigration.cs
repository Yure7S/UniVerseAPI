using System;
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
            migrationBuilder.CreateTable(
                name: "AddressEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressValue = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Cep = table.Column<string>(type: "CHAR(8)", fixedLength: true, nullable: false),
                    Deleted = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "1"),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Code = table.Column<string>(type: "CHAR(5)", nullable: false),
                    Shift = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Room = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Deleted = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "1"),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    ShortDescription = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(2000)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    SpotsAvailable = table.Column<int>(type: "INT", nullable: false),
                    Price = table.Column<int>(type: "INT", nullable: false),
                    Category = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Code = table.Column<string>(type: "CHAR(10)", nullable: false),
                    Deleted = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "1"),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleValue = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    RefreshToken = table.Column<string>(type: "CHAR(64)", nullable: true),
                    RefreshTokenValidity = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Deleted = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "1"),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "User_fk0",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Cpf = table.Column<string>(type: "CHAR(11)", fixedLength: true, nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Phone = table.Column<string>(type: "CHAR(11)", nullable: false),
                    Deleted = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "1"),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "People_fk0",
                        column: x => x.AddressId,
                        principalTable: "AddressEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "People_fk1",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Registration = table.Column<string>(type: "CHAR(10)", nullable: false),
                    Deleted = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "1"),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "Student_fk1",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Student_fk2",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "CHAR(10)", nullable: false),
                    Deleted = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "1"),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "Teacher_fk0",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FullName = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Code = table.Column<string>(type: "CHAR(10)", fixedLength: true, nullable: false),
                    Workload = table.Column<DateTime>(type: "DATE", nullable: false),
                    Deleted = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Active = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "1"),
                    CreationDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "Subject_fk0",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Subject_fk1",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Subject_fk2",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstNote = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: true, defaultValueSql: "0"),
                    SecondNote = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: true, defaultValueSql: "0"),
                    TookFinalExame = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "0"),
                    FinalExameGrade = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: true, defaultValueSql: "0"),
                    Approved = table.Column<bool>(type: "BIT", nullable: false, defaultValueSql: "0"),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "Grades_fk0",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Grades_fk1",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_StudentsId",
                table: "ClassStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressId",
                table: "People",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserId",
                table: "People",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PeopleId",
                table: "Student",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_ClassId",
                table: "Subject",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CourseId",
                table: "Subject",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_PeopleId",
                table: "Teacher",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudent");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "AddressEntity");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniVerseAPI.Infra.Data.Context;

#nullable disable

namespace UniVerseAPI.Infra.Data.Migrations
{
    [DbContext(typeof(UniDBContext))]
    partial class UniDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Address");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .IsFixedLength();

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Assessment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Assessment");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EnrolledStudents")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Shift")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("SpotsAvailable")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Grades", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssessmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Grade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 0)")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.People", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .IsFixedLength();

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex(new[] { "Cpf" }, "UQ__People__C1FF9309991D9366")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EnrolledStudents")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Period");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.ReportCard", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GradesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GradesId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ReportCard");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PeopleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Registration")
                        .HasColumnType("int");

                    b.Property<Guid>("ReportCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("PeopleId");

                    b.HasIndex("ReportCardId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Instructor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Workload")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("PeopleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId");

                    b.HasIndex(new[] { "Code" }, "UQ__Teacher__A25C5AA792072F3C")
                        .IsUnique();

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Assessment", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Subject", "Subject")
                        .WithMany("Assessment")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("Assessment_fk0");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Grades", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Assessment", "Assessment")
                        .WithMany("Grades")
                        .HasForeignKey("AssessmentId")
                        .IsRequired()
                        .HasConstraintName("Grades_fk0");

                    b.Navigation("Assessment");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.People", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Address", "Address")
                        .WithMany("People")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("People_fk0");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.ReportCard", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Grades", "Grades")
                        .WithMany("ReportCard")
                        .HasForeignKey("GradesId")
                        .IsRequired()
                        .HasConstraintName("FK_GRADES");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Period", "Period")
                        .WithMany("ReportCard")
                        .HasForeignKey("PeriodId")
                        .IsRequired()
                        .HasConstraintName("FK_PERIOD");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Subject", "Subject")
                        .WithMany("ReportCard")
                        .HasForeignKey("SubjectId")
                        .IsRequired()
                        .HasConstraintName("FK_SUBJECT");

                    b.Navigation("Grades");

                    b.Navigation("Period");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Student", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Course", "Course")
                        .WithMany("Student")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("Student_fk2");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.People", "People")
                        .WithMany("Student")
                        .HasForeignKey("PeopleId")
                        .IsRequired()
                        .HasConstraintName("Student_fk1");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.ReportCard", "ReportCard")
                        .WithMany("Student")
                        .HasForeignKey("ReportCardId")
                        .IsRequired()
                        .HasConstraintName("Student_fk0");

                    b.Navigation("Course");

                    b.Navigation("People");

                    b.Navigation("ReportCard");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Subject", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Class", "Class")
                        .WithMany("Subject")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("Subject_fk2");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Course", "Course")
                        .WithMany("Subject")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("Subject_fk0");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Period", "Period")
                        .WithMany("Subject")
                        .HasForeignKey("PeriodId")
                        .IsRequired()
                        .HasConstraintName("Subject_fk3");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Teacher", "Teacher")
                        .WithMany("Subject")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("Subject_fk1");

                    b.Navigation("Class");

                    b.Navigation("Course");

                    b.Navigation("Period");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Teacher", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.People", "People")
                        .WithMany("Teacher")
                        .HasForeignKey("PeopleId")
                        .IsRequired()
                        .HasConstraintName("Teacher_fk0");

                    b.Navigation("People");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Address", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Assessment", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Class", b =>
                {
                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Course", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Grades", b =>
                {
                    b.Navigation("ReportCard");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.People", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Period", b =>
                {
                    b.Navigation("ReportCard");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.ReportCard", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Subject", b =>
                {
                    b.Navigation("Assessment");

                    b.Navigation("ReportCard");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Teacher", b =>
                {
                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}

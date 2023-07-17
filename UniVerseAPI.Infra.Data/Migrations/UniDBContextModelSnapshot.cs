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

            modelBuilder.Entity("ClassStudent", b =>
                {
                    b.Property<Guid>("ClassesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClassesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ClassStudent");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("1");

                    b.Property<string>("AddressValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("CHAR(8)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("Number")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("AddressEntity", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Code")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("CHAR(5)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Class", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("CHAR(10)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME2");

                    b.Property<int>("Price")
                        .HasColumnType("INT");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("SpotsAvailable")
                        .HasColumnType("INT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("DATETIME2");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Grades", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Approved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("FinalExameGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL")
                        .HasDefaultValueSql("0");

                    b.Property<decimal?>("FirstNote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("SecondNote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL")
                        .HasDefaultValueSql("0");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("TookFinalExame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.People", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("1");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("CHAR(11)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("People", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Roles", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("RoleValue")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("1");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME2");

                    b.Property<Guid>("PeopleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("CHAR(10)");

                    b.Property<Guid?>("ReportCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("PeopleId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("1");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("CHAR(10)")
                        .IsFixedLength();

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME2");

                    b.Property<Guid?>("PeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Workload")
                        .HasColumnType("DATE");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Code")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("CHAR(10)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME2");

                    b.Property<Guid>("PeopleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PeopleId");

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("DATETIME2");

                    b.Property<bool?>("Deleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("CHAR(64)");

                    b.Property<DateTime>("RefreshTokenValidity")
                        .HasColumnType("DATETIME2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ClassStudent", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Grades", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Grades_fk0");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Grades_fk1");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.People", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.AddressEntity", "AddressEntity")
                        .WithMany("People")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("People_fk0");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.User", "User")
                        .WithOne("People")
                        .HasForeignKey("UniVerseAPI.Infra.Data.Context.People", "UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("People_fk1");

                    b.Navigation("AddressEntity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Student", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Course", "Course")
                        .WithMany("Student")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("Student_fk2");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.People", "People")
                        .WithMany("Student")
                        .HasForeignKey("PeopleId")
                        .IsRequired()
                        .HasConstraintName("Student_fk1");

                    b.Navigation("Course");

                    b.Navigation("People");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Subject", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Class", "Class")
                        .WithMany("Subject")
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("Subject_fk2");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Course", "Course")
                        .WithMany("Subject")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("Subject_fk0");

                    b.HasOne("UniVerseAPI.Infra.Data.Context.Teacher", "Teacher")
                        .WithMany("Subject")
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("Subject_fk1");

                    b.Navigation("Class");

                    b.Navigation("Course");

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

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.User", b =>
                {
                    b.HasOne("UniVerseAPI.Infra.Data.Context.Roles", "Roles")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("User_fk0");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.AddressEntity", b =>
                {
                    b.Navigation("People");
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

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.People", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Roles", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Subject", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.Teacher", b =>
                {
                    b.Navigation("Subject");
                });

            modelBuilder.Entity("UniVerseAPI.Infra.Data.Context.User", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}

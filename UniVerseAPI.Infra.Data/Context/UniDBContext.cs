
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using UniVerseAPI.Domain.Entities.MasterEntities;
using UniVerseAPI.Infra.Data.Repositories;

namespace UniVerseAPI.Infra.Data.Context
{
    public class UniDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public UniDBContext(DbContextOptions<UniDBContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<AddressEntity> AddressEntity { get; set; }
        public virtual DbSet<Assessment> Assessment { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<ReportCard> ReportCard { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<GroupStudentClass> GroupStudentClass { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cep).IsFixedLength();
            });

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Assessment)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("Assessment_fk0");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

            });

            modelBuilder.Entity<GroupStudentClass>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.GroupStudentClass)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GroupStudentClass_fk0");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.GroupStudentClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GroupStudentClass_fk2");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Grades>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Grade).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.AssessmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Grades_fk0");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cpf).IsFixedLength();

                entity.HasOne(d => d.AddressEntity)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("People_fk0");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ReportCard>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Grades)
                    .WithMany(p => p.ReportCard)
                    .HasForeignKey(d => d.GradesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GRADES");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.ReportCard)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERIOD");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ReportCard)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SUBJECT");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_fk2");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_fk1");

                entity.HasOne(d => d.ReportCard)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.ReportCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_fk0");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsFixedLength();


                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subject_fk0");
               
                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subject_fk1");
                
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subject_fk2");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Subject_fk3");

            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Teacher_fk0");
            });

        }

    }
}
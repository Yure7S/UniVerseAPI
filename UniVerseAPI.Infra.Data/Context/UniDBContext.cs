
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using NPOI.SS.Formula.Functions;
using UniVerseAPI.Infra.Data.Context;
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
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

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

                entity.ToTable("AddressEntity");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.AddressValue).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.Number).HasColumnType("INT").IsRequired();
                entity.Property(e => e.Neighborhood).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.Cep).HasColumnType("CHAR(8)").IsRequired();
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasMany(p => p.Students)
                  .WithMany(c => c.Classes);

                entity.ToTable("Class");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.Code).HasColumnType("CHAR(5)").IsUnicode(true).IsRequired();
                entity.Property(e => e.Shift).HasColumnType("VARCHAR(50)").IsRequired();
                entity.Property(e => e.Room).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.FullName).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.ShortDescription).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.Description).HasColumnType("VARCHAR(2000)").IsRequired();
                entity.Property(e => e.StartDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.EndDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.SpotsAvailable).HasColumnType("INT").IsRequired();
                entity.Property(e => e.Price).HasColumnType("INT").IsRequired();
                entity.Property(e => e.Category).HasColumnType("VARCHAR(100)").IsRequired();
                entity.Property(e => e.Code).HasColumnType("CHAR(6)").IsUnicode(true).IsRequired();
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.Deleted).HasColumnType("BIT").HasDefaultValueSql("0").IsRequired();
                entity.Property(e => e.Active).HasColumnType("BIT").HasDefaultValueSql("1").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

            });

            modelBuilder.Entity<Grades>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.ToTable("Grades");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstNote).HasColumnType("DECIMAL").HasDefaultValueSql("0");
                entity.Property(e => e.SecondNote).HasColumnType("DECIMAL").HasDefaultValueSql("0");
                entity.Property(e => e.TookFinalExame).HasColumnType("BIT").HasDefaultValueSql("0");
                entity.Property(e => e.FinalExameGrade).HasColumnType("DECIMAL").HasDefaultValueSql("0");
                entity.Property(e => e.Approved).HasColumnType("BIT").HasDefaultValueSql("0");
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

                entity.HasOne(e => e.Student)
                    .WithMany(e => e.Grades)
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Grades_fk0");

                entity.HasOne(e => e.Subject)
                    .WithMany(e => e.Grades)
                    .HasForeignKey(e => e.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Grades_fk1");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cpf).IsFixedLength();

                entity.HasOne(d => d.AddressEntity)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("People_fk0");

                entity.HasOne(p => p.User)
                    .WithOne(p => p.People)
                    .HasForeignKey<People>(p => p.UserId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("People_fk1");

                entity.ToTable("People");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.BirthDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.Cpf).HasColumnType("CHAR(11)").IsUnicode(true).IsRequired();
                entity.Property(e => e.Phone).HasColumnType("CHAR(11)").IsRequired();
                entity.Property(e => e.Gender).HasColumnType("VARCHAR(50)").IsRequired();
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_fk0");

                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).HasColumnType("VARCHAR(100)").IsRequired();
                entity.Property(e => e.Password).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.RefreshToken).HasColumnType("CHAR(64)");
                entity.Property(e => e.RefreshTokenValidity).HasColumnType("DATETIME2");
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.Deleted).HasColumnType("BIT").HasDefaultValueSql("0").IsRequired();
                entity.Property(e => e.Active).HasColumnType("BIT").HasDefaultValueSql("1").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.ToTable("Roles");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RoleValue).HasColumnType("VARCHAR(150)").IsRequired();
                entity.Property(e => e.Description).HasColumnType("VARCHAR(255)").IsRequired();
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

                entity.ToTable("Student");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Registration).HasColumnType("CHAR(10)").IsUnicode(true).IsRequired();
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.Deleted).HasColumnType("BIT").HasDefaultValueSql("0").IsRequired();
                entity.Property(e => e.Active).HasColumnType("BIT").HasDefaultValueSql("1").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

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

                entity.ToTable("Subject");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.Description).HasColumnType("VARCHAR(255)").IsRequired();
                entity.Property(e => e.Code).HasColumnType("CHAR(10)").IsUnicode(true).IsRequired();
                entity.Property(e => e.Workload).HasColumnType("DATE").IsRequired();
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Teacher_fk0");

                entity.ToTable("Teacher");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).HasColumnType("CHAR(6)").IsUnicode(true).IsRequired();
                entity.Property(e => e.CreationDate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.LastUpdate).HasColumnType("DATETIME2").IsRequired();
                entity.Property(e => e.Deleted).HasColumnType("BIT").HasDefaultValueSql("0").IsRequired();
                entity.Property(e => e.Active).HasColumnType("BIT").HasDefaultValueSql("1").IsRequired();
                entity.Property(e => e.NumberOfUpdates).HasColumnType("INT").IsRequired();

            });

        }

    }
}

// SQL Scripts

// Admin:
/*
 * 
     INSERT INTO[User] (
          [Id],
          [RoleId]
          ,[Email]
          ,[Password]
          ,[RefreshTokenValidity]
          ,[Deleted]
          ,[Active]
          ,[CreationDate]
          ,[LastUpdate],
          [NumberOfUpdates])
    VALUES(
        NEWID(),
        'd111d842-cde0-4b76-9420-3b636e8defcc',
        'administrator@gmail.com',
        'AG8ucQ6Y8TIvJLxIgxS2slPljvMIHm8HMOZMgPzxz3gAVLlGbGpKxgDrzgUaDNdiQQ==',
        '0001-01-01 00:00:00.0000000',
        '0',
        '1',
        GETDATE(),
        GETDATE(),
        0
    )


Roles:

INSERT INTO Roles (Id, RoleValue, [Description]) VALUES (NEWID(), 'Administrator', 'Pequena descrição')

 */
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_Dbkurs.Models;

public partial class Labb2ErikDbContext : DbContext
{
    public Labb2ErikDbContext()
    {
    }

    public Labb2ErikDbContext(DbContextOptions<Labb2ErikDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGrade> StudentGrades { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = localhost\\MSSQLSERVER01; Database = Labb2_Erik_DB; Integrated Security = true; Trust Server Certificate = true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC074DB15137");

            entity.Property(e => e.ClassName)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Classes)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Classes__Employe__52593CB8");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0772290EB3");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC07215E0F5A");

            entity.HasIndex(e => e.EmployeeId, "UQ__Position__7AD04F10ED7FBA98").IsUnique();

            entity.Property(e => e.Position1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Position");

            entity.HasOne(d => d.Employee).WithOne(p => p.Position)
                .HasForeignKey<Position>(d => d.EmployeeId)
                .HasConstraintName("FK__Positions__Emplo__4E88ABD4");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07262DB212");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PersonalNr)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Students__ClassI__5535A963");
        });

        modelBuilder.Entity<StudentGrade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentG__3214EC07ADAE33AD");

            entity.Property(e => e.Grade)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.StudentGrades)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__StudentGr__Emplo__5BE2A6F2");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentGrades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentGr__Stude__59FA5E80");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentGrades)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__StudentGr__Subje__5AEE82B9");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC07176E61AE");

            entity.Property(e => e.SubjectName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

 using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFdemo.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advisor> Advisors { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Prereq> Prereqs { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Take> Takes { get; set; }
        public virtual DbSet<Teach> Teaches { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=139.196.114.7)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User ID=MFQTEST;Password=mfq20010719;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MFQTEST");

            modelBuilder.Entity<Advisor>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("SYS_C0010025");

                entity.ToTable("ADVISOR");

                entity.Property(e => e.SId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("S_ID");

                entity.Property(e => e.IId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("I_ID");

                entity.HasOne(d => d.IIdNavigation)
                    .WithMany(p => p.Advisors)
                    .HasForeignKey(d => d.IId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C0010026");

                entity.HasOne(d => d.SIdNavigation)
                    .WithOne(p => p.Advisor)
                    .HasForeignKey<Advisor>(d => d.SId)
                    .HasConstraintName("SYS_C0010027");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(e => new { e.Building, e.RoomNumber })
                    .HasName("SYS_C0010000");

                entity.ToTable("CLASSROOM");

                entity.Property(e => e.Building)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ROOM_NUMBER");

                entity.Property(e => e.Capacity)
                    .HasPrecision(4)
                    .HasColumnName("CAPACITY");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.Credits)
                    .HasPrecision(2)
                    .HasColumnName("CREDITS");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_NAME");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.DeptNameNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DeptName)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C0010005");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptName)
                    .HasName("SYS_C0010002");

                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_NAME");

                entity.Property(e => e.Budget)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("BUDGET");

                entity.Property(e => e.Building)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("INSTRUCTOR");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_NAME");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(8,2)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.DeptNameNavigation)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.DeptName)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C0010009");
            });

            modelBuilder.Entity<Prereq>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.PrereqId })
                    .HasName("SYS_C0010033");

                entity.ToTable("PREREQ");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.PrereqId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("PREREQ_ID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PrereqCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("SYS_C0010034");

                entity.HasOne(d => d.PrereqNavigation)
                    .WithMany(p => p.PrereqPrereqNavigations)
                    .HasForeignKey(d => d.PrereqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C0010035");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.SecId, e.Semester, e.Year })
                    .HasName("SYS_C0010012");

                entity.ToTable("SECTION");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.SecId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SEC_ID");

                entity.Property(e => e.Semester)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEMESTER");

                entity.Property(e => e.Year)
                    .HasPrecision(4)
                    .HasColumnName("YEAR");

                entity.Property(e => e.Building)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BUILDING");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ROOM_NUMBER");

                entity.Property(e => e.TimeSlotId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TIME_SLOT_ID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("SYS_C0010013");

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => new { d.Building, d.RoomNumber })
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C0010014");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_NAME");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.TotCred)
                    .HasPrecision(3)
                    .HasColumnName("TOT_CRED");

                entity.HasOne(d => d.DeptNameNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DeptName)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C0010021");
            });

            modelBuilder.Entity<Take>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CourseId, e.SecId, e.Semester, e.Year })
                    .HasName("SYS_C0010022");

                entity.ToTable("TAKES");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.SecId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SEC_ID");

                entity.Property(e => e.Semester)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEMESTER");

                entity.Property(e => e.Year)
                    .HasPrecision(4)
                    .HasColumnName("YEAR");

                entity.Property(e => e.Grade)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GRADE");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("SYS_C0010024");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Takes)
                    .HasForeignKey(d => new { d.CourseId, d.SecId, d.Semester, d.Year })
                    .HasConstraintName("SYS_C0010023");
            });

            modelBuilder.Entity<Teach>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CourseId, e.SecId, e.Semester, e.Year })
                    .HasName("SYS_C0010015");

                entity.ToTable("TEACHES");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.SecId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SEC_ID");

                entity.Property(e => e.Semester)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SEMESTER");

                entity.Property(e => e.Year)
                    .HasPrecision(4)
                    .HasColumnName("YEAR");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Teaches)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("SYS_C0010017");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Teaches)
                    .HasForeignKey(d => new { d.CourseId, d.SecId, d.Semester, d.Year })
                    .HasConstraintName("SYS_C0010016");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.HasKey(e => new { e.TimeSlotId, e.Day, e.StartHr, e.StartMin })
                    .HasName("SYS_C0010032");

                entity.ToTable("TIME_SLOT");

                entity.Property(e => e.TimeSlotId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TIME_SLOT_ID");

                entity.Property(e => e.Day)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DAY");

                entity.Property(e => e.StartHr)
                    .HasPrecision(2)
                    .HasColumnName("START_HR");

                entity.Property(e => e.StartMin)
                    .HasPrecision(2)
                    .HasColumnName("START_MIN");

                entity.Property(e => e.EndHr)
                    .HasPrecision(2)
                    .HasColumnName("END_HR");

                entity.Property(e => e.EndMin)
                    .HasPrecision(2)
                    .HasColumnName("END_MIN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

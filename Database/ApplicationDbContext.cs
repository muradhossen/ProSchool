using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        } 
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassTeacher>()
                .HasKey(ct => new { ct.ClassId, ct.TeacherId });

            modelBuilder.Entity<ClassTeacher>()
                .HasOne(ct => ct.Class)
                .WithMany(c => c.ClassTeachers)
                .HasForeignKey(ct => ct.ClassId);

            modelBuilder.Entity<ClassTeacher>()
                .HasOne(ct => ct.Teacher)
                .WithMany(t => t.ClassTeachers)
                .HasForeignKey(ct => ct.TeacherId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId);

            #region Student validation
            modelBuilder.Entity<Student>()
               .Property(c => c.StudentName)
               .IsRequired(true);

            modelBuilder.Entity<Student>()
                .Property(c => c.StudentName)
                .HasMaxLength(70); 

            #endregion

            #region Class validation

            modelBuilder.Entity<Class>()
              .Property(c => c.ClassName)
              .IsRequired(true);

            modelBuilder.Entity<Class>()
               .Property(c => c.ClassName)
               .HasMaxLength(15);

            #endregion

            #region Teacher validation
            modelBuilder.Entity<Teacher>()
           .Property(c => c.TeacherName)
           .IsRequired(true);

            modelBuilder.Entity<Teacher>()
              .Property(c => c.TeacherName)
              .HasMaxLength(70);
            #endregion

        }
    }
}

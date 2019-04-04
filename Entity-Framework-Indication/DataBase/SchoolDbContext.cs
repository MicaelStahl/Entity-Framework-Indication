using Entity_Framework_Indication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Indication.Models
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StudentsCourses> Sc { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity<StudentsCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(sc => sc.CourseId);
            modelBuilder.Entity<StudentsCourses>()
                .HasOne(sc => sc.Student)
                .WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(sc => sc.StudentId);
        }
    }
}

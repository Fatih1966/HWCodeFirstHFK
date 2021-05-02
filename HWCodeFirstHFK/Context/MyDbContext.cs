using HWCodeFirstHFK.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWCodeFirstHFK.Context
{
    class MyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MsSqlLocalDb;database=HWCodeFirstHFK;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ManyToMany(modelBuilder);
        }

        private void ManyToMany(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseInstructor>()
                .HasKey(ci => new { ci.CourseID, ci.PersonID });
            modelBuilder.Entity<CourseInstructor>()
                .HasOne(ci => ci.course)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(ci => ci.CourseID);
            modelBuilder.Entity<CourseInstructor>()
                .HasOne(ci => ci.person)
                .WithMany(p => p.CourseInstructors)
                .HasForeignKey(ci => ci.PersonID);
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<OfficeAssignment> officeAssignments { get; set; }

        public DbSet<OnlineCourse> onlineCourses { get; set; }

        public DbSet<OnSiteCourse> onSiteCourses { get; set; }

        public DbSet<Person> people { get; set; }

        public DbSet<StudentGrade> studentGrades { get; set; }

        public DbSet<Course> courses { get; set; }



    }
}

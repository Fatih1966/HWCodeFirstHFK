﻿// <auto-generated />
using System;
using HWCodeFirstHFK.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HWCodeFirstHFK.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210502133038_Dbinit")]
    partial class Dbinit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoursePerson", b =>
                {
                    b.Property<int>("PeoplePersonID")
                        .HasColumnType("int");

                    b.Property<int>("coursesCourseID")
                        .HasColumnType("int");

                    b.HasKey("PeoplePersonID", "coursesCourseID");

                    b.HasIndex("coursesCourseID");

                    b.ToTable("CoursePerson");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int?>("OnlineCourseiD")
                        .HasColumnType("int");

                    b.Property<int?>("OnsiteCourseiD")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("OnlineCourseiD");

                    b.HasIndex("OnsiteCourseiD");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.CourseInstructor", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("CourseID", "PersonID");

                    b.HasIndex("PersonID");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Administrator")
                        .HasColumnType("int");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.OfficeAssignment", b =>
                {
                    b.Property<int>("iD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Timestamp")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("iD");

                    b.HasIndex("PersonID")
                        .IsUnique();

                    b.ToTable("officeAssignments");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.OnSiteCourse", b =>
                {
                    b.Property<int>("iD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Days")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("iD");

                    b.ToTable("onSiteCourses");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.OnlineCourse", b =>
                {
                    b.Property<int>("iD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("iD");

                    b.ToTable("onlineCourses");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("people");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.StudentGrade", b =>
                {
                    b.Property<int>("iD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("iD");

                    b.HasIndex("CourseID");

                    b.HasIndex("PersonID");

                    b.ToTable("studentGrades");
                });

            modelBuilder.Entity("CoursePerson", b =>
                {
                    b.HasOne("HWCodeFirstHFK.Entity.Person", null)
                        .WithMany()
                        .HasForeignKey("PeoplePersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HWCodeFirstHFK.Entity.Course", null)
                        .WithMany()
                        .HasForeignKey("coursesCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.Course", b =>
                {
                    b.HasOne("HWCodeFirstHFK.Entity.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HWCodeFirstHFK.Entity.OnlineCourse", "OnlineCourse")
                        .WithMany()
                        .HasForeignKey("OnlineCourseiD");

                    b.HasOne("HWCodeFirstHFK.Entity.OnSiteCourse", "OnsiteCourse")
                        .WithMany()
                        .HasForeignKey("OnsiteCourseiD");

                    b.Navigation("Department");

                    b.Navigation("OnlineCourse");

                    b.Navigation("OnsiteCourse");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.CourseInstructor", b =>
                {
                    b.HasOne("HWCodeFirstHFK.Entity.Course", "course")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HWCodeFirstHFK.Entity.Person", "person")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("person");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.OfficeAssignment", b =>
                {
                    b.HasOne("HWCodeFirstHFK.Entity.Person", "Person")
                        .WithOne("officeAssignment")
                        .HasForeignKey("HWCodeFirstHFK.Entity.OfficeAssignment", "PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.StudentGrade", b =>
                {
                    b.HasOne("HWCodeFirstHFK.Entity.Course", "Course")
                        .WithMany("StudentGrades")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HWCodeFirstHFK.Entity.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID");

                    b.Navigation("Course");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.Course", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("StudentGrades");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("HWCodeFirstHFK.Entity.Person", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("officeAssignment");
                });
#pragma warning restore 612, 618
        }
    }
}

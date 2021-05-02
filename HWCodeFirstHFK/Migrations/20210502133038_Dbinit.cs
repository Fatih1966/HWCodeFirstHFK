using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HWCodeFirstHFK.Migrations
{
    public partial class Dbinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Administrator = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "onlineCourses",
                columns: table => new
                {
                    iD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onlineCourses", x => x.iD);
                });

            migrationBuilder.CreateTable(
                name: "onSiteCourses",
                columns: table => new
                {
                    iD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onSiteCourses", x => x.iD);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    OnlineCourseiD = table.Column<int>(type: "int", nullable: true),
                    OnsiteCourseiD = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_courses_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courses_onlineCourses_OnlineCourseiD",
                        column: x => x.OnlineCourseiD,
                        principalTable: "onlineCourses",
                        principalColumn: "iD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_courses_onSiteCourses_OnsiteCourseiD",
                        column: x => x.OnsiteCourseiD,
                        principalTable: "onSiteCourses",
                        principalColumn: "iD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "officeAssignments",
                columns: table => new
                {
                    iD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_officeAssignments", x => x.iD);
                    table.ForeignKey(
                        name: "FK_officeAssignments_people_PersonID",
                        column: x => x.PersonID,
                        principalTable: "people",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => new { x.CourseID, x.PersonID });
                    table.ForeignKey(
                        name: "FK_CourseInstructor_courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_people_PersonID",
                        column: x => x.PersonID,
                        principalTable: "people",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePerson",
                columns: table => new
                {
                    PeoplePersonID = table.Column<int>(type: "int", nullable: false),
                    coursesCourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePerson", x => new { x.PeoplePersonID, x.coursesCourseID });
                    table.ForeignKey(
                        name: "FK_CoursePerson_courses_coursesCourseID",
                        column: x => x.coursesCourseID,
                        principalTable: "courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePerson_people_PeoplePersonID",
                        column: x => x.PeoplePersonID,
                        principalTable: "people",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentGrades",
                columns: table => new
                {
                    iD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentGrades", x => x.iD);
                    table.ForeignKey(
                        name: "FK_studentGrades_courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentGrades_people_PersonID",
                        column: x => x.PersonID,
                        principalTable: "people",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_PersonID",
                table: "CourseInstructor",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePerson_coursesCourseID",
                table: "CoursePerson",
                column: "coursesCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_courses_DepartmentID",
                table: "courses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_courses_OnlineCourseiD",
                table: "courses",
                column: "OnlineCourseiD");

            migrationBuilder.CreateIndex(
                name: "IX_courses_OnsiteCourseiD",
                table: "courses",
                column: "OnsiteCourseiD");

            migrationBuilder.CreateIndex(
                name: "IX_officeAssignments_PersonID",
                table: "officeAssignments",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentGrades_CourseID",
                table: "studentGrades",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_studentGrades_PersonID",
                table: "studentGrades",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInstructor");

            migrationBuilder.DropTable(
                name: "CoursePerson");

            migrationBuilder.DropTable(
                name: "officeAssignments");

            migrationBuilder.DropTable(
                name: "studentGrades");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "onlineCourses");

            migrationBuilder.DropTable(
                name: "onSiteCourses");
        }
    }
}

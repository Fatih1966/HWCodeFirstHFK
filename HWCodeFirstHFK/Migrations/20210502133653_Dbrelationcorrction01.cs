using Microsoft.EntityFrameworkCore.Migrations;

namespace HWCodeFirstHFK.Migrations
{
    public partial class Dbrelationcorrction01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_CoursePerson_coursesCourseID",
                table: "CoursePerson",
                column: "coursesCourseID");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendSico.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lastname2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    typePerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    tuition = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fkPersonStu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_Person_fkPersonStu",
                        column: x => x.fkPersonStu,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    professionalLicense = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fkPersonTea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teacher_Person_fkPersonTea",
                        column: x => x.fkPersonTea,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    fkTeacher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.id);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_fkTeacher",
                        column: x => x.fkTeacher,
                        principalTable: "Teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    fkStudent = table.Column<int>(type: "int", nullable: false),
                    fkCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseDetail_Course_fkCourse",
                        column: x => x.fkCourse,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseDetail_Student_fkStudent",
                        column: x => x.fkStudent,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_fkTeacher",
                table: "Course",
                column: "fkTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetail_fkCourse",
                table: "CourseDetail",
                column: "fkCourse");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetail_fkStudent",
                table: "CourseDetail",
                column: "fkStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Student_fkPersonStu",
                table: "Student",
                column: "fkPersonStu");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_fkPersonTea",
                table: "Teacher",
                column: "fkPersonTea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDetail");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLabb2.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTablesAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeacherLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudentRelation",
                columns: table => new
                {
                    ClassStudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkClassId = table.Column<int>(type: "int", nullable: false),
                    FkStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudentRelation", x => x.ClassStudentId);
                    table.ForeignKey(
                        name: "FK_ClassStudentRelation_Classes_FkClassId",
                        column: x => x.FkClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudentRelation_Students_FkStudentId",
                        column: x => x.FkStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseRelation",
                columns: table => new
                {
                    StudentCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkStudentId = table.Column<int>(type: "int", nullable: false),
                    FkCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseRelation", x => x.StudentCourseId);
                    table.ForeignKey(
                        name: "FK_StudentCourseRelation_Courses_FkCourseId",
                        column: x => x.FkCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourseRelation_Students_FkStudentId",
                        column: x => x.FkStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeacherRelation",
                columns: table => new
                {
                    ClassTeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkTeacherId = table.Column<int>(type: "int", nullable: false),
                    FkClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeacherRelation", x => x.ClassTeacherId);
                    table.ForeignKey(
                        name: "FK_ClassTeacherRelation_Classes_FkClassId",
                        column: x => x.FkClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTeacherRelation_Teachers_FkTeacherId",
                        column: x => x.FkTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherClassRelation",
                columns: table => new
                {
                    TeacherClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkTeacherId = table.Column<int>(type: "int", nullable: false),
                    FkClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClassRelation", x => x.TeacherClassId);
                    table.ForeignKey(
                        name: "FK_TeacherClassRelation_Classes_FkClassId",
                        column: x => x.FkClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherClassRelation_Teachers_FkTeacherId",
                        column: x => x.FkTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourseRelation",
                columns: table => new
                {
                    TeacherCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkTeacherId = table.Column<int>(type: "int", nullable: false),
                    FkCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourseRelation", x => x.TeacherCourseId);
                    table.ForeignKey(
                        name: "FK_TeacherCourseRelation_Courses_FkCourseId",
                        column: x => x.FkCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourseRelation_Teachers_FkTeacherId",
                        column: x => x.FkTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentRelation_FkClassId",
                table: "ClassStudentRelation",
                column: "FkClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentRelation_FkStudentId",
                table: "ClassStudentRelation",
                column: "FkStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherRelation_FkClassId",
                table: "ClassTeacherRelation",
                column: "FkClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherRelation_FkTeacherId",
                table: "ClassTeacherRelation",
                column: "FkTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseRelation_FkCourseId",
                table: "StudentCourseRelation",
                column: "FkCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourseRelation_FkStudentId",
                table: "StudentCourseRelation",
                column: "FkStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassRelation_FkClassId",
                table: "TeacherClassRelation",
                column: "FkClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassRelation_FkTeacherId",
                table: "TeacherClassRelation",
                column: "FkTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourseRelation_FkCourseId",
                table: "TeacherCourseRelation",
                column: "FkCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourseRelation_FkTeacherId",
                table: "TeacherCourseRelation",
                column: "FkTeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudentRelation");

            migrationBuilder.DropTable(
                name: "ClassTeacherRelation");

            migrationBuilder.DropTable(
                name: "StudentCourseRelation");

            migrationBuilder.DropTable(
                name: "TeacherClassRelation");

            migrationBuilder.DropTable(
                name: "TeacherCourseRelation");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}

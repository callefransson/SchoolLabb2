using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLabb2.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedrelationstoapplicationdbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassRelation_Classes_FkClassId",
                table: "TeacherClassRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassRelation_Teachers_FkTeacherId",
                table: "TeacherClassRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourseRelation_Courses_FkCourseId",
                table: "TeacherCourseRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourseRelation_Teachers_FkTeacherId",
                table: "TeacherCourseRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourseRelation",
                table: "TeacherCourseRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherClassRelation",
                table: "TeacherClassRelation");

            migrationBuilder.RenameTable(
                name: "TeacherCourseRelation",
                newName: "TeacherCourseRelations");

            migrationBuilder.RenameTable(
                name: "TeacherClassRelation",
                newName: "TeacherClassRelations");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourseRelation_FkTeacherId",
                table: "TeacherCourseRelations",
                newName: "IX_TeacherCourseRelations_FkTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourseRelation_FkCourseId",
                table: "TeacherCourseRelations",
                newName: "IX_TeacherCourseRelations_FkCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherClassRelation_FkTeacherId",
                table: "TeacherClassRelations",
                newName: "IX_TeacherClassRelations_FkTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherClassRelation_FkClassId",
                table: "TeacherClassRelations",
                newName: "IX_TeacherClassRelations_FkClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourseRelations",
                table: "TeacherCourseRelations",
                column: "TeacherCourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherClassRelations",
                table: "TeacherClassRelations",
                column: "TeacherClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassRelations_Classes_FkClassId",
                table: "TeacherClassRelations",
                column: "FkClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassRelations_Teachers_FkTeacherId",
                table: "TeacherClassRelations",
                column: "FkTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourseRelations_Courses_FkCourseId",
                table: "TeacherCourseRelations",
                column: "FkCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourseRelations_Teachers_FkTeacherId",
                table: "TeacherCourseRelations",
                column: "FkTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassRelations_Classes_FkClassId",
                table: "TeacherClassRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClassRelations_Teachers_FkTeacherId",
                table: "TeacherClassRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourseRelations_Courses_FkCourseId",
                table: "TeacherCourseRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourseRelations_Teachers_FkTeacherId",
                table: "TeacherCourseRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherCourseRelations",
                table: "TeacherCourseRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherClassRelations",
                table: "TeacherClassRelations");

            migrationBuilder.RenameTable(
                name: "TeacherCourseRelations",
                newName: "TeacherCourseRelation");

            migrationBuilder.RenameTable(
                name: "TeacherClassRelations",
                newName: "TeacherClassRelation");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourseRelations_FkTeacherId",
                table: "TeacherCourseRelation",
                newName: "IX_TeacherCourseRelation_FkTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherCourseRelations_FkCourseId",
                table: "TeacherCourseRelation",
                newName: "IX_TeacherCourseRelation_FkCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherClassRelations_FkTeacherId",
                table: "TeacherClassRelation",
                newName: "IX_TeacherClassRelation_FkTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherClassRelations_FkClassId",
                table: "TeacherClassRelation",
                newName: "IX_TeacherClassRelation_FkClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherCourseRelation",
                table: "TeacherCourseRelation",
                column: "TeacherCourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherClassRelation",
                table: "TeacherClassRelation",
                column: "TeacherClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassRelation_Classes_FkClassId",
                table: "TeacherClassRelation",
                column: "FkClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClassRelation_Teachers_FkTeacherId",
                table: "TeacherClassRelation",
                column: "FkTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourseRelation_Courses_FkCourseId",
                table: "TeacherCourseRelation",
                column: "FkCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourseRelation_Teachers_FkTeacherId",
                table: "TeacherCourseRelation",
                column: "FkTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

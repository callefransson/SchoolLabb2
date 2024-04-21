using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLabb2.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeletedAModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassTeacherRelation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassTeacherRelation",
                columns: table => new
                {
                    ClassTeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkClassId = table.Column<int>(type: "int", nullable: false),
                    FkTeacherId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherRelation_FkClassId",
                table: "ClassTeacherRelation",
                column: "FkClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacherRelation_FkTeacherId",
                table: "ClassTeacherRelation",
                column: "FkTeacherId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "ClassroomLessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_ClassId",
                table: "ClassStudents",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomTeachers_ClassId",
                table: "ClassroomTeachers",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomTeachers_TeacherId",
                table: "ClassroomTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomLessons_ClassId",
                table: "ClassroomLessons",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomLessons_LessonId",
                table: "ClassroomLessons",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomLessons_Classes_ClassId",
                table: "ClassroomLessons",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomLessons_Lessons_LessonId",
                table: "ClassroomLessons",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTeachers_Classes_ClassId",
                table: "ClassroomTeachers",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTeachers_Teachers_TeacherId",
                table: "ClassroomTeachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_Classes_ClassId",
                table: "ClassStudents",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_Students_StudentId",
                table: "ClassStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomLessons_Classes_ClassId",
                table: "ClassroomLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomLessons_Lessons_LessonId",
                table: "ClassroomLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTeachers_Classes_ClassId",
                table: "ClassroomTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTeachers_Teachers_TeacherId",
                table: "ClassroomTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_Classes_ClassId",
                table: "ClassStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_Students_StudentId",
                table: "ClassStudents");

            migrationBuilder.DropIndex(
                name: "IX_ClassStudents_ClassId",
                table: "ClassStudents");

            migrationBuilder.DropIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudents");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomTeachers_ClassId",
                table: "ClassroomTeachers");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomTeachers_TeacherId",
                table: "ClassroomTeachers");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomLessons_ClassId",
                table: "ClassroomLessons");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomLessons_LessonId",
                table: "ClassroomLessons");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "ClassroomLessons");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class added_seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassName" },
                values: new object[,]
                {
                    { 1, "Mathematics" },
                    { 2, "Science" },
                    { 3, "History" },
                    { 4, "English" },
                    { 5, "Physics" },
                    { 6, "Biology" },
                    { 7, "Chemistry" },
                    { 8, "Geography" },
                    { 9, "Art" },
                    { 10, "Music" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "TeacherName" },
                values: new object[,]
                {
                    { 1, "Murad Hossen" },
                    { 2, "Hamidur Rahman" },
                    { 3, "Rajib Sarkar" },
                    { 4, "Mominul Islam" },
                    { 5, "Hasan Showrav" }
                });

            migrationBuilder.InsertData(
                table: "ClassTeachers",
                columns: new[] { "ClassId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 1 },
                    { 7, 2 },
                    { 8, 3 },
                    { 9, 4 },
                    { 10, 5 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "StudentName" },
                values: new object[,]
                {
                    { 1, 1, "John" },
                    { 2, 1, "Alice" },
                    { 3, 2, "Bob" },
                    { 4, 2, "Eve" },
                    { 5, 3, "Mike" },
                    { 6, 3, "Sarah" },
                    { 7, 4, "David" },
                    { 8, 4, "Emily" },
                    { 9, 5, "Chris" },
                    { 10, 5, "Sophia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "ClassTeachers",
                keyColumns: new[] { "ClassId", "TeacherId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 5);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LINQ_Labb.Migrations
{
    /// <inheritdoc />
    public partial class _202304191517 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Student");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Student",
                type: "int",
                nullable: true);
        }
    }
}

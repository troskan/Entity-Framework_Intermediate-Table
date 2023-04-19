using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LINQ_Labb.Migrations
{
    /// <inheritdoc />
    public partial class courseIDaddStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Student");
        }
    }
}

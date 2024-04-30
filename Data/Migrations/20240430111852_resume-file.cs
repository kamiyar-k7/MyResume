using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class resumefile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Information");

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "Information",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resume",
                table: "Information");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Information",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Adminfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Information",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsAdmin",
                table: "Information",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}

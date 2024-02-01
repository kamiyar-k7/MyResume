using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UserFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicName",
                table: "Information",
                newName: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "IsAdmin",
                table: "Information",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Information");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Information",
                newName: "PicName");
        }
    }
}

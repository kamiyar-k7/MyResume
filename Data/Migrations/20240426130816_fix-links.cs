using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class fixlinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "links",
                newName: "TelegramUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "links",
                newName: "LinkedinUrl");

            migrationBuilder.AddColumn<string>(
                name: "GitHubmUrl",
                table: "links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHubmUrl",
                table: "links");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "links");

            migrationBuilder.RenameColumn(
                name: "TelegramUrl",
                table: "links",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "LinkedinUrl",
                table: "links",
                newName: "Name");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TappWeb.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserPasswordKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordKey",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

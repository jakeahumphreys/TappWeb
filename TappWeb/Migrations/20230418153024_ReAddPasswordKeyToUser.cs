using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TappWeb.Migrations
{
    /// <inheritdoc />
    public partial class ReAddPasswordKeyToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Users");
        }
    }
}

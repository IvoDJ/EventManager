using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToDJ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Password",
                table: "Djs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User_Username",
                table: "Djs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Password",
                table: "Djs");

            migrationBuilder.DropColumn(
                name: "User_Username",
                table: "Djs");
        }
    }
}

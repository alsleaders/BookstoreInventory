using Microsoft.EntityFrameworkCore.Migrations;

namespace bookstoreinventory.Migrations
{
    public partial class AddAuthorAndComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Books",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Books");
        }
    }
}

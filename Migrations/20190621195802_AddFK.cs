using Microsoft.EntityFrameworkCore.Migrations;

namespace bookstoreinventory.Migrations
{
    public partial class AddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LocationId",
                table: "Books",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Location_LocationId",
                table: "Books",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Location_LocationId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LocationId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Books");
        }
    }
}

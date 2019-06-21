using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace bookstoreinventory.Migrations
{
  public partial class First : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {

      migrationBuilder.CreateTable(
          name: "Location",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
            Address = table.Column<string>(nullable: true),
            Manager = table.Column<string>(nullable: true),
            PhoneNumber = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Location", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Books");

      migrationBuilder.DropTable(
          name: "Location");
    }
  }
}

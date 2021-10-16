using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "TbReserve",
                columns: table => new
                {
                    TbReserveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    TableDate = table.Column<DateTime>(nullable: false),
                    TableHour = table.Column<string>(nullable: true),
                    NumOfPersons = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbReserve", x => x.TbReserveId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbReserve");

           
        }
    }
}

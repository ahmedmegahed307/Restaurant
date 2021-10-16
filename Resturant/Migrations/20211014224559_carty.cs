using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class carty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "checkoutdata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    phonenumber = table.Column<double>(nullable: false),
                    country = table.Column<string>(nullable: true),
                    emailaddress = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    postalcode = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkoutdata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopingCartItem",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ShopingCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopingCartItem", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_ShopingCartItem_checkoutdata_ShopingCartId",
                        column: x => x.ShopingCartId,
                        principalTable: "checkoutdata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCartItem_ShopingCartId",
                table: "ShopingCartItem",
                column: "ShopingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopingCartItem");

            migrationBuilder.DropTable(
                name: "checkoutdata");
        }
    }
}

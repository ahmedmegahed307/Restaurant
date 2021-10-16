using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class reviewsproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "TbReviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TbReviews_ProductId",
                table: "TbReviews",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbReviews_TbProduct_ProductId",
                table: "TbReviews",
                column: "ProductId",
                principalTable: "TbProduct",
                principalColumn: "TbProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbReviews_TbProduct_ProductId",
                table: "TbReviews");

            migrationBuilder.DropIndex(
                name: "IX_TbReviews_ProductId",
                table: "TbReviews");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "TbReviews");
        }
    }
}

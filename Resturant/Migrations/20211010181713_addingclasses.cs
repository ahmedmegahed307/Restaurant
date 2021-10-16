using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class addingclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "TbCategory",
                columns: table => new
                {
                    TbCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    CategorySlug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategory", x => x.TbCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TbGallery",
                columns: table => new
                {
                    TbGalleryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalleryImage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbGallery", x => x.TbGalleryId);
                });

            migrationBuilder.CreateTable(
                name: "TbSlider",
                columns: table => new
                {
                    TbSliderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderTitle = table.Column<string>(maxLength: 50, nullable: false),
                    SliderDescription = table.Column<string>(maxLength: 200, nullable: false),
                    SliderImage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSlider", x => x.TbSliderId);
                });

           

           
            migrationBuilder.CreateTable(
                name: "TbProduct",
                columns: table => new
                {
                    TbProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductImage = table.Column<string>(nullable: false),
                    ProductDescription = table.Column<string>(maxLength: 200, nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProduct", x => x.TbProductId);
                    table.ForeignKey(
                        name: "FK_TbProduct_TbCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TbCategory",
                        principalColumn: "TbCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbProductImage",
                columns: table => new
                {
                    TbProductImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductImageName = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProductImage", x => x.TbProductImageId);
                    table.ForeignKey(
                        name: "FK_TbProductImage_TbProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TbProduct",
                        principalColumn: "TbProductId",
                        onDelete: ReferentialAction.Cascade);
                });

           

          

            migrationBuilder.CreateIndex(
                name: "IX_TbProduct_CategoryId",
                table: "TbProduct",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProductImage_ProductId",
                table: "TbProductImage",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.DropTable(
                name: "TbGallery");

            migrationBuilder.DropTable(
                name: "TbProductImage");

            migrationBuilder.DropTable(
                name: "TbSlider");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TbProduct");

            migrationBuilder.DropTable(
                name: "TbCategory");
        }
    }
}

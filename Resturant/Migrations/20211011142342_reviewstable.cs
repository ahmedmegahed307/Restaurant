using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Migrations
{
    public partial class reviewstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbReviews",
                columns: table => new
                {
                    TbReviewsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    TopicName = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    ReviewDate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbReviews", x => x.TbReviewsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbReviews");
        }
    }
}

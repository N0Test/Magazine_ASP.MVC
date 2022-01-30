using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine_ASP.MVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tag = table.Column<int>(type: "int", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "img/news-350x223-1.jpg" },
                    { 2, "img/news-350x223-2.jpg" },
                    { 3, "img/news-350x223-3.jpg" },
                    { 4, "img/news-350x223-4.jpg" },
                    { 5, "img/news-350x223-5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Date", "ImageId", "Tag", "Title", "ViewsCount" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 29, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(389), 2, 1, "#1 Title", 163 },
                    { 2, new DateTime(2022, 1, 27, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(475), 3, 1, "#2 Title", 357 },
                    { 3, new DateTime(2022, 1, 27, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(481), 4, 4, "#3 Title", 112 },
                    { 4, new DateTime(2022, 1, 27, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(485), 5, 2, "#4 Title", 762 },
                    { 5, new DateTime(2022, 1, 26, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(488), 1, 3, "#5 Title", 436 },
                    { 6, new DateTime(2022, 1, 26, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(493), 2, 2, "#6 Title", 123 },
                    { 7, new DateTime(2022, 1, 25, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(497), 3, 1, "#7 Title", 422 },
                    { 8, new DateTime(2022, 1, 29, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(501), 4, 1, "#8 Title", 447 },
                    { 9, new DateTime(2022, 1, 25, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(504), 5, 2, "#9 Title", 751 },
                    { 10, new DateTime(2022, 1, 29, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(509), 1, 4, "#10 Title", 563 },
                    { 11, new DateTime(2022, 1, 26, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(513), 2, 2, "#11 Title", 868 },
                    { 12, new DateTime(2022, 1, 27, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(517), 3, 3, "#12 Title", 165 },
                    { 13, new DateTime(2022, 1, 28, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(521), 4, 2, "#13 Title", 275 },
                    { 14, new DateTime(2022, 1, 26, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(524), 5, 2, "#14 Title", 152 },
                    { 15, new DateTime(2022, 1, 29, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(528), 1, 1, "#15 Title", 692 },
                    { 16, new DateTime(2022, 1, 26, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(532), 2, 4, "#16 Title", 265 },
                    { 17, new DateTime(2022, 1, 29, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(535), 3, 3, "#17 Title", 559 },
                    { 18, new DateTime(2022, 1, 29, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(540), 4, 4, "#18 Title", 397 },
                    { 19, new DateTime(2022, 1, 28, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(543), 5, 3, "#19 Title", 334 },
                    { 20, new DateTime(2022, 1, 26, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(554), 1, 4, "#20 Title", 900 },
                    { 21, new DateTime(2022, 1, 26, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(558), 2, 1, "#21 Title", 405 },
                    { 22, new DateTime(2022, 1, 25, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(561), 3, 2, "#22 Title", 848 },
                    { 23, new DateTime(2022, 1, 29, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(565), 4, 1, "#23 Title", 301 },
                    { 24, new DateTime(2022, 1, 26, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(569), 5, 1, "#24 Title", 134 },
                    { 25, new DateTime(2022, 1, 28, 14, 56, 37, 554, DateTimeKind.Local).AddTicks(573), 1, 4, "#25 Title", 813 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_ImageId",
                table: "News",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}

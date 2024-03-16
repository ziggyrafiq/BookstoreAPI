/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	20/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZR.Infrastructure.Migrations.Migrations
{
    public partial class Nes1wMigrationTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "Author", "Price", "Title" },
                values: new object[] { 1L, "A.A. Milne", 19.25m, "Winnie-the-Pooh" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "Author", "Price", "Title" },
                values: new object[] { 2L, "Jane Austen", 5.49m, "Pride and Prejudice" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "Author", "Price", "Title" },
                values: new object[] { 3L, "William Shakespeare", 6.95m, "Romeo and Juliet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForestTime.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_User_UserId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId1",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_User_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_User_UserId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId1",
                table: "Articles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_User_UserId1",
                table: "Articles",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}

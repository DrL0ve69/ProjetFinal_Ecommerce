using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinal_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class Modifications_AllModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserConnectedId",
                table: "DbSet_Factures");

            migrationBuilder.DropIndex(
                name: "IX_DbSet_Factures_AppUserConnectedId",
                table: "DbSet_Factures");

            migrationBuilder.DropColumn(
                name: "AppUserConnectedId",
                table: "DbSet_Factures");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "DbSet_Factures",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Factures_AppUserId",
                table: "DbSet_Factures",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserId",
                table: "DbSet_Factures",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserId",
                table: "DbSet_Factures");

            migrationBuilder.DropIndex(
                name: "IX_DbSet_Factures_AppUserId",
                table: "DbSet_Factures");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "DbSet_Factures");

            migrationBuilder.AddColumn<string>(
                name: "AppUserConnectedId",
                table: "DbSet_Factures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Factures_AppUserConnectedId",
                table: "DbSet_Factures",
                column: "AppUserConnectedId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserConnectedId",
                table: "DbSet_Factures",
                column: "AppUserConnectedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

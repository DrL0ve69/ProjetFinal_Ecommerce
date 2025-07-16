using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinal_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class ModificationCleProduit_Context4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserId",
                table: "DbSet_Factures");

            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserId1",
                table: "DbSet_Factures");

            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Factures_DbSet_Produits_MockproduitId",
                table: "DbSet_Factures");

            migrationBuilder.DropIndex(
                name: "IX_DbSet_Factures_AppUserId",
                table: "DbSet_Factures");

            migrationBuilder.DropIndex(
                name: "IX_DbSet_Factures_AppUserId1",
                table: "DbSet_Factures");

            migrationBuilder.DropIndex(
                name: "IX_DbSet_Factures_MockproduitId",
                table: "DbSet_Factures");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "DbSet_Factures");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "DbSet_Factures");

            migrationBuilder.DropColumn(
                name: "MockproduitId",
                table: "DbSet_Factures");

            migrationBuilder.AlterColumn<string>(
                name: "Facture",
                table: "DbSet_Factures",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FactureId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Factures_Facture",
                table: "DbSet_Factures",
                column: "Facture");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FactureId",
                table: "AspNetUsers",
                column: "FactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DbSet_Factures_FactureId",
                table: "AspNetUsers",
                column: "FactureId",
                principalTable: "DbSet_Factures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_Facture",
                table: "DbSet_Factures",
                column: "Facture",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DbSet_Factures_FactureId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_Facture",
                table: "DbSet_Factures");

            migrationBuilder.DropIndex(
                name: "IX_DbSet_Factures_Facture",
                table: "DbSet_Factures");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FactureId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FactureId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Facture",
                table: "DbSet_Factures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "DbSet_Factures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "DbSet_Factures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MockproduitId",
                table: "DbSet_Factures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Factures_AppUserId",
                table: "DbSet_Factures",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Factures_AppUserId1",
                table: "DbSet_Factures",
                column: "AppUserId1",
                unique: true,
                filter: "[AppUserId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Factures_MockproduitId",
                table: "DbSet_Factures",
                column: "MockproduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserId",
                table: "DbSet_Factures",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserId1",
                table: "DbSet_Factures",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Factures_DbSet_Produits_MockproduitId",
                table: "DbSet_Factures",
                column: "MockproduitId",
                principalTable: "DbSet_Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

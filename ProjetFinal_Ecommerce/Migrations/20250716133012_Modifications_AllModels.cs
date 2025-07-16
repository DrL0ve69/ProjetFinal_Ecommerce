using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinal_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class Modifications_AllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DbSet_Factures_FactureId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_Facture",
                table: "DbSet_Factures");

            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureId",
                table: "DbSet_Produits");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FactureId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FactureId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Facture",
                table: "DbSet_Factures",
                newName: "AppUserConnectedId");

            migrationBuilder.RenameIndex(
                name: "IX_DbSet_Factures_Facture",
                table: "DbSet_Factures",
                newName: "IX_DbSet_Factures_AppUserConnectedId");

            migrationBuilder.AlterColumn<int>(
                name: "FactureId",
                table: "DbSet_Produits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserConnectedId",
                table: "DbSet_Factures",
                column: "AppUserConnectedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureId",
                table: "DbSet_Produits",
                column: "FactureId",
                principalTable: "DbSet_Factures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Factures_AspNetUsers_AppUserConnectedId",
                table: "DbSet_Factures");

            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureId",
                table: "DbSet_Produits");

            migrationBuilder.RenameColumn(
                name: "AppUserConnectedId",
                table: "DbSet_Factures",
                newName: "Facture");

            migrationBuilder.RenameIndex(
                name: "IX_DbSet_Factures_AppUserConnectedId",
                table: "DbSet_Factures",
                newName: "IX_DbSet_Factures_Facture");

            migrationBuilder.AlterColumn<int>(
                name: "FactureId",
                table: "DbSet_Produits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FactureId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureId",
                table: "DbSet_Produits",
                column: "FactureId",
                principalTable: "DbSet_Factures",
                principalColumn: "Id");
        }
    }
}

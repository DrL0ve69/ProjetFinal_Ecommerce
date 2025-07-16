using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinal_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class Modifications_NullableFactureId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureId",
                table: "DbSet_Produits");

            migrationBuilder.AlterColumn<int>(
                name: "FactureId",
                table: "DbSet_Produits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureId",
                table: "DbSet_Produits",
                column: "FactureId",
                principalTable: "DbSet_Factures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureId",
                table: "DbSet_Produits");

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
                name: "FK_DbSet_Produits_DbSet_Factures_FactureId",
                table: "DbSet_Produits",
                column: "FactureId",
                principalTable: "DbSet_Factures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

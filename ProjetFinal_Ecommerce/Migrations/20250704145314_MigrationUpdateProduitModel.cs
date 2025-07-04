using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinal_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateProduitModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "DbSet_Produits",
                newName: "PrixUnitaire");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "DbSet_Produits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "DbSet_Produits");

            migrationBuilder.RenameColumn(
                name: "PrixUnitaire",
                table: "DbSet_Produits",
                newName: "Prix");
        }
    }
}

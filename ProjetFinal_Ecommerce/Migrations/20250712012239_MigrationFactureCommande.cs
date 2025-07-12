using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinal_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFactureCommande : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlImage",
                table: "DbSet_Produits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FactureCommandeId",
                table: "DbSet_Produits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DbSet_Factures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MockproduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSet_Factures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbSet_Factures_AspNetUsers_IdentityUserIdId",
                        column: x => x.IdentityUserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DbSet_Factures_DbSet_Produits_MockproduitId",
                        column: x => x.MockproduitId,
                        principalTable: "DbSet_Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Produits_FactureCommandeId",
                table: "DbSet_Produits",
                column: "FactureCommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Factures_IdentityUserIdId",
                table: "DbSet_Factures",
                column: "IdentityUserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_DbSet_Factures_MockproduitId",
                table: "DbSet_Factures",
                column: "MockproduitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureCommandeId",
                table: "DbSet_Produits",
                column: "FactureCommandeId",
                principalTable: "DbSet_Factures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbSet_Produits_DbSet_Factures_FactureCommandeId",
                table: "DbSet_Produits");

            migrationBuilder.DropTable(
                name: "DbSet_Factures");

            migrationBuilder.DropIndex(
                name: "IX_DbSet_Produits_FactureCommandeId",
                table: "DbSet_Produits");

            migrationBuilder.DropColumn(
                name: "FactureCommandeId",
                table: "DbSet_Produits");

            migrationBuilder.AlterColumn<string>(
                name: "UrlImage",
                table: "DbSet_Produits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

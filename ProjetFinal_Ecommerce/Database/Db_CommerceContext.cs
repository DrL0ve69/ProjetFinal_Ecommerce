using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Database;

public class Db_CommerceContext : IdentityDbContext
{
    public Db_CommerceContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Produit> DbSet_Produits { get; set; }
    public DbSet<FactureCommande> DbSet_Factures { get; set; }
}

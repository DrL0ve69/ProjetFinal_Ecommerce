using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Database;

public class Db_CommerceContext : IdentityDbContext<AppUser>
{
    public Db_CommerceContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Produit> DbSet_Produits { get; set; }
    public DbSet<Facture> DbSet_Factures { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Produit>()
            .HasKey(p => p.Id); // Clé primaire pour Produit
        
        /*
        modelBuilder.Entity<Facture>()
            .HasOne(f => f.AppUserConnected)
            .WithMany(u => u.ListeFactures)
            .HasForeignKey(f => f.AppUserId);
        */
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.ListeFactures)
            .WithOne(f => f.AppUserConnected)
            .IsRequired(false); // Facture peut être null si l'utilisateur n'a pas de facture
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_Ecommerce.Models;

public class FactureCommande
{
    public int Id { get; set; } // Clé primaire
    public string NumeroFacture => $"{NomUtilisateur}/" + DateTime.Now.ToString();
    public IdentityUser IdentityUserId { get; set; } // Clé étrangère vers IdentityUser
    public string? NomUtilisateur => IdentityUserId.UserName;
    public Produit Mockproduit { get; set; }
    public List<Produit> ProduitsPanier { get; set; }
    public decimal Montant => (decimal)ProduitsPanier.Sum(p => p.PrixUnitaire);
}

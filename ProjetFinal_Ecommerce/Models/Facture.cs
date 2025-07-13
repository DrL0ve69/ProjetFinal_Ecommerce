using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_Ecommerce.Models;

public class Facture
{
    [Key]
    public int Id { get; set; } // Clé primaire
    public string NumeroFacture => $"{NomUtilisateur}/" + DateTime.Now.ToString();

    [ForeignKey("AppUserId")]
    public string AppUserId { get; set; } // Clé étrangère vers l'utilisateur connecté
    public AppUser AppUserConnected { get; set; } // Propriété de navigation vers l'utilisateur
    public string? NomUtilisateur => AppUserConnected.UserName;
    public Produit Mockproduit { get; set; }
    public List<Produit> ProduitsPanier { get; set; } // 1 facture peut contenir plusieurs produits
    public decimal Montant => (decimal)ProduitsPanier.Sum(p => p.PrixUnitaire);
}

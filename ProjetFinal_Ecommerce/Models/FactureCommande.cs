using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinal_Ecommerce.Models;

public class FactureCommande
{
    public string Id => $"{NomUtilisateur}/" + DateTime.Now.ToString();
    public IdentityUser UserConnected { get; set; }
    public string NomUtilisateur => UserConnected.UserName;
    public Produit Mockproduit { get; set; }
    public List<Produit> ProduitsPanier { get; set; }
    public decimal Montant => (decimal)ProduitsPanier.Sum(p => p.PrixUnitaire);
}

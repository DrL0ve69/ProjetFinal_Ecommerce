using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_Ecommerce.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {
            ListeFactures = new List<Facture>();
        }
        public AppUser(string userName) : base(userName)
        {
            ListeFactures = new List<Facture>();
        }
        public string? Nom { get; set; } = null;
        public string? Prenom { get; set; } = null;
        public string? NomComplet => $"{Nom}, {Prenom}" ?? null;
        [ForeignKey("Facture")]
        public List<Facture>? ListeFactures { get; set; }
        public Facture? Facture { get; set; } // Navigation vers facture
    }
}

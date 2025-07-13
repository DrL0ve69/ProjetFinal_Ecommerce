using Microsoft.AspNetCore.Identity;

namespace ProjetFinal_Ecommerce.Models
{
    public class AppUser : IdentityUser
    {
        public List<Facture>? ListeFactures { get; set; }
        public Facture? Facture { get; set; } // Navigation vers facture
    }
}

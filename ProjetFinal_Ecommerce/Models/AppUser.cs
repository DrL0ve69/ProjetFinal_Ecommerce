using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetFinal_Ecommerce.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {
        }
        public AppUser(string userName) : base(userName)
        {
        }
        public string? Nom { get; set; } = null;
        public string? Prenom { get; set; } = null;
        public string? NomComplet => $"{Nom}, {Prenom}" ?? null;


    }
}

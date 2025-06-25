using System.ComponentModel.DataAnnotations;

namespace ProjetFinal_Ecommerce.Models
{
    public class Produit
    {
        public int Id { get; set; } // Clé primaire
        [Required]
        public string? Nom { get; set; }
        [Required]
        public string? Marque { get; set; }
        [Required]
        public string? Categorie { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal? Prix { get; set; }
    }
}

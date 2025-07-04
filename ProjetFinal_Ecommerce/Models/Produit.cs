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
        [Display(Name ="Prix unitaire")]
        public decimal? PrixUnitaire { get; set; }

        public string UrlImage { get; set; } = "https://dummyimage.com/300x300/000/fff.jpg";
    }
}

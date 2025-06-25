using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Database;

public interface IProduitRepository
{
    //Collection d'autos
    IEnumerable<Produit> MesProduits { get; }

    //Méthodes CURD
    Produit GetProduit(int? id);

    void AddProduit(Produit produit);

    void SupprimerProduit(int id);

    void ModifierProduit(Produit produit);
}

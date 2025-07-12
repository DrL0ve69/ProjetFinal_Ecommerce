using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Database;

public interface IFactureRepository
{
    IEnumerable<FactureCommande> FactureCommandes { get; }
    void Ajouter(FactureCommande facture);
    List<FactureCommande> GetFacturesByUser(string userId);
}

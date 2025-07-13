using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Database;

public interface IFactureRepository
{
    IEnumerable<Facture> FactureCommandes { get; }
    void Ajouter(Facture facture);
    List<Facture> GetFacturesByUser(string userId);
}

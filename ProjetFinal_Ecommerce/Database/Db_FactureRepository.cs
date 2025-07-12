using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Database;

public class Db_FactureRepository : IFactureRepository
{
    private readonly Db_CommerceContext _context;
    public Db_FactureRepository(Db_CommerceContext context)
    {
        _context = context;
    }

    IEnumerable<FactureCommande> IFactureRepository.FactureCommandes => _context.DbSet_Factures.ToList();

    public void Ajouter(FactureCommande facture)
    {
        _context.DbSet_Factures.Add(facture);
        _context.SaveChanges();
    }

    public List<FactureCommande> GetFacturesByUser(string userId)
    {
        return _context.DbSet_Factures
            .Where(f => f.IdentityUserId.Id == userId)
            .Include(f => f.IdentityUserId)
            .ToList();
    }
}

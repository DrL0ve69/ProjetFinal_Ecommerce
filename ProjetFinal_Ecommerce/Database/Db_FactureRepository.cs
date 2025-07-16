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

    IEnumerable<Facture> IFactureRepository.FactureCommandes => _context.DbSet_Factures.ToList();

    public void Ajouter(Facture facture)
    {
        _context.DbSet_Factures.Add(facture);
        //_context.Users.Attach(facture.AppUserConnected);
        _context.SaveChanges();
    }

    public List<Facture> GetFacturesByUser(string userId)
    {
        return _context.DbSet_Factures
            .Where(f => f.AppUserConnected.Id == userId)
            .ToList();
    }
}

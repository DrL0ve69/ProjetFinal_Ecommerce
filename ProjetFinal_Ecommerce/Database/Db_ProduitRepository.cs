using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Database
{
    public class Db_ProduitRepository : IProduitRepository
    {
        private readonly Db_CommerceContext _context;

        public Db_ProduitRepository(Db_CommerceContext context)
        {
            _context = context;
        }

        IEnumerable<Produit> IProduitRepository.MesProduits => _context.DbSet_Produits.ToList();

        public void AddProduit(Produit produit)
        {
            _context.Add(produit);
            _context.SaveChanges();
        }

        public Produit GetProduit(int? id)
        {
            return _context.DbSet_Produits.FirstOrDefault(p => p.Id == id);
        }

        public void ModifierProduit(Produit produit)
        {
            _context.Update(produit);
            _context.SaveChanges();
        }

        public void SupprimerProduit(int id)
        {
            _context.Remove(GetProduit(id));
            _context.SaveChanges();
        }
    }
}

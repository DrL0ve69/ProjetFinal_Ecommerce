
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Database;
using ProjetFinal_Ecommerce.Models;
using System.Text.Json;

namespace ProjetFinal_Ecommerce.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly Db_CommerceContext _context;

        public UtilisateurController(Db_CommerceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            // Gestion du panier
            int compteurPanier = 0;
            // 1. Vérifier s'il existe

            if (HttpContext.Session.Keys.Contains("compteurPanier"))
            {
                compteurPanier = (int)HttpContext.Session.GetInt32("compteurPanier");

            }

            HttpContext.Session.SetInt32("compteurPanier", compteurPanier);


            ViewBag.CompteurPanier = compteurPanier;
            int pageSize = 12;

            return View(await PaginatedList<Produit>.CreateAsync(_context.DbSet_Produits.AsNoTracking(),
                        pageNumber ?? 1, pageSize)); // Créer une page avec une liste paginée
        }
        public IActionResult AjoutPanier(int produitId) 
        {
            // Gestion du panier
            int compteurPanier = 0;
            // 1. Trouver le produit
            var produit = _context.DbSet_Produits.FirstOrDefault(p => p.Id == produitId);

            // 2. Initialiser le panier ou bien le récupérer
            string panier = HttpContext.Session.GetString("Panier");
            if (string.IsNullOrEmpty(panier))
            {
                List<Produit> listeNewPanier = new List<Produit>();
                string jsonNewPanier = JsonSerializer.Serialize(listeNewPanier);

                HttpContext.Session.SetString("Panier", jsonNewPanier);
            }

            List<Produit> listePanier = JsonSerializer.Deserialize<List<Produit>>(panier);
            compteurPanier = listePanier.Count();
            listePanier.Add(produit);

            string jsonPanier = JsonSerializer.Serialize(listePanier);
            HttpContext.Session.SetString("Panier", jsonPanier);

            if (HttpContext.Session.Keys.Contains("compteurPanier"))
            {
                compteurPanier = (int)HttpContext.Session.GetInt32("compteurPanier");

            }
            compteurPanier++;
            HttpContext.Session.SetInt32("compteurPanier", compteurPanier);


            return RedirectToAction("VoirPanier"); // Créer une page avec une liste paginée
        }

        public IActionResult VoirPanier() 
        {
            string panier = HttpContext.Session.GetString("Panier");
            List<Produit> listePanier = JsonSerializer.Deserialize<List<Produit>>(panier);
            return View(listePanier);
        }

    }
}

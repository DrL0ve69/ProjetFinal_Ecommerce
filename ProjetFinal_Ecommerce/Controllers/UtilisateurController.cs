
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Database;
using ProjetFinal_Ecommerce.Models;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetFinal_Ecommerce.Controllers
{
    public class UtilisateurController : Controller
    {
        private readonly Db_CommerceContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UtilisateurController(Db_CommerceContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            // Gestion du panier
            int compteurPanier = 0;
            string panier = HttpContext.Session.GetString("Panier");
            List<Produit> listePanier = new List<Produit>();

            if (!string.IsNullOrEmpty(panier))
            {
                listePanier = JsonSerializer.Deserialize<List<Produit>>(panier);
                ViewData["Panier"] = listePanier;
            }
            else
            {
                ViewData["Panier"] = listePanier;
            }
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
            // Nouveau panier ou panier existant
            List<Produit> listePanier = new List<Produit>();

            // 2. Initialiser le panier ou bien le récupérer
            string panier = HttpContext.Session.GetString("Panier");
            if (string.IsNullOrEmpty(panier))
            {
                
                listePanier.Add(produit);
                string jsonNewPanier = JsonSerializer.Serialize(listePanier);

                HttpContext.Session.SetString("Panier", jsonNewPanier);
            }
            else 
            {
                listePanier = JsonSerializer.Deserialize<List<Produit>>(panier);
                listePanier.Add(produit);
            }
            
            compteurPanier = listePanier.Count();
            ViewData["Panier"] = listePanier;


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

        // Action pour supprimer un item du panier
        public IActionResult SupprimerItemPanier(int produitId) 
        {
            // Gestion du panier
            int compteurPanier = 0;
            // 1. Récupérer le panier
            string panier = HttpContext.Session.GetString("Panier");
            List<Produit> listePanier = JsonSerializer.Deserialize<List<Produit>>(panier);
            // 2. Supprimer le produit du panier
            listePanier.RemoveAll(p => p.Id == produitId);
            // 3. Mettre à jour le panier dans la session
            string jsonPanier = JsonSerializer.Serialize(listePanier);
            HttpContext.Session.SetString("Panier", jsonPanier);
            // 4. Mettre à jour le compteur de produits dans le panier
            compteurPanier = listePanier.Count();
            ViewData["Panier"] = listePanier;
            HttpContext.Session.SetInt32("compteurPanier", compteurPanier);
            return RedirectToAction("VoirPanier"); // Rediriger vers la vue du panier
        }
        // Diminuer le compte d'un item dans le panier
        public IActionResult DiminuerItemPanier(int produitId) 
        {
            // Gestion du panier
            int compteurPanier = 0;
            // 1. Récupérer le panier
            string panier = HttpContext.Session.GetString("Panier");
            List<Produit> listePanier = JsonSerializer.Deserialize<List<Produit>>(panier);
            // 2. Trouver le produit dans le panier
            var produit = listePanier.FirstOrDefault(p => p.Id == produitId);
            if (produit != null)
            {
                // 3. Supprimer le produit du panier
                listePanier.Remove(produit);
                // 4. Mettre à jour le panier dans la session
                string jsonPanier = JsonSerializer.Serialize(listePanier);
                HttpContext.Session.SetString("Panier", jsonPanier);
                // 5. Mettre à jour le compteur de produits dans le panier
                compteurPanier = listePanier.Count();
                ViewData["Panier"] = listePanier;
                HttpContext.Session.SetInt32("compteurPanier", compteurPanier);
            }
            return RedirectToAction("VoirPanier"); // Rediriger vers la vue du panier
        }
        public IActionResult VoirPanier() 
        {
            string panier = HttpContext.Session.GetString("Panier");
            List<Produit> listePanier = new List<Produit>();
            if (string.IsNullOrEmpty(panier))
            {


                string jsonNewPanier = JsonSerializer.Serialize(listePanier);

                HttpContext.Session.SetString("Panier", jsonNewPanier);
            }
            else 
            {
                listePanier = JsonSerializer.Deserialize<List<Produit>>(panier);
            }
                
            ViewData["Panier"] = listePanier;
            return View(listePanier);
        }

        public async Task<IActionResult> VoirFacture() 
        {
            string panier = HttpContext.Session.GetString("Panier");
            
            /*
            if (string.IsNullOrEmpty(panier))
            {
                return View();
            }
            */

            List<Produit> listePanier = JsonSerializer.Deserialize<List<Produit>>(panier);
            ViewData["Panier"] = listePanier;
            string user = User.Identity.Name;
            var userName = User.FindFirstValue(ClaimTypes.Email);

            IdentityUser identityUser = await _userManager.GetUserAsync(User);

            FactureCommande factureCommande = new FactureCommande()
            {
                ProduitsPanier = listePanier,
                IdentityUserId = identityUser,
                
            };
            return View(factureCommande);


        }

    }
}

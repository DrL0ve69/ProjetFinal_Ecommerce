using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Database;
using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Controllers
{
    
    public class ProduitsController : Controller
    {
        private readonly Db_CommerceContext _context;

        public ProduitsController(Db_CommerceContext context)
        {
            _context = context;
        }

        // GET: Produits
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int compteur = 0;

            
            if (HttpContext.Session.Keys.Contains("compteur"))
            {
                compteur = (int)HttpContext.Session.GetInt32("compteur");
                
            }
            compteur++;
            HttpContext.Session.SetInt32("compteur", compteur);



            ViewBag.Compteur = compteur;
            

            int pageSize = 10;

            return View(await PaginatedList<Produit>.CreateAsync(_context.DbSet_Produits.AsNoTracking(),
                        pageNumber ?? 1, pageSize)); // Créer une page avec une liste paginée

            //return View(await _context.DbSet_Produits.ToListAsync());
        }

        public async Task<IActionResult> SearchNom(string rechercheNom, int? pageNumber)
        {
            ViewBag.Search = rechercheNom;

            // Préparer la requête LINQ
            IQueryable<Produit> requete = from produit in _context.DbSet_Produits
                                       where produit.Nom.Contains(rechercheNom)
                                       select produit;

            int pageSize = 5; // Nombre d'objets par page



            return View("Index", await PaginatedList<Produit>.CreateAsync(requete.AsNoTracking(),
                            pageNumber ?? 1, pageSize)); // Créer une page avec les résultats
            //IEnumerable<Produit> result = await requete.ToListAsync();
            //return View("Index", result);
        }
        // Filtre par catégorie
        public async Task<IActionResult> FiltreCategorie(string rechercheId, int? pageNumber)
        {
            ViewBag.FiltreCategorie = rechercheId;

            IQueryable<Produit> requete = _context.DbSet_Produits.Where(p => p.Categorie == rechercheId);
            int pageSize = 3; // Nombre d'objets par page


            return View("Index", await PaginatedList<Produit>.CreateAsync(requete.AsNoTracking(),
                pageNumber ?? 1, pageSize)); // Créer une page avec les résultats
            //IEnumerable<Produit> result = await requete.ToListAsync();
            //return View("Index", result);
        }

        // Filtre par marque
        public async Task<IActionResult> FiltreMarque(string rechercheId, int? pageNumber)
        {
            ViewBag.FiltreMarque = rechercheId;
            int pageSize = 3; // Nombre d'objets par page

            IQueryable<Produit> requete = _context.DbSet_Produits.Where(p => p.Marque == rechercheId);

            IEnumerable<Produit> result = await requete.ToListAsync();
            return View("Index", await PaginatedList<Produit>.CreateAsync(requete.AsNoTracking(),
                pageNumber ?? 1, pageSize));
        }

        // Filtre par prix
        public async Task<IActionResult> FiltrePrix(string rechercheId, int? pageNumber)
        {
            ViewBag.FiltrePrix = rechercheId;
            int pageSize = 5;
            IQueryable<Produit> requete;
            if (rechercheId == "Élevé")
            {
                requete = _context.DbSet_Produits.Where(p => p.PrixUnitaire >= 500);
            }
            else if (rechercheId == "Moyen")
            {
                requete = _context.DbSet_Produits.Where(p => p.PrixUnitaire < 500 && p.PrixUnitaire >= 100);
            }
            else if (rechercheId == "Bas")
            {
                requete = _context.DbSet_Produits.Where(p => p.PrixUnitaire < 100);
            }
            else return NotFound();



            IEnumerable<Produit> result = await requete.OrderBy(prod => prod.PrixUnitaire).ToListAsync();

            return View("Index", await PaginatedList<Produit>.CreateAsync(requete.AsNoTracking(),
                pageNumber ?? 1, pageSize));
        }
        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.DbSet_Produits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: Produits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Marque,Categorie,PrixUnitaire,UrlImage")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // GET: Produits/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.DbSet_Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Marque,Categorie,Prix")] Produit produit)
        {
            if (id != produit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitExists(produit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // GET: Produits/Delete/5
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await _context.DbSet_Produits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produit = await _context.DbSet_Produits.FindAsync(id);
            if (produit != null)
            {
                _context.DbSet_Produits.Remove(produit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitExists(int id)
        {
            return _context.DbSet_Produits.Any(e => e.Id == id);
        }
    }
}

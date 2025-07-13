using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetFinal_Ecommerce.Models;

namespace ProjetFinal_Ecommerce.Controllers
{
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Creer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Creer(string nom)
        {
            IdentityRole role = await _roleManager.FindByNameAsync(nom);

            if (role != null)
            {
                ModelState.AddModelError(nom, "Ce nom de rôle existe déjà, veuillez choisir un autre.");
                return View(nameof(Creer), nom);
            }

            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(nom));

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(nameof(Creer), nom);
        }

        public async Task<IActionResult> Supprimer(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View("Index", _roleManager.Roles);
        }

        /*
        [HttpGet]
        public async Task<IActionResult> ModifierRoleUsager(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            IList<IdentityUser> membres = new List<IdentityUser>();
            List<IdentityUser> nonMembres = new List<IdentityUser>();

            List<IdentityUser> listeUsagers = _userManager.Users.ToList();

            membres = await _userManager.GetUsersInRoleAsync(role.Name);
            nonMembres = _userManager.Users.Where(user => !membres.Contains(user)).ToList();

            RoleMembresViewModel membresRoleVM = new RoleMembresViewModel
            {
                Role = role,
                NonMembres = nonMembres,
                Membres = membres
            };

            return View(membresRoleVM);
        }
        */
        [HttpPost]
        public async Task<IActionResult> ModifierRoleUsager(string roleId, string userId, string modif) 
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByIdAsync(userId);
                IdentityRole role = await _roleManager.FindByIdAsync(roleId);

                if (user != null && role != null)
                {
                    if (modif == "-1")
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        result = await _userManager.AddToRoleAsync(user, role.Name);

                    }

                    if (!result.Succeeded)
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

            }

            return RedirectToAction(nameof(ModifierRoleUsager), "Roles", new { id = roleId });

        }



    }
}

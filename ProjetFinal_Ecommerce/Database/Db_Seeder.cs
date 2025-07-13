using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Models;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ProjetFinal_Ecommerce.Database;

public static class Db_Seeder
{
    private static List<Produit> _seedProduits = new List<Produit>() 
    {
        new Produit
        {
            Nom = "Écouteurs Deluxe",
            Marque = "Beats",
            Categorie = "Électronique",
            PrixUnitaire = 150.99m
        },
        new Produit { Nom = "Écouteurs Deluxe", Marque = "Beats", Categorie = "Électronique", PrixUnitaire = 150.99m },
        new Produit { Nom = "Téléviseur OLED 55\"", Marque = "LG", Categorie = "Électronique", PrixUnitaire = 999.99m },
        new Produit { Nom = "Cafetière Expresso", Marque = "Nespresso", Categorie = "Cuisine", PrixUnitaire = 199.00m },
        new Produit { Nom = "Chaise de Bureau Ergonomique", Marque = "Herman Miller", Categorie = "Mobilier", PrixUnitaire = 899.99m },
        new Produit { Nom = "Smartphone Galaxy S22", Marque = "Samsung", Categorie = "Électronique", PrixUnitaire = 799.99m },
        new Produit { Nom = "Ordinateur Portable XPS 13", Marque = "Dell", Categorie = "Informatique", PrixUnitaire = 1199.00m },
        new Produit { Nom = "Grille-pain 4 tranches", Marque = "Breville", Categorie = "Cuisine", PrixUnitaire = 89.99m },
        new Produit { Nom = "Montre Connectée Series 8", Marque = "Apple", Categorie = "Électronique", PrixUnitaire = 429.00m },
        new Produit { Nom = "Aspirateur sans fil", Marque = "Dyson", Categorie = "Maison", PrixUnitaire = 599.99m },
        new Produit { Nom = "Table de salle à manger", Marque = "IKEA", Categorie = "Mobilier", PrixUnitaire = 349.00m },
        new Produit { Nom = "Lunettes de soleil Aviator", Marque = "Ray-Ban", Categorie = "Mode", PrixUnitaire = 159.99m },
        new Produit { Nom = "Enceinte Bluetooth", Marque = "JBL", Categorie = "Électronique", PrixUnitaire = 99.99m },
        new Produit { Nom = "Jeu FIFA 25", Marque = "EA Sports", Categorie = "Jeux Vidéo", PrixUnitaire = 69.99m },
        new Produit { Nom = "Sac à dos Explorer", Marque = "The North Face", Categorie = "Voyage", PrixUnitaire = 129.99m },
        new Produit { Nom = "Lave-linge 8kg", Marque = "Bosch", Categorie = "Électroménager", PrixUnitaire = 499.00m },
        new Produit { Nom = "Parfum Homme", Marque = "Dior", Categorie = "Beauté", PrixUnitaire = 94.50m },
        new Produit { Nom = "Appareil Photo Reflex", Marque = "Canon", Categorie = "Photographie", PrixUnitaire = 849.00m },
        new Produit { Nom = "Chaussures Running", Marque = "Nike", Categorie = "Sport", PrixUnitaire = 119.99m },
        new Produit { Nom = "Écran 27\" 4K", Marque = "Samsung", Categorie = "Informatique", PrixUnitaire = 329.99m },
        new Produit { Nom = "Tondeuse Électrique", Marque = "Philips", Categorie = "Beauté", PrixUnitaire = 59.99m },
        new Produit { Nom = "Clavier Mécanique", Marque = "Logitech", Categorie = "Informatique", PrixUnitaire = 139.99m },
        new Produit { Nom = "Drone Mini", Marque = "DJI", Categorie = "Électronique", PrixUnitaire = 449.00m },
        new Produit { Nom = "Four Micro-ondes Inox", Marque = "Panasonic", Categorie = "Cuisine", PrixUnitaire = 179.00m },
        new Produit { Nom = "Casque Gaming", Marque = "Razer", Categorie = "Jeux Vidéo", PrixUnitaire = 149.99m },
        new Produit { Nom = "Baskets Mode", Marque = "Adidas", Categorie = "Mode", PrixUnitaire = 89.99m },
        new Produit { Nom = "Lampe de Chevet LED", Marque = "Philips Hue", Categorie = "Maison", PrixUnitaire = 59.00m },
        new Produit { Nom = "Souris Ergonomique", Marque = "Logitech", Categorie = "Informatique", PrixUnitaire = 49.99m },
        new Produit { Nom = "Balance Connectée", Marque = "Withings", Categorie = "Santé", PrixUnitaire = 99.99m },
        new Produit { Nom = "Batteur Électrique", Marque = "Moulinex", Categorie = "Cuisine", PrixUnitaire = 34.90m },
        new Produit { Nom = "Barre de son", Marque = "Sony", Categorie = "Électronique", PrixUnitaire = 249.99m },
        new Produit { Nom = "Jeu de société Catan", Marque = "Kosmos", Categorie = "Loisirs", PrixUnitaire = 39.99m },
        new Produit { Nom = "Pantalon Chino", Marque = "Celio", Categorie = "Mode", PrixUnitaire = 49.90m },
        new Produit { Nom = "Trottinette Électrique", Marque = "Xiaomi", Categorie = "Mobilité", PrixUnitaire = 499.99m },
        new Produit { Nom = "Support Téléphone Voiture", Marque = "Spigen", Categorie = "Accessoires", PrixUnitaire = 19.99m },
        new Produit { Nom = "Imprimante Multifonction", Marque = "HP", Categorie = "Informatique", PrixUnitaire = 159.00m },
        new Produit { Nom = "Bracelet connecté", Marque = "Fitbit", Categorie = "Santé", PrixUnitaire = 129.99m },
        new Produit { Nom = "Pèse-personne digital", Marque = "Terraillon", Categorie = "Santé", PrixUnitaire = 45.00m },
        new Produit { Nom = "Machine à pain", Marque = "Moulinex", Categorie = "Cuisine", PrixUnitaire = 109.00m },
        new Produit { Nom = "Table Basse Bois", Marque = "Conforama", Categorie = "Mobilier", PrixUnitaire = 139.00m },
        new Produit { Nom = "Carte Graphique RTX 4060", Marque = "NVIDIA", Categorie = "Informatique", PrixUnitaire = 349.99m },
        new Produit { Nom = "Brosse à dents Électrique", Marque = "Oral-B", Categorie = "Santé", PrixUnitaire = 89.99m },
        new Produit { Nom = "Jeu Zelda: Breath of the Wild", Marque = "Nintendo", Categorie = "Jeux Vidéo", PrixUnitaire = 59.99m },
        new Produit { Nom = "Mixeur Plongeant", Marque = "Bosch", Categorie = "Cuisine", PrixUnitaire = 49.90m },
        new Produit { Nom = "Appareil Raclette", Marque = "Tefal", Categorie = "Cuisine", PrixUnitaire = 79.99m },
        new Produit { Nom = "Tabouret de Bar", Marque = "But", Categorie = "Mobilier", PrixUnitaire = 69.90m },
        new Produit { Nom = "Guitare Acoustique", Marque = "Yamaha", Categorie = "Musique", PrixUnitaire = 229.00m },
        new Produit { Nom = "Climatisation Portable", Marque = "Rowenta", Categorie = "Maison", PrixUnitaire = 399.00m },
        new Produit { Nom = "Trépied Appareil Photo", Marque = "Manfrotto", Categorie = "Photographie", PrixUnitaire = 89.00m },
        new Produit { Nom = "Lampe Anneau LED", Marque = "Neewer", Categorie = "Photographie", PrixUnitaire = 69.99m },
        new Produit { Nom = "Jeu Zelda: Ocarina of Time", Marque = "Nintendo", Categorie = "Jeux Vidéo", PrixUnitaire = 59.99m },
        new Produit { Nom = "Jeu Zelda: Majora's Mask", Marque = "Nintendo", Categorie = "Jeux Vidéo", PrixUnitaire = 59.99m },
    };
    public static async Task Seed(IApplicationBuilder appBuilder)
    {
        Db_CommerceContext context = appBuilder.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<Db_CommerceContext>();

        if (!context.DbSet_Produits.Any())
        {
            context.DbSet_Produits.AddRange(_seedProduits);
            context.SaveChanges();

        }



        RoleManager<IdentityRole> roleManager = appBuilder.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        UserManager<AppUser> userManager = appBuilder.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        // Trouver le rôle Admin sinon crée le
        IdentityRole role = await roleManager.FindByNameAsync("Admin");
        if (role == null) 
        {
            IdentityResult result = await roleManager.CreateAsync(new IdentityRole("Admin"));
            
        }

        // Trouver le rôle User sinon crée le
        IdentityRole roleUser = await roleManager.FindByNameAsync("User");
        if (roleUser == null)
        {
            IdentityResult result = await roleManager.CreateAsync(new IdentityRole("User"));

        }

        // Ajouter .ToList() pour utiliser foreach en async avec un IQueryable.
        foreach (AppUser user in userManager.Users.ToList()) 
        {
            IdentityResult resultatUser = await userManager.AddToRoleAsync(user, "User");
        }
        
        

        AppUser userAdmin = await userManager.FindByNameAsync("blabla123@email.com");
        if (userAdmin == null) 
        {
            IdentityResult result = await userManager.CreateAsync(new AppUser() { UserName = "blabla123@email.com" });
        }

        // Admin 2 est créé sans problème pour moi peu importe si blabla123 était déjà existant ou pas.
        // Admin2
        AppUser userAdmin2 = await userManager.FindByNameAsync("Admin2@email.com");
        if (userAdmin2 == null)
        {
            IdentityResult result = await userManager.CreateAsync(new AppUser() { UserName = "Admin2@email.com" });
        }

        // Récupère de la base de données
        AppUser admin = await userManager.FindByNameAsync("blabla123@email.com");
        AppUser admin2 = await userManager.FindByNameAsync("Admin2@email.com");

        IdentityRole roleAdmin = await roleManager.FindByNameAsync("Admin");

        // Ajout des propriétés, pourrait être fait à même l'objet
        admin.EmailConfirmed = true;
        admin2.EmailConfirmed = true;

        // Modification du password
        

        IdentityResult resultatTest = await userManager.AddToRoleAsync(admin, roleAdmin.Name);
        IdentityResult resultatTest2 = await userManager.AddToRoleAsync(admin2, roleAdmin.Name);
        IdentityResult resultatTest3 = await userManager.AddPasswordAsync(admin2, "Admin2!");
        context.SaveChanges();
    }
    
}

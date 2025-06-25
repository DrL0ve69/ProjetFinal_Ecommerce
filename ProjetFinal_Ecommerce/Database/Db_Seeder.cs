using ProjetFinal_Ecommerce.Models;

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
            Prix = 150.99m
        },
        new Produit { Nom = "Écouteurs Deluxe", Marque = "Beats", Categorie = "Électronique", Prix = 150.99m },
        new Produit { Nom = "Téléviseur OLED 55\"", Marque = "LG", Categorie = "Électronique", Prix = 999.99m },
        new Produit { Nom = "Cafetière Expresso", Marque = "Nespresso", Categorie = "Cuisine", Prix = 199.00m },
        new Produit { Nom = "Chaise de Bureau Ergonomique", Marque = "Herman Miller", Categorie = "Mobilier", Prix = 899.99m },
        new Produit { Nom = "Smartphone Galaxy S22", Marque = "Samsung", Categorie = "Électronique", Prix = 799.99m },
        new Produit { Nom = "Ordinateur Portable XPS 13", Marque = "Dell", Categorie = "Informatique", Prix = 1199.00m },
        new Produit { Nom = "Grille-pain 4 tranches", Marque = "Breville", Categorie = "Cuisine", Prix = 89.99m },
        new Produit { Nom = "Montre Connectée Series 8", Marque = "Apple", Categorie = "Électronique", Prix = 429.00m },
        new Produit { Nom = "Aspirateur sans fil", Marque = "Dyson", Categorie = "Maison", Prix = 599.99m },
        new Produit { Nom = "Table de salle à manger", Marque = "IKEA", Categorie = "Mobilier", Prix = 349.00m },
        new Produit { Nom = "Lunettes de soleil Aviator", Marque = "Ray-Ban", Categorie = "Mode", Prix = 159.99m },
        new Produit { Nom = "Enceinte Bluetooth", Marque = "JBL", Categorie = "Électronique", Prix = 99.99m },
        new Produit { Nom = "Jeu FIFA 25", Marque = "EA Sports", Categorie = "Jeux Vidéo", Prix = 69.99m },
        new Produit { Nom = "Sac à dos Explorer", Marque = "The North Face", Categorie = "Voyage", Prix = 129.99m },
        new Produit { Nom = "Lave-linge 8kg", Marque = "Bosch", Categorie = "Électroménager", Prix = 499.00m },
        new Produit { Nom = "Parfum Homme", Marque = "Dior", Categorie = "Beauté", Prix = 94.50m },
        new Produit { Nom = "Appareil Photo Reflex", Marque = "Canon", Categorie = "Photographie", Prix = 849.00m },
        new Produit { Nom = "Chaussures Running", Marque = "Nike", Categorie = "Sport", Prix = 119.99m },
        new Produit { Nom = "Écran 27\" 4K", Marque = "Samsung", Categorie = "Informatique", Prix = 329.99m },
        new Produit { Nom = "Tondeuse Électrique", Marque = "Philips", Categorie = "Beauté", Prix = 59.99m },
        new Produit { Nom = "Clavier Mécanique", Marque = "Logitech", Categorie = "Informatique", Prix = 139.99m },
        new Produit { Nom = "Drone Mini", Marque = "DJI", Categorie = "Électronique", Prix = 449.00m },
        new Produit { Nom = "Four Micro-ondes Inox", Marque = "Panasonic", Categorie = "Cuisine", Prix = 179.00m },
        new Produit { Nom = "Casque Gaming", Marque = "Razer", Categorie = "Jeux Vidéo", Prix = 149.99m },
        new Produit { Nom = "Baskets Mode", Marque = "Adidas", Categorie = "Mode", Prix = 89.99m },
        new Produit { Nom = "Lampe de Chevet LED", Marque = "Philips Hue", Categorie = "Maison", Prix = 59.00m },
        new Produit { Nom = "Souris Ergonomique", Marque = "Logitech", Categorie = "Informatique", Prix = 49.99m },
        new Produit { Nom = "Balance Connectée", Marque = "Withings", Categorie = "Santé", Prix = 99.99m },
        new Produit { Nom = "Batteur Électrique", Marque = "Moulinex", Categorie = "Cuisine", Prix = 34.90m },
        new Produit { Nom = "Barre de son", Marque = "Sony", Categorie = "Électronique", Prix = 249.99m },
        new Produit { Nom = "Jeu de société Catan", Marque = "Kosmos", Categorie = "Loisirs", Prix = 39.99m },
        new Produit { Nom = "Pantalon Chino", Marque = "Celio", Categorie = "Mode", Prix = 49.90m },
        new Produit { Nom = "Trottinette Électrique", Marque = "Xiaomi", Categorie = "Mobilité", Prix = 499.99m },
        new Produit { Nom = "Support Téléphone Voiture", Marque = "Spigen", Categorie = "Accessoires", Prix = 19.99m },
        new Produit { Nom = "Imprimante Multifonction", Marque = "HP", Categorie = "Informatique", Prix = 159.00m },
        new Produit { Nom = "Bracelet connecté", Marque = "Fitbit", Categorie = "Santé", Prix = 129.99m },
        new Produit { Nom = "Pèse-personne digital", Marque = "Terraillon", Categorie = "Santé", Prix = 45.00m },
        new Produit { Nom = "Machine à pain", Marque = "Moulinex", Categorie = "Cuisine", Prix = 109.00m },
        new Produit { Nom = "Table Basse Bois", Marque = "Conforama", Categorie = "Mobilier", Prix = 139.00m },
        new Produit { Nom = "Carte Graphique RTX 4060", Marque = "NVIDIA", Categorie = "Informatique", Prix = 349.99m },
        new Produit { Nom = "Brosse à dents Électrique", Marque = "Oral-B", Categorie = "Santé", Prix = 89.99m },
        new Produit { Nom = "Jeu Zelda: Breath of the Wild", Marque = "Nintendo", Categorie = "Jeux Vidéo", Prix = 59.99m },
        new Produit { Nom = "Mixeur Plongeant", Marque = "Bosch", Categorie = "Cuisine", Prix = 49.90m },
        new Produit { Nom = "Appareil Raclette", Marque = "Tefal", Categorie = "Cuisine", Prix = 79.99m },
        new Produit { Nom = "Tabouret de Bar", Marque = "But", Categorie = "Mobilier", Prix = 69.90m },
        new Produit { Nom = "Guitare Acoustique", Marque = "Yamaha", Categorie = "Musique", Prix = 229.00m },
        new Produit { Nom = "Climatisation Portable", Marque = "Rowenta", Categorie = "Maison", Prix = 399.00m },
        new Produit { Nom = "Trépied Appareil Photo", Marque = "Manfrotto", Categorie = "Photographie", Prix = 89.00m },
        new Produit { Nom = "Lampe Anneau LED", Marque = "Neewer", Categorie = "Photographie", Prix = 69.99m },
        new Produit { Nom = "Jeu Zelda: Ocarina of Time", Marque = "Nintendo", Categorie = "Jeux Vidéo", Prix = 59.99m },
        new Produit { Nom = "Jeu Zelda: Majora's Mask", Marque = "Nintendo", Categorie = "Jeux Vidéo", Prix = 59.99m },
    };
    public static void Seed(IApplicationBuilder appBuilder)
    {
        Db_CommerceContext context = appBuilder.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<Db_CommerceContext>();

        if (!context.DbSet_Produits.Any())
        {
            context.DbSet_Produits.AddRange(_seedProduits);

        }
        context.SaveChanges();
    }
}

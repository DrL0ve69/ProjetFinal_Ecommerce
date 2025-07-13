namespace ProjetFinal_Ecommerce.ViewModels;

public class LoginViewModel
{
    public string Email { get; set; } = string.Empty; // Email de l'utilisateur
    public string Password { get; set; } = string.Empty; // Mot de passe de l'utilisateur
    public bool RememberMe { get; set; } = false; // Option pour se souvenir de l'utilisateur
    public string? ReturnUrl { get; set; } // URL de retour après la connexion, si applicable
}

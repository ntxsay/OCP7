using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Le nom d'utilisateur est requis.")]
    public string UserName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Le mot de passe est requis.")]
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; } = false;
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace P7CreateRestApi.ViewModels;

public class Rating
{
    [ValidateNever]
    public int Id {get; set;}
    
    [Required(ErrorMessage = "La note de l'agence de notation Moodys est obligatoire")]
    public string MoodysRating { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La note de l'agence de notation SandP est obligatoire")]
    public string SandPRating { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "La note de l'agence de notation Fitch est obligatoire")]
    public string FitchRating { get; set; } = string.Empty;
    
    [Range(0, 255, ErrorMessage = "Le numéro de l'ordre doit être compris entre 0 et 255")]
    public byte? OrderNumber { get; set; }
}
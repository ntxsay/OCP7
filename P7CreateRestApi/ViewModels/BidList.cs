using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace P7CreateRestApi.ViewModels;

public class BidList
{
    [ValidateNever]
    public int Id { get; set; } 

    [Required(ErrorMessage = "Le compte est obligatoire")]
    public string Account { get; set; } = string.Empty;
        
    [Required(ErrorMessage = "Le type de l'offre est obligatoire")]
    public string BidType { get; set; } = string.Empty;
        
    public double? BidQuantity { get; set; }
}
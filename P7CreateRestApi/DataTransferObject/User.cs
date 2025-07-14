using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace P7CreateRestApi.DataTransferObject;

public class User
{
    [ValidateNever]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Le nom d'utilisateur est obligatoire")]
    public string UserName { get; set; } = string.Empty;
}
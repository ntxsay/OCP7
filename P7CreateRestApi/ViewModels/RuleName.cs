using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace P7CreateRestApi.ViewModels;

public class RuleName
{
    [ValidateNever]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    public string Json { get; set; } = string.Empty;
    public string Template { get; set; } = string.Empty;
    public string SqlStr { get; set; } = string.Empty;
    public string SqlPart { get; set; } = string.Empty;
}
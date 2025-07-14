using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace P7CreateRestApi.DataTransferObject;

public class Rating
{
    [ValidateNever]
    public int Id {get; set;}
    public string MoodysRating { get; set; } = string.Empty;
    public string SandPRating { get; set; } = string.Empty;
    public string FitchRating { get; set; } = string.Empty;
    public byte? OrderNumber { get; set; }
}
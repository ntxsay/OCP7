namespace P7CreateRestApi.Models.Entities;

public class RatingEntity
{
    public int Id {get; set;}
    public string MoodysRating {get; set;} = string.Empty;
    public string SandPRating {get; set;} = string.Empty;
    public string FitchRating {get; set;} = string.Empty;
    public byte? OrderNumber {get; set;}
}
﻿namespace P7CreateRestApi.Models.Entities;

public class RatingEntity
{
    public int Id {get; set;}
    public string MoodysRating {get; set;}
    public string SandPRating {get; set;}
    public string FitchRating {get; set;}
    public byte? OrderNumber {get; set;}
}
﻿namespace P7CreateRestApi.Models.Entities;
public class CurvePointEntity
{
    public int Id {get; set;}
    public byte? CurveId {get; set;}
    public DateTime? AsOfDate {get; set;}
    public double? Term {get; set;}
    public double? CurvePointValue {get; set;}
    public DateTime? CreationDate {get; set;}
}
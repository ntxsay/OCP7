using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace P7CreateRestApi.DataTransferObject;

public class CurvePoint
{
    [ValidateNever]
    public int Id {get; set;}

    [Required(ErrorMessage = "L'identifiant de la courbe ne dois pas être vide")]
    public byte CurveId { get; set; }
    public DateTime? AsOfDate {get; set;}
    public double? Term {get; set;}
    public double? CurvePointValue {get; set;}
    public DateTime? CreationDate {get; set;}
}
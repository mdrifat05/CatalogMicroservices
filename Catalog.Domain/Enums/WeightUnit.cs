using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Enums;

public enum WeightUnit
{
    [Display(Name = "Milligram")]
    Milligram,
    [Display(Name = "Gram")]
    Gram,
    [Display(Name = "Kilogram")]
    Kilogram,
    [Display(Name = "Pound")]
    Pound
}

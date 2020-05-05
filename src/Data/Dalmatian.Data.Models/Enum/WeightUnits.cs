using System.ComponentModel.DataAnnotations;

namespace Dalmatian.Data.Models.Enum
{
    public enum WeightUnits
    {
        [Display(Name = "Kilogram")]
        Kg = 10,

        [Display(Name = "Pound")]
        Lbs = 20,
    }
}

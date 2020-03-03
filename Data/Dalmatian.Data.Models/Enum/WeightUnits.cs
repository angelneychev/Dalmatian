using System.ComponentModel.DataAnnotations;

namespace Dalmatian.Data.Models.Enum
{
    public enum WeightUnits
    {
        [Display(Name = "Kilogram")]
        kg = 10,

        [Display(Name = "Pound")]
        lbs = 20,
    }
}
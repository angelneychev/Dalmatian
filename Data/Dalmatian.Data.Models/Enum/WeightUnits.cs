namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum WeightUnits
    {
        [Display(Name = "Kilogram")]
        Kg = 10,

        [Display(Name = "Pound")]
        Lbs = 20,
    }
}

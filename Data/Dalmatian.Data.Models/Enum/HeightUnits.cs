namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum HeightUnits
    {
        [Display(Name = "Centimeters")]
        cm = 10,

        [Display(Name = "Inches")]
        inch = 20,
    }
}

namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum HeightUnits
    {
        [Display(Name = "Centimeters")]
        Cm = 10,

        [Display(Name = "Inches")]
        Inch = 20,
    }
}

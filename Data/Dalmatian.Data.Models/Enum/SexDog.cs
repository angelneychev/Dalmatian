namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum SexDog
    {
        [Display(Name = "Male")]
        Male = 10,

        [Display(Name = "Female")]
        Female = 20,
    }
}
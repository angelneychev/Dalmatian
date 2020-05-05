namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum Gender
    {
        [Display(Name = "Male")]
        Male = 10,

        [Display(Name = "Female")]
        Female = 20,
    }
}

namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum Gender
    {
        [Display(Name = "Male")]
        MALE = 10,

        [Display(Name = "Female")]
        FEMALE = 20,
    }
}

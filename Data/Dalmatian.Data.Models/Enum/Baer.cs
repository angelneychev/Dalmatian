namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum Baer
    {
        [Display(Name = "Not available")]
        Not_available = 0,

        [Display(Name = "+/+")]
        Bilateral = 10,

        [Display(Name = "-/+")]
        Left_unilateral = 20,

        [Display(Name = "+/-")]
        Right_unilateral = 30,

        [Display(Name = "-/-")]
        Total_deaf = 40,
    }
}

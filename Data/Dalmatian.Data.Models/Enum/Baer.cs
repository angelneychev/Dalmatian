using System.ComponentModel.DataAnnotations;

namespace Dalmatian.Data.Models.Enum
{
    public enum Baer
    {
        [Display(Name = "+/+")]
        Bilateral = 10,

        [Display(Name = "-/+")]
        LeftUnilateral = 20,

        [Display(Name = "+/-")]
        RightUnilateral = 30,

        [Display(Name = "-/-")]
        TotalDeaf = 40,
    }
}

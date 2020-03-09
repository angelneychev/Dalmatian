using System.ComponentModel.DataAnnotations;

namespace Dalmatian.Data.Models.Enum
{
    public enum Baer
    {
        [Display(Name = "+/+")]
        bilateral = 10,

        [Display(Name = "-/+")]
        left_unilateral = 20,

        [Display(Name = "+/-")]
        right_unilateral = 30,

        [Display(Name = "-/-")]
        total_deaf = 40,
    }
}

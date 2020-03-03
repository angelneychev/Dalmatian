namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum Color
    {
        [Display(Name = "white, black spots")]
        WBLS = 10,

        [Display(Name = "white, brown spots")]
        WBRS = 20,
    }
}
using System.ComponentModel;

namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum Color
    {
        [Display(Name = "white, black spots")]
        [Description("white, black spots")]
        Wbls = 10,

        [Display(Name = "white, brown spots")]
        [Description("white, brown spots")]
        Wbrs = 20,
    }
}

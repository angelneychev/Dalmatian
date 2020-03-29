namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum TypeOfMating
    {
        [Display(Name = "Natural mating")]
        NМ = 10,

        [Display(Name = "Artificial insemination w/chilled/fresh sperm")]
        AICFS = 20,

        [Display(Name = "Artificial insemination w/frozen sperm")]
        AIFS = 30,

    }
}

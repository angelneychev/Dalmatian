namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum TypeOfMating
    {
        [Display(Name = "Natural mating")]
        Nм = 10,

        [Display(Name = "Artificial insemination w/chilled/fresh sperm")]
        Aicfs = 20,

        [Display(Name = "Artificial insemination w/frozen sperm")]
        Aifs = 30,
    }
}

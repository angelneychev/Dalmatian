namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum BreedingStatus
    {
        [Display(Name = "Intact")]
        Intact = 10,

        [Display(Name = "Neutered")]
        Neutered = 20,
    }
}

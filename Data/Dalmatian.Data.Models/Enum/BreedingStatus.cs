namespace Dalmatian.Data.Models.Enum
{
    using System.ComponentModel.DataAnnotations;

    public enum BreedingStatus
    {
        [Display(Name = "Not available")]
        Not_available = 0,

        [Display(Name = "Intact")]
        Intact = 10,

        [Display(Name = "Neutered")]
        Neutered = 20,
    }
}

using System.ComponentModel.DataAnnotations;

namespace Dalmatian.Data.Models.Enum
{
    public enum BreedingStatus
    {
        [Display(Name = "Intact")]
        Intact = 10,

        [Display(Name = "Neutered")]
        Neutered = 20,
    }
}
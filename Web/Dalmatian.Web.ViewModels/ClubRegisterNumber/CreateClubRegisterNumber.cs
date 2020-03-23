namespace Dalmatian.Web.ViewModels.ClubRegisterNumber
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;

    public class CreateClubRegisterNumber
    {
        public int Id { get; set; }

        [Required]
        public string RegisterNumber { get; set; }

        public IEnumerable<Dog> Dogs { get; set; }
    }
}
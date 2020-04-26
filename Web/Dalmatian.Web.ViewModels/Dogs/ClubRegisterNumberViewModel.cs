namespace Dalmatian.Web.ViewModels.Dogs
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class ClubRegisterNumberViewModel : IMapFrom<ClubRegisterNumber>
    {
        public int Id { get; set; }

        public string ClubNumber { get; set; }

        public int DogId { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}

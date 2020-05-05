namespace Dalmatian.Web.ViewModels.Dogs
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class ParentViewModel : IMapFrom<Parent>
    {
        public int Id { get; set; }

        public int? FatherDogId { get; set; }

        public int? MotherDogId { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}

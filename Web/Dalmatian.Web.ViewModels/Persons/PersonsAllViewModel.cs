namespace Dalmatian.Web.ViewModels.Persons
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class PersonsAllViewModel : IMapFrom<Kennel>, IMapFrom<ApplicationUser>
    {
        public IEnumerable<PersonViewModel> Persons { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}

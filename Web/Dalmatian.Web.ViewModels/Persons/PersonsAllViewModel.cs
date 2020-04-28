namespace Dalmatian.Web.ViewModels.Persons
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class PersonsAllViewModel : IMapFrom<Person>, IMapFrom<ApplicationUser>
    {
        public IEnumerable<PersonViewModel> Persons { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }

        public int Total { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage - 1;

        public int NextPage => this.CurrentPage + 1;

        public bool PreviousDisable => this.CurrentPage == 1;

        public bool NextDisable
        {
            get
            {
                var maxPage = Math.Ceiling((double)this.Total / 10);

                return maxPage == this.CurrentPage;
            }
        }
    }
}

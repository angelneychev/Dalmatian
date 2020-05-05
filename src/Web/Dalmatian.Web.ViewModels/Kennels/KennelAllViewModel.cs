namespace Dalmatian.Web.ViewModels.Kennels
{
    using System;
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class KennelAllViewModel : IMapFrom<Kennel>, IMapFrom<ApplicationUser>
    {
        public IEnumerable<KennelViewModel> Kennels { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}

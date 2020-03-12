using System;

namespace Dalmatian.Web.ViewModels.Dogs
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class RegistrationDogNumberViewModel : IMapFrom<RegistrationDogNumber>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string RegistrationNumber { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}

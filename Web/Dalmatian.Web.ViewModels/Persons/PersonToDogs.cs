namespace Dalmatian.Web.ViewModels.Persons
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Dogs;

    public class PersonToDogs : IMapFrom<Person>, IMapTo<Person>
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string UserId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Linkedin { get; set; }

        public IEnumerable<DogsViewModel> DogsViewModels { get; set; }
    }
}

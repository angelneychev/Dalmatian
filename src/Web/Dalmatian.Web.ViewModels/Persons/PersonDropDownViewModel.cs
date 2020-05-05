namespace Dalmatian.Web.ViewModels.Persons
{
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class PersonDropDownViewModel : IMapFrom<Person>
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string FullName => this.Firstname + " " + this.Middlename + " " + this.Lastname;
    }
}

namespace Dalmatian.Web.ViewModels.Dogs
{
    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class DogDropDownViewModel : IMapFrom<Dog>
    {
        public int Id { get; set; }

        public string PedigreeName { get; set; }

        public SexDog SexDog { get; set; }
    }
}
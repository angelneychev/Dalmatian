namespace Dalmatian.Web.ViewModels.Kennels
{
    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class KennelsDropDownViewModel : IMapFrom<Kennel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Country Country { get; set; }
    }
}

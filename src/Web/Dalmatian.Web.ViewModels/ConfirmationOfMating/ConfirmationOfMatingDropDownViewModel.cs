namespace Dalmatian.Web.ViewModels.ConfirmationOfMating
{
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class ConfirmationOfMatingDropDownViewModel : IMapFrom<ConfirmationOfMating>
    {
        public int Id { get; set; }

        public string RegistrationNumber { get; set; }
    }
}

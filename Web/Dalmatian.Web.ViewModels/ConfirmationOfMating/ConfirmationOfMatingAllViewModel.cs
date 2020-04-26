namespace Dalmatian.Web.ViewModels.ConfirmationOfMating
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class ConfirmationOfMatingAllViewModel : IMapFrom<ConfirmationOfMating>
    {
        public IEnumerable<ConfirmationOfMatingViewModel> ConfirmationOfMatings { get; set; }
    }
}

namespace Dalmatian.Web.ViewModels.BirthCertificate
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class BirthCertificateAllModel : IMapFrom<BirthCertificate>
    {
        public IEnumerable<BirthCertificateViewModel> BirthCertificates { get; set; }
    }
}

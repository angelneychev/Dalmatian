namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.BirthCertificate;

    public interface IBirthCertificatesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(BirthCertificateInputModel input);

        BirthCertificateViewModel Details(int id);
    }
}
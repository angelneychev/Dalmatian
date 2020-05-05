namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.BirthCertificate;

    public interface IBirthCertificatesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(int id);

        Task<int> CreateAsync(BirthCertificateInputModel input);

        BirthCertificateViewModel Details(int id);

        Task<bool> DoesIdExits(int id);

        BirthCertificateEditModel GetByBirthCertificateId(int id);

        Task UpdateBirthCertificate(BirthCertificateEditModel input);
    }
}

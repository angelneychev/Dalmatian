namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.Kennels;

    public interface IKennelsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(KennelInputModel input);

        KennelViewModel Details(int id);
    }
}

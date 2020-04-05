using System.Collections.Generic;

namespace Dalmatian.Services.Data
{
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.Peoples;

    public interface IPeopleService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(PeopleInputModel input);
    }
}
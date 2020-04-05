namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.Peoples;

    public interface IPeoplesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(PeopleInputModel input);

        PeopleViewModel Details(int id);
    }
}
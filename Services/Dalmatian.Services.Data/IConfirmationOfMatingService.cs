using System.Linq;

namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.ConfirmationOfMating;

    public interface IConfirmationOfMatingService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(int id);

        Task<int> CreateAsync(ConfirmationOfMatingInputModel input);

        //IQueryable<string> Details(int id);

        ConfirmationOfMatingViewModel Details(int id);
    }
}

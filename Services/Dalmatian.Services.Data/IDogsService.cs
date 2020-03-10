namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IDogsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string pedigreeName);

    }
}

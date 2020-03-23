namespace Dalmatian.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Web.ViewModels.ClubRegisterNumber;
    using Dalmatian.Web.ViewModels.Dogs;

    public interface IDogsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string pedigreeName);

        Task<int> CreateAsync(DogCreateInputModel input);
    }
}

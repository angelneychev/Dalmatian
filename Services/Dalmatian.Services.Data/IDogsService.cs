﻿namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.Dogs;

    public interface IDogsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string pedigreeName);

        Task<int> CreateAsync(DogCreateInputModel input);

        IEnumerable<T> SearchDogs<T>(string search);

        //IEnumerable<DogFatherViewModel> DogFather(int id);

        //List<T> SireDogName<T>(int? id);
    }
}

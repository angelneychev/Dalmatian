﻿namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.Persons;

    public interface IPersonsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(PersonInputModel input);

        PersonViewModel Details(int id);
    }
}
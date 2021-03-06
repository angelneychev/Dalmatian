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

        IEnumerable<T> SearchPersons<T>(string search);

        Task<bool> DoesIdExits(int id);

        PersonEditModel GetByPersonId(int id);

        Task UpdatePerson(PersonEditModel input);

        int Total();

        IEnumerable<PersonViewModel> AllPersons(int page = 1);

        public PersonToDogs GetByPersonToDogId(int id);

        public BreederToDogViewModel GetByBreederToDogId(int id);

        public IEnumerable<PersonViewModel> GetTenPersons();
    }
}

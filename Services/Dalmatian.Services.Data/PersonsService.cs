namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Identity;

    public class PersonsService : IPersonsService
    {
        private readonly IDeletableEntityRepository<Person> personRepository;

        public PersonsService(IDeletableEntityRepository<Person> personRepository)
        {
            this.personRepository = personRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count)
        {
            IQueryable<Person> query =
                this.personRepository.All().OrderByDescending(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task<int> CreateAsync(PersonInputModel input)
        {
            var person = new Person()
            {
                Firstname = input.Firstname,
                Middlename = input.Middlename,
                Lastname = input.Lastname,
                Email = input.Email,
                Phone = input.Phone,
                Website = input.Website,
                Country = input.Country,
                City = input.City,
                Address = input.Address,
                Facebook = input.Facebook,
                Twitter = input.Twitter,
                Instagram = input.Instagram,
                Linkedin = input.Linkedin,
                UserId = input.UserId,
            };
            await this.personRepository.AddAsync(person);
            await this.personRepository.SaveChangesAsync();
            return person.Id;
        }

        public PersonViewModel Details(int id)
        {
            var people = this.personRepository.All().Where(x => x.Id == id).To<PersonViewModel>().FirstOrDefault();

            return people;
        }
    }
}

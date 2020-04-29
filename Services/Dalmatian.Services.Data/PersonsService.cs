namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Persons;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class PersonsService : IPersonsService
    {
        private const int PersonPageSize = 10;

        private readonly IDeletableEntityRepository<Person> personRepository;

        public PersonsService(IDeletableEntityRepository<Person> personRepository)
        {
            this.personRepository = personRepository;
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

        public IEnumerable<T> SearchPersons<T>(string search)
        {
            var personSearch = this.personRepository.All().Where(x => x.Firstname.Contains(search) || x.Middlename.Contains(search) || x.Lastname.Contains(search) || x.City.Contains(search) || x.Email.Contains(search) || x.Phone.Contains(search));

            return personSearch.To<T>().ToImmutableList();
        }

        public PersonEditModel GetByPersonId(int id)
        {
            var personId = this.personRepository.All().Where(x => x.Id == id).To<PersonEditModel>().FirstOrDefault();

            return personId;
        }

        public PersonToDogs GetByPersonToDogId(int id)
        {
            var person = this.personRepository.All().To<PersonToDogs>(id).Where(x=>x.Id == id).FirstOrDefault();

            return person;
        }

        public BreederToDogViewModel GetByBreederToDogId(int id)
        {
            var breeder = this.personRepository.All().To<BreederToDogViewModel>(id).Where(x => x.Id == id).FirstOrDefault();

            return breeder;
        }

        public async Task UpdatePerson(PersonEditModel input)
        {
            var person = this.personRepository.All().FirstOrDefault(x => x.Id == input.Id);

            if (person != null)
            {
                person.Firstname = input.Firstname;
                person.Lastname = input.Lastname;
                person.Middlename = input.Middlename;
                person.Email = input.Email;
                person.City = input.City;
                person.Country = input.Country;
                person.Address = input.Address;
                person.Facebook = input.Facebook;
                person.Twitter = input.Twitter;
                person.Instagram = input.Instagram;
            }

            this.personRepository.Update(person);

            await this.personRepository.SaveChangesAsync();
        }

        public async Task<bool> DoesIdExits(int id)
        {
            var obj = await this.personRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            return obj != null;
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

        public int Total() => this.personRepository.All().Count();

        public IEnumerable<PersonViewModel> AllPersons(int page = 1)
        {
            if (page <= 0)
            {
                page = 1;
            }

            var person = this.personRepository.All()
                .Skip((page - 1) * PersonPageSize)
                .Take(PersonPageSize)
                .To<PersonViewModel>()
                .ToList();

            return person;
        }

        public IEnumerable<PersonViewModel> GetTenPersons()
        {
            return this.personRepository.All().OrderBy(x => x.CreatedOn).To<PersonViewModel>().Take(10);
        }
    }
}

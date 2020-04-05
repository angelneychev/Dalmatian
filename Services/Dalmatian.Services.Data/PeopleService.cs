namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Peoples;

    public class PeopleService : IPeopleService
    {
        private readonly IDeletableEntityRepository<People> peopleRepository;

        public PeopleService(IDeletableEntityRepository<People> peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count)
        {
            IQueryable<People> query =
                this.peopleRepository.All().OrderByDescending(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task<int> CreateAsync(PeopleInputModel input)
        {
            var people = new People()
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
            };
            await this.peopleRepository.AddAsync(people);
            await this.peopleRepository.SaveChangesAsync();
            return people.Id;
        }
    }
}

namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Peoples;
    using Microsoft.AspNetCore.Identity;

    public class PeoplesService : IPeoplesService
    {
        private readonly IDeletableEntityRepository<People> peopleRepository;

        public PeoplesService(IDeletableEntityRepository<People> peopleRepository)
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
                UserId = input.UserId,
            };
            await this.peopleRepository.AddAsync(people);
            await this.peopleRepository.SaveChangesAsync();
            return people.Id;
        }

        public PeopleViewModel Details(int id)
        {
            var people = this.peopleRepository.All().Where(x => x.Id == id).To<PeopleViewModel>().FirstOrDefault();

            return people;
        }
    }
}

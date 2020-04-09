namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Kennels;
    using Dalmatian.Web.ViewModels.Persons;

    public class KennelsService : IKennelsService
    {
        private readonly IDeletableEntityRepository<Kennel> kennelRepository;

        public KennelsService(IDeletableEntityRepository<Kennel> kennelRepository)
        {
            this.kennelRepository = kennelRepository;
        }

        public async Task<int> CreateAsync(KennelInputModel input)
        {
            var kennel = new Kennel()
            {
                Name = input.Name,
                RegistrationNumber = input.RegistrationNumber,
                DateOfRegistration = input.DateOfRegistration,
                Country = input.Country,
                City = input.City,
                Address = input.Address,
                PersonOwnerId = input.PersonOwnerId,
                PersonCoOwnerId = input.PersonCoOwnerId,
            };
            await this.kennelRepository.AddAsync(kennel);
            await this.kennelRepository.SaveChangesAsync();
            return kennel.Id;
        }

        public KennelViewModel Details(int id)
        {
            var kennel = this.kennelRepository.All().Where(x => x.Id == id).To<KennelViewModel>().FirstOrDefault();

            return kennel;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Kennel> query = this.kennelRepository.All().OrderByDescending(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }
    }
}

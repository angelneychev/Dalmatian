using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        private readonly UserManager<ApplicationUser> userManager;

        public KennelsService(IDeletableEntityRepository<Kennel> kennelRepository, UserManager<ApplicationUser> userManager)
        {
            this.kennelRepository = kennelRepository;
            this.userManager = userManager;
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

        public KennelEditModel GetById(int id)
        {
          var kennelId = this.kennelRepository.All().Where(x => x.Id == id).To<KennelEditModel>().FirstOrDefault();

            return kennelId;
        }

        public async Task UpdateKennel(KennelEditModel input)
        {
            var kennel = this.kennelRepository.All().FirstOrDefault(x => x.Id == input.Id);

            if (kennel != null)
            {
                kennel.Name = input.Name;
                kennel.RegistrationNumber = input.RegistrationNumber;
                kennel.City = input.City;
                kennel.Country = input.Country;
                kennel.Address = input.Address;
                kennel.DateOfRegistration = input.DateOfRegistration;
                kennel.PersonOwnerId = input.PersonOwnerId;
                kennel.PersonCoOwnerId = input.PersonCoOwnerId;
            }

            this.kennelRepository.Update(kennel);

            await this.kennelRepository.SaveChangesAsync();
        }

        public async Task<bool> DoesIdExits(int id)
        {
            var obj = await this.kennelRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            return obj != null;
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

namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.ConfirmationOfMating;

    public class ConfirmationOfMatingService : IConfirmationOfMatingService
    {
        private readonly IDeletableEntityRepository<ConfirmationOfMating> confirmationOfMatingRepository;

        public ConfirmationOfMatingService(IDeletableEntityRepository<ConfirmationOfMating> confirmationOfMatingRepository)
        {
            this.confirmationOfMatingRepository = confirmationOfMatingRepository;
        }

        public async Task<int> CreateAsync(ConfirmationOfMatingInputModel input)
        {
            var confirmationOfMating = new ConfirmationOfMating()
            {
                DateOfMating = input.DateOfMating,
                EstimatedDateOfBirth = input.EstimatedDateOfBirth,
                RegistrationNumber = input.RegistrationNumber,
                TypeOfMating = input.TypeOfMating,
                DogFatherId = input.DogFatherId,
                DogMotherId = input.DogMotherId,
                OwnerMaleDog = input.OwnerMaleDog,
                OwnerFemaleDog = input.OwnerFemaleDog,
            };
            await this.confirmationOfMatingRepository.AddAsync(confirmationOfMating);
            await this.confirmationOfMatingRepository.SaveChangesAsync();

            return confirmationOfMating.Id;
        }

        public ConfirmationOfMatingViewModel Details(int id)
        {
            var conf = this.confirmationOfMatingRepository.All().Where(x => x.Id == id)
                .Select(x => new ConfirmationOfMatingViewModel()
                {
                    Id = x.Id,
                    RegistrationNumber = x.RegistrationNumber,
                    FatherDogId = x.DogFatherId,
                    MotherDogId = x.DogMotherId,
                    DateOfMating = x.DateOfMating,
                    EstimatedDateOfBirth = x.EstimatedDateOfBirth,
                    TypeOfMating = x.TypeOfMating,
                    OwnerFemaleDog = x.OwnerFemaleDog,
                    OwnerMaleDog = x.OwnerMaleDog,
                }).FirstOrDefault();
            return conf;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<ConfirmationOfMating> query =
                this.confirmationOfMatingRepository.All().OrderBy(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var confirmationOfMating = this.confirmationOfMatingRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return confirmationOfMating;
        }
    }
}

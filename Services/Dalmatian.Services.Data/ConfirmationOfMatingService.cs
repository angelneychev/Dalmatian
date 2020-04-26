namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.ConfirmationOfMating;
    using Microsoft.EntityFrameworkCore;

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
                    DogFatherId = x.DogFatherId,
                    DogMotherId = x.DogMotherId,
                    DateOfMating = x.DateOfMating,
                    EstimatedDateOfBirth = x.EstimatedDateOfBirth,
                    TypeOfMating = x.TypeOfMating,
                    OwnerFemaleDog = x.OwnerFemaleDog,
                    OwnerMaleDog = x.OwnerMaleDog,
                }).FirstOrDefault();
            return conf;
        }

        public ConfirmationOfMatingEditModel GetByConfirmationOfMatingId(int id)
        {
            var confirmationOfMatingId = this.confirmationOfMatingRepository.All().Where(x => x.Id == id).To<ConfirmationOfMatingEditModel>().FirstOrDefault();

            return confirmationOfMatingId;
        }

        public async Task UpdateConfirmationOfMating(ConfirmationOfMatingEditModel input)
        {
            var confirmationOfMating = this.confirmationOfMatingRepository.All().FirstOrDefault(x => x.Id == input.Id);

            if (confirmationOfMating != null)
            {
                confirmationOfMating.RegistrationNumber = input.RegistrationNumber;
                confirmationOfMating.DogFatherId = input.DogFatherId;
                confirmationOfMating.DogMotherId = input.DogMotherId;
                confirmationOfMating.DateOfMating = input.DateOfMating;
                confirmationOfMating.EstimatedDateOfBirth = input.EstimatedDateOfBirth;
                confirmationOfMating.TypeOfMating = input.TypeOfMating;
                confirmationOfMating.OwnerMaleDog = input.OwnerMaleDog;
                confirmationOfMating.OwnerFemaleDog = input.OwnerFemaleDog;
            }

            this.confirmationOfMatingRepository.Update(confirmationOfMating);

            await this.confirmationOfMatingRepository.SaveChangesAsync();
        }

        public async Task<bool> DoesIdExits(int id)
        {
            var obj = await this.confirmationOfMatingRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            return obj != null;
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

namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.BirthCertificate;
    using Microsoft.EntityFrameworkCore;

    public class BirthCertificatesService : IBirthCertificatesService
    {
        private readonly IDeletableEntityRepository<BirthCertificate> birthCertificatesRepository;
        private readonly IDeletableEntityRepository<ConfirmationOfMating> confirmationOfMatingRepository;

        public BirthCertificatesService(
            IDeletableEntityRepository<BirthCertificate> birthCertificateSRepository,
            IDeletableEntityRepository<ConfirmationOfMating> confirmationOfMatingRepository)
        {
            this.birthCertificatesRepository = birthCertificateSRepository;
            this.confirmationOfMatingRepository = confirmationOfMatingRepository;
        }

        public async Task<int> CreateAsync(BirthCertificateInputModel input)
        {
            var birthCertificate = new BirthCertificate()
            {
                RegistrationNumber = input.RegistrationNumber,
                DateOfBirth = input.DateOfBirth,
                ConfirmationOfMatingId = input.ConfirmationOfMatingId,
                NumberOfPuppies = input.NumberOfPuppies,
                NumberOfMales = input.NumberOfMales,
                NumberOfFemales = input.NumberOfFemales,
                PersonId = input.PersonId,
                KennelId = input.KennelId,
                LetterOfLitter = input.LetterOfLitter,
            };
            await this.birthCertificatesRepository.AddAsync(birthCertificate);
            await this.birthCertificatesRepository.SaveChangesAsync();
            return birthCertificate.Id;
        }

        public BirthCertificateViewModel Details(int id)
        {
            var birthCertificate = this.birthCertificatesRepository.All().Where(x => x.Id == id)
                .To<BirthCertificateViewModel>(id).FirstOrDefault();

            return birthCertificate;
        }

        public BirthCertificateEditModel GetByBirthCertificateId(int id)
        {
            var birthCertificateId = this.birthCertificatesRepository.All().Where(x => x.Id == id)
                .To<BirthCertificateEditModel>().FirstOrDefault();

            return birthCertificateId;
        }

        public async Task UpdateBirthCertificate(BirthCertificateEditModel input)
        {
            var birthCertificate = this.birthCertificatesRepository.All().FirstOrDefault(x => x.Id == input.Id);

            if (birthCertificate != null)
            {
                birthCertificate.RegistrationNumber = input.RegistrationNumber;
                birthCertificate.DateOfBirth = input.DateOfBirth;
                birthCertificate.ConfirmationOfMatingId = input.ConfirmationOfMatingId;
                birthCertificate.NumberOfPuppies = input.NumberOfPuppies;
                birthCertificate.NumberOfMales = input.NumberOfMales;
                birthCertificate.NumberOfFemales = input.NumberOfFemales;
                birthCertificate.PersonId = input.PersonId;
                birthCertificate.KennelId = input.KennelId;
            }

            this.birthCertificatesRepository.Update(birthCertificate);

            await this.birthCertificatesRepository.SaveChangesAsync();
        }

        public async Task<bool> DoesIdExits(int id)
        {
            var obj = await this.birthCertificatesRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            return obj != null;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<BirthCertificate> query =
                this.birthCertificatesRepository.All().OrderByDescending(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var birthCertificateg = this.birthCertificatesRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return birthCertificateg;
        }
    }
}

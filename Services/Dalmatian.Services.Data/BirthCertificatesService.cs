using System.Linq;
using Dalmatian.Services.Mapping;

namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Web.ViewModels.BirthCertificate;

    public class BirthCertificatesService : IBirthCertificatesService
    {
        private readonly IDeletableEntityRepository<BirthCertificate> birthCertificateSRepository;

        public BirthCertificatesService(IDeletableEntityRepository<BirthCertificate> birthCertificateSRepository)
        {
            this.birthCertificateSRepository = birthCertificateSRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<BirthCertificate> query =
                this.birthCertificateSRepository.All().OrderByDescending(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
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
                KennelId=input.KennelId,
                LetterOfLitter = input.LetterOfLitter,
            };
            await this.birthCertificateSRepository.AddAsync(birthCertificate);
            await this.birthCertificateSRepository.SaveChangesAsync();
            return birthCertificate.Id;
        }

        public BirthCertificateViewModel Details(int id)
        {
            var birthCertificate = this.birthCertificateSRepository.All().Where(x => x.Id == id).To<BirthCertificateViewModel>().FirstOrDefault();

            return birthCertificate;
        }
    }
}
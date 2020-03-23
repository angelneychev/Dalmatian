using System.Linq;
using System.Threading.Tasks;
using Dalmatian.Data.Common.Repositories;
using Dalmatian.Data.Models;
using Dalmatian.Web.ViewModels.ClubRegisterNumber;

namespace Dalmatian.Services.Data
{
    public class ClubRegisterNumberService : IClubRegisterNumberService
    {
        private readonly IDeletableEntityRepository<ClubRegisterNumber> clubRegisterNumberRepository;

        public ClubRegisterNumberService(IDeletableEntityRepository<ClubRegisterNumber> clubRegisterNumberRepository)
        {
            this.clubRegisterNumberRepository = clubRegisterNumberRepository;
        }

        public async Task<int> CreateClubNumberAsync(CreateClubRegisterNumber input)
        {
           var clubNumber = new ClubRegisterNumber()
           {
               ClubNumber = input.RegisterNumber,
           };
           await this.clubRegisterNumberRepository.AddAsync(clubNumber);
           await this.clubRegisterNumberRepository.SaveChangesAsync();
           return clubNumber.DogId;
        }
    }
}
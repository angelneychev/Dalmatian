namespace Dalmatian.Services.Data
{
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.ClubRegisterNumber;

    public interface IClubRegisterNumberService
    {
        Task<int> CreateClubNumberAsync(CreateClubRegisterNumber input);
    }
}
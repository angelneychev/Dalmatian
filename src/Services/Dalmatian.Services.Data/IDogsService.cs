using System.Collections;

namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dalmatian.Web.ViewModels.Dogs;

    public interface IDogsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string pedigreeName);

        Task<int> CreateAsync(DogCreateInputModel input);

        IEnumerable<T> SearchDogs<T>(string search);

        IEnumerable<T> FindByLitterListDog<T>(int id);

        IEnumerable<T> FindBySiblingsDog<T>(int id);

        Task<bool> DoesIdExits(int id);

        DogEditViewModel GetByDogId(int id);

        Task UpdateDog(DogEditViewModel input);

        public IEnumerable<T> GetAllBaers<T>();

        int GetDogCount();

        int GetDogBaerTestCount();

        int GetDogHipRatingCount();

        int GetDogLiveCount();

        int GetDogDeadCount();

        int GetDogMaleCount();

        int GetDogFemaleCount();

        int GetDogColorBrownCount();

        int GetDogColorBlackCount();

        public IEnumerable GetDogNewRegister();

        public IEnumerable<DogHealtViewModel> GetDogByHealthTest();

        public IEnumerable<DogSexViewMode> GetDogMale();

        public IEnumerable<DogSexViewMode> GetDogFemale();

        public IEnumerable<DogColorViewModel> GetDogColorBrown();

        public IEnumerable<DogColorViewModel> GetDogColorBlack();
    }
}

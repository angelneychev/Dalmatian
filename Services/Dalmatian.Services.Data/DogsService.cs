namespace Dalmatian.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.ClubRegisterNumber;
    using Dalmatian.Web.ViewModels.Dogs;

    public class DogsService : IDogsService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;

        public DogsService(IDeletableEntityRepository<Dog> dogRepository)
        {
            this.dogsRepository = dogRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Dog> query =
                this.dogsRepository.All().OrderBy(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string pedigreeName)
        {
            pedigreeName = Regex.Replace(pedigreeName, @"(\D\d)", string.Empty);

            pedigreeName = pedigreeName.Replace('-', ' ');
            var dogId = this.dogsRepository.All()
                .Where(x => x.PedigreeName == pedigreeName)
                .Select(x => x.Id);

            var dogName = this.dogsRepository.All()
                .Where(x => x.PedigreeName == pedigreeName)
                .To<T>().FirstOrDefault();

            return dogName;
        }

        public async Task<int> CreateAsync(DogCreateInputModel input)
        {
            var dog = new Dog()
            {
                PedigreeName = input.PedigreeName,
                Breed = input.Breed,
                SexDog = input.SexDog,
                DateOfBirth = input.DateOfBirth,
                DateOfDeath = input.DateOfDeath,
                Color = input.Color,
                OwnerName = input.OwnerName,
                BreederName = input.BreederName,
                FatherDogId = input.FatherDogId,
                MotherDogId = input.MotherDogId,
                //UserId= user.Id,
            };
            await this.dogsRepository.AddAsync(dog);

            var clubNumber = new ClubRegisterNumber()
            {
                ClubNumber = input.ClubNumber,
                DateOfClubRegister = input.DateOfClubRegister,
                DogId = dog.Id,
            };

            dog.ClubRegisterNumbers.Add(clubNumber);

            var registrationDogNumber = new RegistrationDogNumber()
            {
                RegistrationNumber = input.RegistrationNumber,
                DateOfRegistrationNumber = input.DateOfRegistrationNumber,
                DogId = dog.Id,
            };

            dog.RegistrationDogNumbers.Add(registrationDogNumber);

            var healthInformation = new HealthInformation()
            {
                Baer = input.Baer,
                DateOfBaer = input.DateOfBaer,
                HipRating = input.HipRating,
                DateOfHipRating = input.DateOfHipRating,
                ElbowRating = input.ElbowRating,
                DateOfElbowRating = input.DateOfElbowRating,
                OtherHealthTest = input.OtherHealthTest,
                DogId = dog.Id,
            };

            dog.HealthInformations.Add(healthInformation);

            var breedingInformation = new BreedingInformation()
            {
                HeightUnits = input.HeightUnits,
                Height = input.Height,
                WeightUnits = input.WeightUnits,
                Weight = input.Weight,
                BreedingStatus = input.BreedingStatus,
                CountryOfOrigin = input.CountryOfOrigin,
                CountryOfResidence = input.CountryOfResidence,
                DogId = dog.Id,
            };

            dog.BreedingInformations.Add(breedingInformation);

            await this.dogsRepository.AddAsync(dog);
            await this.dogsRepository.SaveChangesAsync();
            return dog.Id;
        }
    }
}
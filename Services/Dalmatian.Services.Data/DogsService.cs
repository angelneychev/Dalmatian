namespace Dalmatian.Services.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Data.Common;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Dogs;
    using Microsoft.EntityFrameworkCore;

    public class DogsService : IDogsService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly Cloudinary cloudinary;
        private readonly IDeletableEntityRepository<ClubRegisterNumber> clubRegisterNumberRepository;
        private readonly IDeletableEntityRepository<RegistrationDogNumber> registrationDogNumberRepository;
        private readonly IDeletableEntityRepository<HealthInformation> healthInformationRepository;
        private readonly IDeletableEntityRepository<BreedingInformation> breedingInformationRepository;

        public DogsService(
            IDeletableEntityRepository<Dog> dogRepository,
            Cloudinary cloudinary,
            IDeletableEntityRepository<ClubRegisterNumber> clubRegisterNumberRepository,
            IDeletableEntityRepository<RegistrationDogNumber> registrationDogNumberRepository,
            IDeletableEntityRepository<HealthInformation> healthInformationRepository,
            IDeletableEntityRepository<BreedingInformation> breedingInformationRepository)
        {
            this.dogsRepository = dogRepository;
            this.cloudinary = cloudinary;
            this.clubRegisterNumberRepository = clubRegisterNumberRepository;
            this.registrationDogNumberRepository = registrationDogNumberRepository;
            this.healthInformationRepository = healthInformationRepository;
            this.breedingInformationRepository = breedingInformationRepository;
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
            pedigreeName = Regex.Replace(pedigreeName, @"(\D\d+)", string.Empty);

            pedigreeName = pedigreeName.Replace('-', ' ');
            var fatherDogId = this.dogsRepository.All()
                .Where(x => x.PedigreeName == pedigreeName)
                .Select(x => x.FatherDogId).FirstOrDefault();

            var dogName = this.dogsRepository.All()
                .Where(x => x.PedigreeName == pedigreeName)
                .To<T>().FirstOrDefault();

            return dogName;
        }

        public IEnumerable<T> SearchDogs<T>(string search)
        {
            
            var dogSearch = this.dogsRepository.All().Where(x => x.PedigreeName.Contains(search));

            return dogSearch.To<T>().ToList();
        }

        public IEnumerable<T> FindByLitterListDog<T>(int id)
        {
            var litter = this.dogsRepository.All()
                .Include(f => f.SubFathers)
                .Include(m => m.SubMothers)
                .Where(x => x.FatherDogId == id || x.MotherDogId == id);
            return litter.To<T>().ToList();
        }

        public IEnumerable<T> FindBySiblingsDog<T>(int id)
        {
            var fatherId = this.dogsRepository.All().Where(x => x.Id == id)
                .Select(x => x.FatherDogId).First();

            var motherId = this.dogsRepository.All().Where(x => x.Id == id)
                .Select(x => x.MotherDogId).First();

            var dateOfBirth = this.dogsRepository.All().Where(x => x.Id == id)
                .Select(x => x.DateOfBirth).First();

            var siblings = this.dogsRepository.All()
                .Include(f => f.SubFathers)
                .Include(m => m.SubMothers)
                .Where(x => x.FatherDogId != null
                            && x.FatherDogId == fatherId
                            && x.MotherDogId != null
                            && x.MotherDogId == motherId
                            && x.DateOfBirth == dateOfBirth
                            && x.Id != id);
            return siblings.To<T>().ToList();
        }

        public async Task<bool> DoesIdExits(int id)
        {
            var obj = await this.dogsRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            return obj != null;
        }

        public DogEditViewModel GetByDogId(int id)
        {
            var dog = this.dogsRepository.All().Where(x => x.Id == id).FirstOrDefault();
            var clubRegisterNumber = this.clubRegisterNumberRepository.All().Where(x => x.DogId == id).FirstOrDefault();
            var registrationNumber = this.registrationDogNumberRepository.All().Where(x => x.DogId == id).FirstOrDefault();
            var healthInformation = this.healthInformationRepository.All().Where(x => x.DogId == id).FirstOrDefault();
            var breedingInformation = this.breedingInformationRepository.All().Where(x => x.DogId == id).FirstOrDefault();

            var dogId = new DogEditViewModel
            {
                PedigreeName = dog.PedigreeName,
                Breed = dog.Breed,
                SexDog = dog.SexDog,
                DateOfBirth = dog.DateOfBirth,
                DateOfDeath = dog.DateOfDeath,
                Color = dog.Color,
                PersonOwnerId = dog.PersonOwnerId,
                PersonBreederId = dog.PersonBreederId,
                FatherDogId = dog.FatherDogId,
                MotherDogId = dog.MotherDogId,
                ClubNumber = clubRegisterNumber.ClubNumber,
                DateOfClubRegister = clubRegisterNumber.DateOfClubRegister,
                RegistrationNumber = registrationNumber.RegistrationNumber,
                DateOfRegistrationNumber = registrationNumber.DateOfRegistrationNumber,
                Baer = healthInformation.Baer,
                DateOfBaer = healthInformation.DateOfBaer,
                HipRating = healthInformation.HipRating,
                DateOfHipRating = healthInformation.DateOfHipRating,
                ElbowRating = healthInformation.ElbowRating,
                DateOfElbowRating = healthInformation.DateOfElbowRating,
                OtherHealthTest = healthInformation.OtherHealthTest,
                HeightUnits = breedingInformation.HeightUnits,
                Height = breedingInformation.Height,
                WeightUnits = breedingInformation.WeightUnits,
                Weight = breedingInformation.Weight,
                BreedingStatus = breedingInformation.BreedingStatus,
                CountryOfOrigin = breedingInformation.CountryOfOrigin,
                CountryOfResidence = breedingInformation.CountryOfOrigin,
            };
            return dogId;
        }

        public async Task UpdateDog(DogEditViewModel input)
        {
            var dog = this.dogsRepository.All().Where(x => x.Id == input.Id).FirstOrDefault();

            var clubNumber =
                this.clubRegisterNumberRepository.All().Where(x => x.DogId == input.Id).FirstOrDefault();

            var registrationDogNumber =
                this.registrationDogNumberRepository.All().Where(x => x.DogId == input.Id).FirstOrDefault();

            var healthInformation =
                this.healthInformationRepository.All().Where(x => x.DogId == input.Id).FirstOrDefault();

            var breedingInformation =
                this.breedingInformationRepository.All().Where(x => x.DogId == input.Id).FirstOrDefault();

            if (dog != null)
            {
                dog.PedigreeName = input.PedigreeName;
                dog.Breed = input.Breed;
                dog.SexDog = input.SexDog;
                dog.DateOfBirth = input.DateOfBirth;
                dog.DateOfDeath = input.DateOfDeath;
                dog.Color = input.Color;
                dog.PersonOwnerId = input.PersonOwnerId;
                dog.PersonBreederId = input.PersonBreederId;
                dog.FatherDogId = input.FatherDogId;
                dog.MotherDogId = input.MotherDogId;
            }

            if (clubNumber != null)
            {
                clubNumber.ClubNumber = input.ClubNumber;
                clubNumber.DateOfClubRegister = input.DateOfClubRegister;
                clubNumber.DogId = dog.Id;
            }

            if (registrationDogNumber != null)
            {
                registrationDogNumber.RegistrationNumber = input.RegistrationNumber;
                registrationDogNumber.DateOfRegistrationNumber = input.DateOfRegistrationNumber;
                registrationDogNumber.DogId = dog.Id;
            }

            if (healthInformation != null)
            {
                healthInformation.Baer = input.Baer;
                healthInformation.DateOfBaer = input.DateOfBaer;
                healthInformation.HipRating = input.HipRating;
                healthInformation.DateOfHipRating = input.DateOfHipRating;
                healthInformation.ElbowRating = input.ElbowRating;
                healthInformation.DateOfElbowRating = input.DateOfElbowRating;
                healthInformation.OtherHealthTest = input.OtherHealthTest;
                healthInformation.DogId = dog.Id;
            }

            if (breedingInformation != null)
            {
                breedingInformation.HeightUnits = input.HeightUnits;
                breedingInformation.Height = input.Height;
                breedingInformation.WeightUnits = input.WeightUnits;
                breedingInformation.Weight = input.Weight;
                breedingInformation.BreedingStatus = input.BreedingStatus;
                breedingInformation.CountryOfOrigin = input.CountryOfOrigin;
                breedingInformation.CountryOfResidence = input.CountryOfResidence;
                breedingInformation.DogId = dog.Id;
            }

            this.dogsRepository.Update(dog);
            this.clubRegisterNumberRepository.Update(clubNumber);
            this.registrationDogNumberRepository.Update(registrationDogNumber);
            this.healthInformationRepository.Update(healthInformation);
            this.breedingInformationRepository.Update(breedingInformation);

            await this.dogsRepository.SaveChangesAsync();
            await this.clubRegisterNumberRepository.SaveChangesAsync();
            await this.registrationDogNumberRepository.SaveChangesAsync();
            await this.healthInformationRepository.SaveChangesAsync();
            await this.breedingInformationRepository.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(DogCreateInputModel input)
        {
            var imageUrl = await ApplicationCloudinary.UploadImage(this.cloudinary, input.ImagesUrl, input.PedigreeName);

            var dog = new Dog()
            {
                PedigreeName = input.PedigreeName,
                Breed = input.Breed,
                SexDog = input.SexDog,
                ImagesUrl = imageUrl,
                DateOfBirth = input.DateOfBirth,
                DateOfDeath = input.DateOfDeath,
                Color = input.Color,
                PersonOwnerId = input.PersonOwnerId,
                PersonBreederId = input.PersonBreederId,
                FatherDogId = input.FatherDogId,
                MotherDogId = input.MotherDogId,
            };

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

        public IEnumerable<T> GetAllBaers<T>()
        {
           var dogBaer = this.healthInformationRepository
                .All()
                .Where(x => x.Baer > 0)
                .To<T>();

           return dogBaer.To<T>().ToList();
        }

        public int GetDogCount()
        {
            return this.dogsRepository.All().Count();
        }

        public int GetDogBaerTestCount()
        {
            return this.healthInformationRepository.All().Count(x => x.Baer > 0);
        }

        public int GetDogHipRatingCount()
        {
            return this.healthInformationRepository.All().Count(x => x.HipRating > 0);
        }

        public int GetDogLiveCount()
        {
            return this.dogsRepository.All().Count(x => x.DateOfDeath == null);
        }

        public int GetDogDeadCount()
        {
            return this.dogsRepository.All().Count(x => x.DateOfDeath != null);
        }

        public int GetDogMaleCount()
        {
            return this.dogsRepository.All().Count(x => x.SexDog == SexDog.Male);
        }

        public int GetDogFemaleCount()
        {
            return this.dogsRepository.All().Count(x => x.SexDog == SexDog.Female);
        }

        public int GetDogColorBrownCount()
        {
            return this.dogsRepository.All().Count(x => x.SexDog == SexDog.Female);
        }

        public int GetDogColorBlackCount()
        {
            return this.dogsRepository.All().Count(x => x.SexDog == SexDog.Female);
        }

        public IEnumerable GetDogNewRegister()
        {
            return this.dogsRepository.All().OrderBy(x => x.CreatedOn).To<DogNewRegisterViewModel>().Take(10);
        }

        public IEnumerable<DogHealtViewModel> GetDogByHealthTest()
        {
            var baer = this.healthInformationRepository.All().Where(x => x.Baer > 0);

            var dog = this.dogsRepository.All().OrderBy(x => x.CreatedOn).To<DogHealtViewModel>(baer);

            return dog;
        }

        public IEnumerable<DogSexViewMode> GetDogMale()
        {
            return this.dogsRepository.All().OrderBy(x => x.CreatedOn).To<DogSexViewMode>().Where(x => x.SexDog == SexDog.Male);
        }

        public IEnumerable<DogSexViewMode> GetDogFemale()
        {
            return this.dogsRepository.All().OrderBy(x => x.CreatedOn).To<DogSexViewMode>().Where(x => x.SexDog == SexDog.Female);
        }

        public IEnumerable<DogColorViewModel> GetDogColorBrown()
        {
            return this.dogsRepository.All().OrderBy(x => x.CreatedOn).To<DogColorViewModel>().Where(x => x.Color == Color.WBLS);
        }

        public IEnumerable<DogColorViewModel> GetDogColorBlack()
        {
            return this.dogsRepository.All().OrderBy(x => x.CreatedOn).To<DogColorViewModel>().Where(x => x.Color == Color.WBBS);
        }
    }
}

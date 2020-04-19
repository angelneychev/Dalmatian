﻿namespace Dalmatian.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Data.Common;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Dogs;
    using Microsoft.EntityFrameworkCore;

    public class DogsService : IDogsService
    {
        private readonly IDeletableEntityRepository<Dog> dogsRepository;
        private readonly Cloudinary cloudinary;

        public DogsService(IDeletableEntityRepository<Dog> dogRepository, Cloudinary cloudinary)
        {
            this.dogsRepository = dogRepository;
            this.cloudinary = cloudinary;
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
                //UserId= user.Id,
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
    }
}

using System;

namespace Dalmatian.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Dalmatian.Data.Common.Repositories;
    using Dalmatian.Data.Models;
    using Dalmatian.Services.Mapping;

    public class DogsService : IDogsService
    {
        private readonly IDeletableEntityRepository<Dog> dogRepository;

        public DogsService(IDeletableEntityRepository<Dog> dogRepository)
        {
            this.dogRepository = dogRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Dog> query =
                this.dogRepository.All().OrderBy(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string pedigreeName)
        {
            pedigreeName = pedigreeName.Replace('-', ' ');
            var dog = this.dogRepository.All().Where(x => x.PedigreeName == pedigreeName)
                .To<T>().FirstOrDefault();

            return dog;
        }
    }
}
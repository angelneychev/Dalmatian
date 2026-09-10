namespace Dalmatian.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data;
    using Dalmatian.Data.Models;
    using Dalmatian.Data.Repositories;
    using Dalmatian.Services.Mapping;
    using Dalmatian.Web.ViewModels.Home;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class Net10CompatibilityTests
    {
        [Fact]
        public void RegisteredMappingsProjectDogSearchResults()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            AutoMapperConfig.RegisterMappings(loggerFactory, typeof(IndexDogsViewModel).Assembly);
            var dogs = new[]
            {
                new Dog { Id = 42, PedigreeName = "Demo Dalmatian", FatherDogId = 7 },
            }.AsQueryable();

            var result = dogs.To<IndexDogsViewModel>().Single();

            Assert.Equal(42, result.Id);
            Assert.Equal(7, result.FatherDogId);
            Assert.Equal("Demo Dalmatian", result.PedigreeName);
            Assert.Equal("/club-dogs/Demo-Dalmatian-42", result.Url);
        }

        [Fact]
        public async Task SoftDeletedRecordsCanBeFoundAndRestored()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using var context = new ApplicationDbContext(options);
            using var repository = new EfDeletableEntityRepository<Setting>(context);
            var setting = new Setting();
            await repository.AddAsync(setting);
            await repository.SaveChangesAsync();
            Assert.NotEqual(default, setting.CreatedOn);

            repository.Delete(setting);
            await repository.SaveChangesAsync();
            Assert.Empty(repository.All());
            Assert.NotNull(setting.DeletedOn);
            Assert.Same(setting, await repository.GetByIdWithDeletedAsync(setting.Id));

            repository.Undelete(setting);
            await repository.SaveChangesAsync();
            Assert.Single(repository.All());
            Assert.Null(setting.DeletedOn);
        }
    }
}

namespace Dalmatian.Data.Configurations
{
    using Dalmatian.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> dog)
        {
            dog
                .HasMany(a => a.Parents)
                .WithOne(b => b.Dog)
                .HasForeignKey(b => b.DogId);

            dog
                .HasMany(a => a.BreedingInformations)
                .WithOne(b => b.Dog)
                .HasForeignKey(b => b.DogId);

            dog
                .HasMany(a => a.HealthInformations)
                .WithOne(b => b.Dog)
                .HasForeignKey(b => b.DogId);

            dog
                .HasMany(a => a.RegistrationDogNumbers)
                .WithOne(b => b.Dog)
                .HasForeignKey(b => b.DogId);
        }
    }
}

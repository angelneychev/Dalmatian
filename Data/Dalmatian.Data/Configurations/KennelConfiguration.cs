namespace Dalmatian.Data.Configurations
{
    using Dalmatian.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KennelConfiguration : IEntityTypeConfiguration<Kennel>
    {
        public void Configure(EntityTypeBuilder<Kennel> kennel)
        {
            //dog
            //    .HasMany(d => d.SubFathers)
            //    .WithOne(d => d.Father)
            //    .HasForeignKey(d => d.FatherDogId);

            //dog
            //    .HasMany(d => d.SubMothers)
            //    .WithOne(d => d.Mother)
            //    .HasForeignKey(d => d.MotherDogId);

            //dog
            //    .HasMany(a => a.BreedingInformations)
            //    .WithOne(b => b.Dog)
            //    .HasForeignKey(b => b.DogId);

            //dog
            //    .HasMany(a => a.HealthInformations)
            //    .WithOne(b => b.Dog)
            //    .HasForeignKey(b => b.DogId);

            //dog
            //    .HasMany(a => a.RegistrationDogNumbers)
            //    .WithOne(b => b.Dog)
            //    .HasForeignKey(b => b.DogId);

            //kennel
            //    .HasOne(x => x.PeopleOwner)
            //    .WithMany(x => x.Kennels)
            //    .HasForeignKey(x => x.PeopleOwnerId);
            //kennel
            //    .HasOne(x => x.PeopleCoOwner)
            //    .WithMany(x => x.Kennels)
            //    .HasForeignKey(x => x.PeopleCoOwnerId);
        }
    }
}

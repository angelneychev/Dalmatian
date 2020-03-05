using Dalmatian.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dalmatian.Data.Configurations
{
    public class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> dog)
        {
            dog
                .HasOne(a => a.Parent)
                .WithOne(b => b.Dog)
                .HasForeignKey<Parent>(b => b.DogId);
        }
    }
}
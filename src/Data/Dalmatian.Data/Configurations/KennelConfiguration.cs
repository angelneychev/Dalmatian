namespace Dalmatian.Data.Configurations
{
    using Dalmatian.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KennelConfiguration : IEntityTypeConfiguration<Kennel>
    {
        public void Configure(EntityTypeBuilder<Kennel> kennel)
        {
        }
    }
}

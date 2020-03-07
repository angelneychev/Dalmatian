using System.Collections.Generic;

namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Kennel : BaseDeletableModel<int>
    {
        public Kennel()
        {
            this.Breeders = new HashSet<Breeder>();
        }

        public string Name { get; set; }

        public string RegistrationNumber { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public virtual ICollection<Breeder> Breeders { get; set; }
    }
}

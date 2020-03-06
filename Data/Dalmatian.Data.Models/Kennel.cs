namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Kennel : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string RegistrationNumber { get; set; }

        public string OwnerName { get; set; }
        //public Person Person { get; set; }

        //public int? PersonId { get; set; }

        public Breed Breed { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string LinkedIn { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

    }
}

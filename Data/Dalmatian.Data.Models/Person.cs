namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Person : BaseDeletableModel<int>
    {
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public Country Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Linkedin { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

    }
}

namespace Dalmatian.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Common.Models;
    using Dalmatian.Data.Models.Enum;

    public class Person : BaseDeletableModel<int>
    {
        [MaxLength(30)]
        public string Firstname { get; set; }

        [MaxLength(30)]
        public string Middlename { get; set; }

        [MaxLength(30)]
        public string Lastname { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(100)]
        public string Website { get; set; }

        public Country Country { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Facebook { get; set; }

        [MaxLength(100)]
        public string Twitter { get; set; }

        [MaxLength(100)]
        public string Instagram { get; set; }

        [MaxLength(100)]
        public string Linkedin { get; set; }
    }
}

namespace Dalmatian.Web.ViewModels.Persons
{
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Data.Models;
    using Dalmatian.Data.Models.Enum;
    using Dalmatian.Services.Mapping;

    public class PersonEditModel : IMapFrom<Person>, IMapTo<Person>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "* Firstname")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Middlename")]
        public string Middlename { get; set; }

        [Required]
        [Display(Name = "* Lastname")]
        public string Lastname { get; set; }

        [Display(Name = "UserId")]
        public string UserId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "* Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "* Phone")]
        public string Phone { get; set; }

        [Required] [Display(Name = "Website")]
        public string Website { get; set; }

        [Required]
        [Display(Name = "* Country")]
        public Country Country { get; set; }

        [Required] [Display(Name = "* City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "* Address")]
        public string Address { get; set; }

        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [Display(Name = "Twitter")]
        public string Twitter { get; set; }

        [Display(Name = "Instagram")]
        public string Instagram { get; set; }

        [Display(Name = "Linkedin")]
        public string Linkedin { get; set; }
    }
}

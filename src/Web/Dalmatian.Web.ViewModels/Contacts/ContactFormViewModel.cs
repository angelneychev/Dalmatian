namespace Dalmatian.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    using Dalmatian.Web.Infrastructure;

    public class ContactFormViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your names ")]
        [Display(Name = "Your names")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Your email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a message title")]
        [StringLength(100, ErrorMessage = "The title must be at least 5 and not more than 100 characters long.", MinimumLength = 5)]
        [Display(Name = "Message title")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the content of the message")]
        [StringLength(10000, ErrorMessage = "Message must be at least 20 characters", MinimumLength = 20)]
        [Display(Name = "Content of the message")]
        public string Content { get; set; }
    }
}

namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;

    public class ContactFormEntry : BaseModel<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Ip { get; set; }

    }
}
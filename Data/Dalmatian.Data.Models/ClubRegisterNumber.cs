namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;

    public class ClubRegisterNumber : BaseDeletableModel<int>
    {
        public string ClubNumber { get; set; }
    }
}
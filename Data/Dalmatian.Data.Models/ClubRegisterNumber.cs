using Dalmatian.Data.Common.Models;

namespace Dalmatian.Data.Models
{
    public class ClubRegisterNumber : BaseDeletableModel<int>
    {
        public string ClubNumber { get; set; }
    }
}
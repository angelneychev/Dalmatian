namespace Dalmatian.Data.Models
{
    using Dalmatian.Data.Common.Models;

    public class Parent : BaseDeletableModel<int>
    {

        public int? FatherId { get; set; }

        public int? MotherId { get; set; }

    }
}
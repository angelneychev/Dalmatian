namespace Dalmatian.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexDogsViewModel> Dogs { get; set; }
    }
}
namespace Dalmatian.Web.ViewModels.Administration.User
{
    using System.Collections.Generic;

    using Dalmatian.Data.Models;

    public class UserRolesViewModel
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsSelected { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}

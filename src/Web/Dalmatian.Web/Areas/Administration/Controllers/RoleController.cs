﻿namespace Dalmatian.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Web.ViewModels.Administration.Role;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RoleController : AdministrationController
    {

        private readonly RoleManager<ApplicationRole> roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return this.View();
        }

        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var applicationRole = new ApplicationRole
                {
                    Name = model.RoleName,
                };

                var result = await this.roleManager.CreateAsync(applicationRole);

                if (result.Succeeded)
                {
                    return this.RedirectToAction("index", "Dashboard");
                }

                foreach (IdentityError error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return this.View(model);
        }
    }
}

namespace Dalmatian.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dalmatian.Data.Models;
    using Dalmatian.Web.ViewModels.Administration.User;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult ListAllUsers()
        {
            var users = this.userManager.Users;
            return this.View(users);
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            this.ViewBag.userId = userId;

            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                this.ViewData["Errorname"] = $"User with Id = {userId} cannot be found";

                return this.NotFound();
            }

            var model = new List<UserRolesViewModel>();

            foreach (var role in this.roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };

                if (await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null)
            {
                this.ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return this.NotFound();
            }

            var roles = await this.userManager.GetRolesAsync(user);
            var result = await this.userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                this.ModelState.AddModelError(string.Empty, "Cannot remove user existing roles");
                return this.View(model);
            }

            result = await this.userManager.AddToRolesAsync(
                user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                this.ModelState.AddModelError(string.Empty, "Cannot add selected roles to user");
                return this.View(model);
            }

            return this.RedirectToAction(nameof(this.ListAllUsers)); //new { id = personId });
        }
    }
}

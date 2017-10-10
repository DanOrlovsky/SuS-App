using SuS.Data.Models;
using SuS.Service.FileServices;
using SuS.Service.MemberServices;
using SuS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SuS.Web.Controllers
{
    public class InstallController : Controller
    {
        // GET: Install
        public ActionResult Install()
        {
            if (RoleActions.RoleExists(RoleActions.SuperUserRole))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult SetupUser([Bind(Include ="CompanyName,UserName,FirstName,LastName,Email,Password,ConfirmPassword,ConnectionString")]InstallViewModel model)
        {

            ApplicationUser newUser = new ApplicationUser();
            RoleActions roleActions = new RoleActions();
            UserActions userActions = new UserActions();

            newUser.UserName = model.Email;
            newUser.CompanyName = model.CompanyName;
            newUser.FirstName = model.FirstName;
            newUser.LastName = model.LastName;
            newUser.Email = model.Email;
            newUser.EmailConfirmed = true;
            newUser.PasswordHash = Crypto.HashPassword(model.Password);
            roleActions.AddRole(RoleActions.SuperUserRole);
            userActions.AddUser(newUser);
            userActions.AddUserToRole(newUser, RoleActions.SuperUserRole);
            return RedirectToAction("Index",  "Home");
        }
    }
}
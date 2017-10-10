using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SuS.Data.DAL;
using SuS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Service.MemberServices
{
    public class UserActions
    {

        public bool AddUser(ApplicationUser user)
        {
            SuSDbContext context = new SuSDbContext();
            var mgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var userResult = mgr.Create(user);
            return true;
        }

        public bool AddUserToRole(ApplicationUser user, string role)
        {
            SuSDbContext context = new SuSDbContext();
            var mgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if(!mgr.IsInRole(user.Id, role))
            {
                mgr.AddToRole(user.Id, role);
                return true;
            }

            return false;
        }
    }
}

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SuS.Data.DAL;

namespace SuS.Service.MemberServices
{
    public class RoleActions
    {
        public static string SuperUserRole = "SuperUser";
        //RoleStore<IdentityRole> store;
        
        public RoleActions()
        {
            
        }

        public bool AddRole(string roleName)
        {
            SuSDbContext context = new SuSDbContext();
            IdentityResult roleResult;

            var store = new RoleStore<IdentityRole>(context);
            var mgr = new RoleManager<IdentityRole>(store);

            if(!mgr.RoleExists(roleName))
            {
                roleResult = mgr.Create(new IdentityRole { Name = roleName });
            }

            return true;
        }

        public static bool RoleExists(string roleName)
        {
            SuSDbContext context = new SuSDbContext();

            var mgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            return mgr.RoleExists(roleName);
        }

    }
}

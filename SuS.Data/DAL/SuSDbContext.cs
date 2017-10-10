using Microsoft.AspNet.Identity.EntityFramework;
using SuS.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuS.Data.DAL
{
    public class SuSDbContext : IdentityDbContext<ApplicationUser>
    {
        
        
        public SuSDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        { }

        public static SuSDbContext Create()
        {
            return new SuSDbContext();
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<SelectionCategory> SelectionCategories { get; set; }
        public DbSet<OptionsCategory> OptionsCategories { get; set; }
        public DbSet<Option> Options { get; set; }
        
    }
}



using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreIdentityCustomization.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using AspNetCoreIdentityCustomization.Core;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIdentityCustomization.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        //  public DbSet<PostLog> PostLogs { get; set; }
    }

    public class ApplicationModelDbContext : System.Data.Entity.DbContext
    {
        public ApplicationModelDbContext()
             : base("name=ApplicationModelDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public System.Data.Entity.DbSet<PostLog> PostLogs { get; set; }
    }
}

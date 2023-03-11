using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreIdentityCustomization.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using AspNetCoreIdentityCustomization.Core;
//using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AspNetCoreIdentityCustomization.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IConfiguration _config;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options) {
            _config= configuration;
        }
        //  public DbSet<PostLog> PostLogs { get; set; }
       // public System.Data.Entity.DbSet<PostLog> PostLog { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
            }
        }
    }

    public class ApplicationModelDbContext : DbContext
    {
        private IConfiguration _config;
        public ApplicationModelDbContext(IConfiguration config, DbContextOptions<ApplicationModelDbContext> options) : base(options)
        {
            _config = config;

        }

        public DbSet<PostLog> PostLog { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseSqlServer(_config.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);


        }
    }
}

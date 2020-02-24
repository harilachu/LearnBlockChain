using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SimpleAssetManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pippette> Pippettes { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<PippetteUser> PippetteUsers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}

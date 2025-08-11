using ApplicationRoleManagementSystem1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApplicationRoleManagementSystem1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ApplicationModel> Applications { get; set; }
    }
}

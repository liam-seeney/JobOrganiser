using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobOrganiserWebApp.Models;

namespace JobOrganiserWebApp.Data
{
    public class JobOrganiserWebAppContext : DbContext
    {
        public JobOrganiserWebAppContext (DbContextOptions<JobOrganiserWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<JobOrganiserWebApp.Models.Customer>? Customer { get; set; }
    }
}

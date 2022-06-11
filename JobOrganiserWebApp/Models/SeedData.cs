using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JobOrganiserWebApp.Data;
using System;
using System.Linq;

namespace JobOrganiserWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JobOrganiserWebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<JobOrganiserWebAppContext>>()))
            {
                if (context.Customer.Any() && context.JobInfo.Any())
                {
                    return;   // DB has been seeded
                }

                context.JobInfo.AddRange(
                    new JobInfo
                    {
                        JobTitle = "Fix Door",
                        JobDescription = "Replcae door hinges, handles and latch",
                        EstCompletionDate = DateTime.Today
                    },

                    new JobInfo
                    {
                        JobTitle = "Fix toilet",
                        JobDescription = "New toilet seat and flusher",
                        EstCompletionDate = DateTime.Today
                    }
                );
                context.Customer.AddRange(
                    new Customer
                    {
                        FirstName = "Bob",
                        LastName = "DaBuilder",
                        EmailAddress = "abc@test.com"
                    },

                    new Customer
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        EmailAddress = "xyz@test.com"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
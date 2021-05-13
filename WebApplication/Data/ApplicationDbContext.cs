using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<ClassInputModels> ClassInputModeles { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ClassInputModels>((pc =>
        //    {
        //        pc.HasNoKey();
        //        pc.ToView("View_ClassInputModeles");
        //    }));
        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}

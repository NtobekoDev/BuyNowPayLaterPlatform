using System;
using Microsoft.EntityFrameworkCore;
using BNPLService.Models;


namespace BNPLService.Data
{

    public class BNPLDbContext : DbContext
    {
        public BNPLDbContext(DbContextOptions<BNPLDbContext> options) : base(options)
        {
        }
        public DbSet<BNPLApp> BNPLApps { get; set; }
    }

}



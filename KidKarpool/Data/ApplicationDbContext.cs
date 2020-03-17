using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KidKarpool.Models;

namespace KidKarpool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<Request> Requests { get; set; }
        
        public DbSet<KidKarpool.Models.Accept> Accept { get; set; }
    }
}

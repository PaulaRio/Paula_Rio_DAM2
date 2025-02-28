using System.Collections.Generic;
using System.Reflection.Emit;
using PlantillaAPI.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PlantillaAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //Add models here
       
        public DbSet<User> Users { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

       // public DbSet<GhibliEntity> Ghibli { get; set; }

    }
}